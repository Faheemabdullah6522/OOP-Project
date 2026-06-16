
CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Email VARCHAR(255) NOT NULL UNIQUE,       
    Password VARCHAR(255) NOT NULL,           
    Role VARCHAR(50) NULL DEFAULT 'Student',   
    IsVerified BIT NOT NULL DEFAULT 0,         
    FullName NVARCHAR(150) NULL,
    Phone VARCHAR(20) NULL,
    Address NVARCHAR(500) NULL,
    DateOfBirth DATETIME NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Students (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NULL, 
    UserEmail VARCHAR(255) NOT NULL UNIQUE,
    FullName NVARCHAR(150) NULL,
    FatherName NVARCHAR(150) NULL,
    CNIC VARCHAR(20) NULL,
    MobileNumber VARCHAR(20) NULL,
    Email VARCHAR(255) NULL,
    Gender VARCHAR(20) NULL,
    Religion NVARCHAR(50) NULL,
    DateOfAdmission DATETIME NULL,
    DisabilityStatus NVARCHAR(100) NULL,
    FamilyIncome DECIMAL(18,2) NULL,
    SemesterYear VARCHAR(50) NULL,
    RollNumber VARCHAR(50) NULL,
    Department NVARCHAR(150) NULL,
    DegreeProgram NVARCHAR(150) NULL,
    UniversityName NVARCHAR(250) NULL,
    RegistrationNumber VARCHAR(100) NULL,
    CGPA DECIMAL(3,2) NULL,
    DateOfBirth DATETIME NULL,
    DomicileDistrict NVARCHAR(100) NULL,
    Province NVARCHAR(100) NULL,
    District NVARCHAR(100) NULL,
    TownVillage NVARCHAR(150) NULL,
    MailingAddress NVARCHAR(500) NULL,
    PermanentAddress NVARCHAR(500) NULL,
    SSCBoard NVARCHAR(150) NULL,
    SSCRollNo VARCHAR(50) NULL,
    SSCYear INT NULL,
    SSCMarks DECIMAL(18,2) NULL,
    SSCPercentage DECIMAL(5,2) NULL,
    SSCInstitute NVARCHAR(250) NULL,
    HSSCBoard NVARCHAR(150) NULL,
    HSSCRollNo VARCHAR(50) NULL,
    HSSCYear INT NULL,
    HSSCMarks DECIMAL(18,2) NULL,
    HSSCPercentage DECIMAL(5,2) NULL,
    HSSCInstitute NVARCHAR(250) NULL,
    FingerprintTemplate VARBINARY(400) NULL, 
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL
);

CREATE TABLE Scholarships (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(255) NOT NULL,            
    Description NVARCHAR(MAX) NULL,
    Eligibility NVARCHAR(MAX) NULL,
    Amount DECIMAL(18,2) NOT NULL,           
    Deadline DATETIME NULL,
    IsActive BIT NOT NULL DEFAULT 1,         
    RequiredDocuments NVARCHAR(MAX) NULL,
    MinimumCGPA DECIMAL(3,2) NULL,           
    MaxFamilyIncome DECIMAL(18,2) NULL,
    DegreeProgram NVARCHAR(150) NULL,        
    SemesterYear VARCHAR(50) NULL,           
    NeedBased BIT NOT NULL DEFAULT 0,        
    CreatedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE Applications (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ScholarshipId INT NOT NULL,               
    UserEmail VARCHAR(255) NOT NULL,          
    Status NVARCHAR(50) NOT NULL DEFAULT 'Pending', 
    AppliedDate DATETIME NOT NULL DEFAULT GETDATE(),
    ReviewDate DATETIME NULL,
    Comments NVARCHAR(MAX) NULL              
);



-- Foreign Keys
ALTER TABLE Students
ADD CONSTRAINT FK_Students_Users FOREIGN KEY (UserEmail) 
    REFERENCES Users(Email) ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE Applications
ADD CONSTRAINT FK_Applications_Scholarships FOREIGN KEY (ScholarshipId) 
    REFERENCES Scholarships(Id) ON DELETE CASCADE;

ALTER TABLE Applications
ADD CONSTRAINT FK_Applications_Users FOREIGN KEY (UserEmail) 
    REFERENCES Users(Email);

-- Performance Indexes
CREATE NONCLUSTERED INDEX IX_Students_UserEmail ON Students(UserEmail);
CREATE NONCLUSTERED INDEX IX_Students_CNIC ON Students(CNIC) WHERE CNIC IS NOT NULL;

CREATE NONCLUSTERED INDEX IX_Scholarships_Active_Deadline 
ON Scholarships(IsActive, Deadline) 
INCLUDE (MinimumCGPA, MaxFamilyIncome, DegreeProgram);

-- Prevent double applications to the same scholarship
CREATE UNIQUE NONCLUSTERED INDEX IX_Applications_Student_Scholarship 
ON Applications(UserEmail, ScholarshipId);

GO


CREATE PROCEDURE sp_RegisterUser
    @Email VARCHAR(255),
    @Password VARCHAR(255),
    @Role VARCHAR(50) = 'Student',
    @FullName NVARCHAR(150) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    IF EXISTS (SELECT 1 FROM Users WHERE Email = @Email)
    BEGIN
        THROW 50001, 'Email is already registered.', 1;
    END

    INSERT INTO Users (Email, Password, Role, FullName)
    VALUES (@Email, @Password, @Role, @FullName);
    
    SELECT SCOPE_IDENTITY() AS NewUserId;
END;
GO



CREATE PROCEDURE sp_UpsertStudentProfile
    @UserEmail VARCHAR(255),
    @FullName NVARCHAR(150),
    @FatherName NVARCHAR(150) = NULL,
    @CNIC VARCHAR(20) = NULL,
    @MobileNumber VARCHAR(20) = NULL,
    @Gender VARCHAR(20) = NULL,
    @Religion NVARCHAR(50) = NULL,
    @FamilyIncome DECIMAL(18,2) = NULL,
    @SemesterYear VARCHAR(50) = NULL,
    @RollNumber VARCHAR(50) = NULL,
    @Department NVARCHAR(150) = NULL,
    @DegreeProgram NVARCHAR(150) = NULL,
    @UniversityName NVARCHAR(250) = NULL,
    @RegistrationNumber VARCHAR(100) = NULL,
    @CGPA DECIMAL(3,2) = NULL,
    @DateOfBirth DATETIME = NULL,
    @DomicileDistrict NVARCHAR(100) = NULL,
    @Province NVARCHAR(100) = NULL,
    @MailingAddress NVARCHAR(500) = NULL,
    @PermanentAddress NVARCHAR(500) = NULL,
    @FingerprintTemplate VARBINARY(400) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM Students WHERE UserEmail = @UserEmail)
    BEGIN
        UPDATE Students
        SET FullName = @FullName, FatherName = @FatherName, CNIC = @CNIC, MobileNumber = @MobileNumber,
            Gender = @Gender, Religion = @Religion, FamilyIncome = @FamilyIncome, SemesterYear = @SemesterYear,
            RollNumber = @RollNumber, Department = @Department, DegreeProgram = @DegreeProgram,
            UniversityName = @UniversityName, RegistrationNumber = @RegistrationNumber, CGPA = @CGPA,
            DateOfBirth = @DateOfBirth, DomicileDistrict = @DomicileDistrict, Province = @Province,
            MailingAddress = @MailingAddress, PermanentAddress = @PermanentAddress,
            FingerprintTemplate = COALESCE(@FingerprintTemplate, FingerprintTemplate), UpdatedAt = GETDATE()
        WHERE UserEmail = @UserEmail;
    END
    ELSE
    BEGIN
        INSERT INTO Students (UserEmail, FullName, FatherName, CNIC, MobileNumber, Gender, Religion, 
                              FamilyIncome, SemesterYear, RollNumber, Department, DegreeProgram, 
                              UniversityName, RegistrationNumber, CGPA, DateOfBirth, DomicileDistrict, 
                              Province, MailingAddress, PermanentAddress, FingerprintTemplate, DateOfAdmission)
        VALUES (@UserEmail, @FullName, @FatherName, @CNIC, @MobileNumber, @Gender, @Religion, 
                @FamilyIncome, @SemesterYear, @RollNumber, @Department, @DegreeProgram, 
                @UniversityName, @RegistrationNumber, @CGPA, @DateOfBirth, @DomicileDistrict, 
                @Province, @MailingAddress, @PermanentAddress, @FingerprintTemplate, GETDATE());
    END
END;
GO

CREATE PROCEDURE sp_GetStudentProfile
    @UserEmail VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM Students WHERE UserEmail = @UserEmail;
END;
GO



CREATE PROCEDURE sp_CreateScholarship
    @Title NVARCHAR(255),
    @Amount DECIMAL(18,2),
    @Description NVARCHAR(MAX) = NULL,
    @Eligibility NVARCHAR(MAX) = NULL,
    @Deadline DATETIME = NULL,
    @RequiredDocuments NVARCHAR(MAX) = NULL,
    @MinimumCGPA DECIMAL(3,2) = NULL,
    @MaxFamilyIncome DECIMAL(18,2) = NULL,
    @DegreeProgram NVARCHAR(150) = NULL,
    @SemesterYear VARCHAR(50) = NULL,
    @NeedBased BIT = 0
AS
BEGIN
    SET NOCOUNT ON;
    
    INSERT INTO Scholarships (Title, Amount, Description, Eligibility, Deadline, RequiredDocuments, 
                              MinimumCGPA, MaxFamilyIncome, DegreeProgram, SemesterYear, NeedBased)
    VALUES (@Title, @Amount, @Description, @Eligibility, @Deadline, @RequiredDocuments, 
            @MinimumCGPA, @MaxFamilyIncome, @DegreeProgram, @SemesterYear, @NeedBased);
            
    SELECT SCOPE_IDENTITY() AS NewScholarshipId;
END;
GO

CREATE PROCEDURE sp_GetEligibleScholarships
    @UserEmail VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @CGPA DECIMAL(3,2);
    DECLARE @Income DECIMAL(18,2);
    DECLARE @Prog NVARCHAR(150);

    SELECT @CGPA = CGPA, @Income = FamilyIncome, @Prog = DegreeProgram 
    FROM Students WHERE UserEmail = @UserEmail;

    SELECT Id, Title, Description, Amount, Deadline, NeedBased
    FROM Scholarships
    WHERE IsActive = 1
      AND (Deadline IS NULL OR Deadline >= GETDATE())
      AND (MinimumCGPA IS NULL OR MinimumCGPA <= @CGPA)
      AND (MaxFamilyIncome IS NULL OR MaxFamilyIncome >= @Income)
      AND (DegreeProgram IS NULL OR DegreeProgram = @Prog)
      AND Id NOT IN (SELECT ScholarshipId FROM Applications WHERE UserEmail = @UserEmail);
END;
GO


CREATE PROCEDURE sp_SubmitApplication
    @ScholarshipId INT,
    @UserEmail VARCHAR(255),
    @StatusMessage NVARCHAR(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @StudentCGPA DECIMAL(3,2);
    DECLARE @StudentIncome DECIMAL(18,2);
    DECLARE @MinCGPA DECIMAL(3,2);
    DECLARE @MaxIncome DECIMAL(18,2);
    DECLARE @IsActive BIT;
    DECLARE @Deadline DATETIME;

    SELECT @StudentCGPA = CGPA, @StudentIncome = FamilyIncome FROM Students WHERE UserEmail = @UserEmail;
    SELECT @MinCGPA = MinimumCGPA, @MaxIncome = MaxFamilyIncome, @IsActive = IsActive, @Deadline = Deadline FROM Scholarships WHERE Id = @ScholarshipId;

    IF @IsActive = 0 OR (@Deadline IS NOT NULL AND @Deadline < GETDATE())
    BEGIN
        SET @StatusMessage = 'Submission Failed: This scholarship is inactive or the deadline has passed.';
        RETURN;
    END

    IF @StudentCGPA < COALESCE(@MinCGPA, 0.0)
    BEGIN
        SET @StatusMessage = 'Submission Failed: Your CGPA does not meet the minimum requirement.';
        RETURN;
    END

    IF @StudentIncome > COALESCE(@MaxIncome, 99999999.99)
    BEGIN
        SET @StatusMessage = 'Submission Failed: Family income exceeds the maximum limit for this award.';
        RETURN;
    END

    BEGIN TRY
        INSERT INTO Applications (ScholarshipId, UserEmail, Status, AppliedDate)
        VALUES (@ScholarshipId, @UserEmail, 'Pending', GETDATE());
        SET @StatusMessage = 'Success: Application submitted successfully.';
    END TRY
    BEGIN CATCH
        IF ERROR_NUMBER() = 2601 
            SET @StatusMessage = 'Submission Failed: You have already applied for this scholarship.';
        ELSE
            SET @StatusMessage = 'Error: ' + ERROR_MESSAGE();
    END CATCH
END;
GO

CREATE PROCEDURE sp_UpdateApplicationStatus
    @ApplicationId INT,
    @Status NVARCHAR(50),  -- e.g., 'Approved', 'Rejected', 'Under Review'
    @Comments NVARCHAR(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    UPDATE Applications
    SET Status = @Status,
        Comments = @Comments,
        ReviewDate = GETDATE()
    WHERE Id = @ApplicationId;
END;
GO

CREATE PROCEDURE sp_GetStudentApplications
    @UserEmail VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT a.Id AS ApplicationId, s.Title AS ScholarshipTitle, s.Amount, 
           a.Status, a.AppliedDate, a.ReviewDate, a.Comments
    FROM Applications a
    INNER JOIN Scholarships s ON a.ScholarshipId = s.Id
    WHERE a.UserEmail = @UserEmail
    ORDER BY a.AppliedDate DESC;
END;
GO

INSERT INTO Scholarships 
    (Title, Description, Eligibility, Amount, Deadline, IsActive, RequiredDocuments, MinimumCGPA, MaxFamilyIncome, DegreeProgram, SemesterYear, NeedBased)
VALUES
    ('Merit Scholarship',
     'For students with strong academic performance.',
     'CGPA must be at least 3.50.',
     50000,
     DATEADD(DAY, 60, GETDATE()),
     1,
     'CNIC Front,CNIC Back,SSC Certificate,HSSC Certificate,Student Image',
     3.50,
     NULL,
     NULL,
     NULL,
     0),

    ('Need-Based Scholarship',
     'For students who need financial support.',
     'Family income must be below 50000.',
     60000,
     DATEADD(DAY, 60, GETDATE()),
     1,
     'CNIC Front,CNIC Back,Domicile,Affidavit,Student Image',
     NULL,
     50000,
     NULL,
     NULL,
     1),

    ('Tech Scholarship',
     'For computer science and technology students.',
     'Computer Science or technology degree students are preferred.',
     40000,
     DATEADD(DAY, 60, GETDATE()),
     1,
     'CNIC Front,CNIC Back,HSSC Certificate,Student Image',
     3.00,
     NULL,
     'Computer Science',
     NULL,
     0);

     SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'Students' AND COLUMN_NAME = 'FingerprintTemplate';



CREATE TABLE Documents (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UserEmail VARCHAR(255) NOT NULL,
    DocumentType NVARCHAR(120) NOT NULL,
    FileName NVARCHAR(260) NOT NULL,
    FilePath NVARCHAR(1000) NOT NULL,
    UploadDate DATETIME2 NOT NULL DEFAULT SYSDATETIME()
);

CREATE TABLE SavedScholarships (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UserEmail VARCHAR(255) NOT NULL,
    ScholarshipId INT NOT NULL,
    SavedDate DATETIME2 NOT NULL DEFAULT SYSDATETIME()
); 

CREATE TABLE Notifications (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UserEmail VARCHAR(255) NOT NULL,
    Message NVARCHAR(500) NOT NULL,
    IsRead BIT NOT NULL DEFAULT 0,
    CreatedDate DATETIME2 NOT NULL DEFAULT SYSDATETIME()
);

IF NOT EXISTS (SELECT 1 FROM Users WHERE Email = 'admin@sms.local')
BEGIN
    INSERT INTO Users (Email, Password, Role, IsVerified, FullName)
    VALUES ('admin@sms.local', 'admin123', 'Admin', 1, 'System Administrator');
END;
GO
SELECT * FROM Documents;
SELECT * FROM SavedScholarships;
SELECT * FROM Notifications;

ALTER TABLE Students
ALTER COLUMN FingerprintTemplate VARBINARY(MAX);

ALTER TABLE Students
ADD DisabilityDetail NVARCHAR(300) NULL;

ALTER PROCEDURE sp_GetStudentApplications
    @UserEmail VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT a.Id,
           a.ScholarshipId,
           s.Title AS ScholarshipTitle,
           s.Amount, 
           a.Status,
           a.AppliedDate,
           a.ReviewDate,
           a.Comments
    FROM Applications a
    INNER JOIN Scholarships s ON a.ScholarshipId = s.Id
    WHERE a.UserEmail = @UserEmail
    ORDER BY a.AppliedDate DESC;
END;
GO

ALTER TABLE Applications
ADD StudentComments NVARCHAR(MAX) NULL;

ALTER PROCEDURE sp_UpdateApplicationStatus
    @ApplicationId INT,
    @Status NVARCHAR(50),
    @Comments NVARCHAR(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Applications
    SET Status = @Status,
        Comments = @Comments,      -- admin writes here
        ReviewDate = GETDATE()
    WHERE Id = @ApplicationId;
END;
GO

ALTER PROCEDURE sp_GetStudentApplications
    @UserEmail VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT a.Id,
           a.ScholarshipId,
           s.Title AS ScholarshipTitle,
           s.Amount, 
           a.Status,
           a.AppliedDate,
           a.ReviewDate,
           a.Comments        AS AdminComments,
           a.StudentComments AS YourComments
    FROM Applications a
    INNER JOIN Scholarships s ON a.ScholarshipId = s.Id
    WHERE a.UserEmail = @UserEmail
    ORDER BY a.AppliedDate DESC;
END;
GO

ALTER PROCEDURE sp_GetStudentApplications
    @UserEmail VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT a.Id,
           a.ScholarshipId,
           s.Title        AS ScholarshipTitle,
           s.Amount,
           a.Status,
           a.AppliedDate,
           a.ReviewDate,
           a.Comments        AS AdminComments,
           a.StudentComments AS YourComments
    FROM Applications a
    INNER JOIN Scholarships s ON a.ScholarshipId = s.Id
    WHERE a.UserEmail = @UserEmail
    ORDER BY a.AppliedDate DESC;
END;
GO

ALTER TABLE Applications
ADD StudentComments NVARCHAR(MAX) NULL;

DROP INDEX IX_Applications_Student_Scholarship ON Applications;
CREATE NONCLUSTERED INDEX IX_Applications_Student_Scholarship
ON Applications(UserEmail, ScholarshipId);

ALTER PROCEDURE sp_SubmitApplication
    @ScholarshipId INT,
    @UserEmail VARCHAR(255),
    @StudentComments NVARCHAR(MAX) = NULL,
    @StatusMessage NVARCHAR(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @StudentCGPA   DECIMAL(3,2);
    DECLARE @StudentIncome DECIMAL(18,2);
    DECLARE @MinCGPA       DECIMAL(3,2);
    DECLARE @MaxIncome     DECIMAL(18,2);
    DECLARE @IsActive      BIT;
    DECLARE @Deadline      DATETIME;

    SELECT @StudentCGPA = CGPA, @StudentIncome = FamilyIncome
    FROM Students WHERE UserEmail = @UserEmail;

    SELECT @MinCGPA = MinimumCGPA, @MaxIncome = MaxFamilyIncome,
           @IsActive = IsActive, @Deadline = Deadline
    FROM Scholarships WHERE Id = @ScholarshipId;

    IF @IsActive = 0 OR (@Deadline IS NOT NULL AND @Deadline < GETDATE())
    BEGIN
        SET @StatusMessage = 'Submission Failed: This scholarship is inactive or the deadline has passed.';
        RETURN;
    END

    IF @StudentCGPA < COALESCE(@MinCGPA, 0.0)
    BEGIN
        SET @StatusMessage = 'Submission Failed: Your CGPA does not meet the minimum requirement.';
        RETURN;
    END

    IF @StudentIncome > COALESCE(@MaxIncome, 99999999.99)
    BEGIN
        SET @StatusMessage = 'Submission Failed: Family income exceeds the maximum limit.';
        RETURN;
    END

    -- Only block if a Pending or Approved row exists — Rejected/Withdrawn can reapply
    IF EXISTS (
        SELECT 1 FROM Applications
        WHERE UserEmail    = @UserEmail
          AND ScholarshipId = @ScholarshipId
          AND Status IN ('Pending', 'Approved')
    )
    BEGIN
        SET @StatusMessage = 'Submission Failed: You already have an active application for this scholarship.';
        RETURN;
    END

    INSERT INTO Applications (ScholarshipId, UserEmail, Status, AppliedDate, StudentComments)
    VALUES (@ScholarshipId, @UserEmail, 'Pending', GETDATE(), @StudentComments);

    SET @StatusMessage = 'Success: Application submitted successfully.';
END;
GO

ALTER PROCEDURE sp_GetStudentApplications
    @UserEmail VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT a.Id,
           a.ScholarshipId,
           s.Title           AS ScholarshipTitle,
           s.Amount,
           a.Status,
           a.AppliedDate,
           a.ReviewDate,
           a.Comments        AS AdminComments,
           a.StudentComments AS YourComments,
           s.NeedBased                          
    FROM Applications a
    INNER JOIN Scholarships s ON a.ScholarshipId = s.Id
    WHERE a.UserEmail = @UserEmail
    ORDER BY a.AppliedDate DESC;
END;
GO

IF NOT EXISTS (
    SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS
    WHERE TABLE_NAME = 'Applications' AND COLUMN_NAME = 'FingerprintVerified'
)
BEGIN
    ALTER TABLE Applications
        ADD FingerprintVerified     BIT       NOT NULL DEFAULT 0,
            FingerprintVerifiedAt   DATETIME2 NULL;
    PRINT 'Added FingerprintVerified columns to Applications.';
END
ELSE
BEGIN
    PRINT 'FingerprintVerified columns already exist — skipped.';
END
GO

-- Step 2: Create fingerprint verification tokens table
IF NOT EXISTS (
    SELECT 1 FROM INFORMATION_SCHEMA.TABLES
    WHERE TABLE_NAME = 'FingerprintVerificationTokens'
)
BEGIN
    CREATE TABLE FingerprintVerificationTokens (
        Id               INT           IDENTITY(1,1) PRIMARY KEY,
        Token            NVARCHAR(128) NOT NULL,
        ApplicationId    INT           NOT NULL,
        UserEmail        NVARCHAR(255) NOT NULL,
        StudentName      NVARCHAR(255) NOT NULL,
        ScholarshipTitle NVARCHAR(255) NOT NULL,
        CreatedAt        DATETIME2     NOT NULL DEFAULT SYSDATETIME(),
        ExpiresAt        DATETIME2     NOT NULL,            -- 48 hours from creation
        IsUsed           BIT           NOT NULL DEFAULT 0,
        VerifiedAt       DATETIME2     NULL,

        CONSTRAINT UQ_FingerprintToken        UNIQUE (Token),
        CONSTRAINT FK_FingerprintTokens_Apps  FOREIGN KEY (ApplicationId)
            REFERENCES Applications(Id) ON DELETE CASCADE
    );

    CREATE NONCLUSTERED INDEX IX_FingerprintTokens_Token
        ON FingerprintVerificationTokens (Token);

    CREATE NONCLUSTERED INDEX IX_FingerprintTokens_Email
        ON FingerprintVerificationTokens (UserEmail);

    PRINT 'Created FingerprintVerificationTokens table.';
END
ELSE
BEGIN
    PRINT 'FingerprintVerificationTokens table already exists — skipped.';
END
GO

-- Step 3: Verification view (optional helper for admin queries)
CREATE OR ALTER VIEW vw_FingerprintStatus AS
    SELECT
        a.Id                    AS ApplicationId,
        a.UserEmail,
        s.Title                 AS ScholarshipTitle,
        a.Status                AS ApplicationStatus,
        a.FingerprintVerified,
        a.FingerprintVerifiedAt,
        t.Token,
        t.ExpiresAt             AS TokenExpiresAt,
        t.IsUsed                AS TokenUsed,
        t.CreatedAt             AS TokenCreatedAt
    FROM Applications a
    JOIN Scholarships s ON a.ScholarshipId = s.Id
    LEFT JOIN FingerprintVerificationTokens t ON t.ApplicationId = a.Id
    WHERE a.Status = 'Approved';
GO

PRINT 'Migration complete.';
SELECT COLUMN_NAME 
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'Applications' AND COLUMN_NAME = 'FingerprintVerified';

IF NOT EXISTS (
    SELECT 1 FROM INFORMATION_SCHEMA.TABLES 
    WHERE TABLE_NAME = 'FingerprintVerificationTokens'
)
BEGIN
    CREATE TABLE FingerprintVerificationTokens (
        Id                INT IDENTITY PRIMARY KEY,
        Token             NVARCHAR(64)  NOT NULL UNIQUE,
        ApplicationId     INT           NOT NULL,
        UserEmail         NVARCHAR(255) NOT NULL,
        StudentName       NVARCHAR(255) NOT NULL,
        ScholarshipTitle  NVARCHAR(255) NOT NULL,
        CreatedAt         DATETIME2     NOT NULL DEFAULT SYSDATETIME(),
        ExpiresAt         DATETIME2     NOT NULL,
        IsUsed            BIT           NOT NULL DEFAULT 0
    );
END

IF NOT EXISTS (
    SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS 
    WHERE TABLE_NAME = 'Applications' AND COLUMN_NAME = 'FingerprintVerified'
)
BEGIN
    ALTER TABLE Applications
    ADD FingerprintVerified BIT NOT NULL DEFAULT 0;
END

SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Applications' AND COLUMN_NAME = 'StudentComments';

SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'Applications'
ORDER BY ORDINAL_POSITION;

SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_NAME = 'FingerprintVerificationTokens';

ALTER TABLE Applications
ADD FingerprintVerified   BIT       NOT NULL DEFAULT 0,
    FingerprintVerifiedAt DATETIME2 NULL;

    CREATE TABLE IdentityVerificationTokens (
    Id          INT           IDENTITY(1,1) PRIMARY KEY,
    Token       NVARCHAR(64)  NOT NULL UNIQUE,
    UserEmail   NVARCHAR(255) NOT NULL,
    StudentName NVARCHAR(255) NOT NULL,
    CreatedAt   DATETIME2     NOT NULL DEFAULT SYSDATETIME(),
    ExpiresAt   DATETIME2     NOT NULL,
    IsUsed      BIT           NOT NULL DEFAULT 0,
    VerifiedAt  DATETIME2     NULL
);
CREATE NONCLUSTERED INDEX IX_IdentityTokens_Token ON IdentityVerificationTokens(Token);
CREATE NONCLUSTERED INDEX IX_IdentityTokens_Email ON IdentityVerificationTokens(UserEmail);

ALTER TABLE IdentityVerificationTokens
ALTER COLUMN Token NVARCHAR(128) NOT NULL;

UPDATE Scholarships
SET RequiredDocuments = 'CNIC Front,CNIC Back,Domicile,Affidavit,Student Image,Income/Salary Slip'
WHERE NeedBased = 1;

UPDATE Scholarships
SET RequiredDocuments = REPLACE(RequiredDocuments, 'Income/Salary Slip', 'Income/Salary Proof')
WHERE RequiredDocuments LIKE '%Income/Salary Slip%';

UPDATE Documents
SET DocumentType = 'Income/Salary Proof'
WHERE DocumentType = 'Income/Salary Slip';