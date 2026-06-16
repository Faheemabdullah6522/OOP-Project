-- ============================================================================
-- STORED PROCEDURES FOR SCHOLARSHIP MANAGEMENT SYSTEM
-- Run this ONCE on your database to replace all hardcoded SQL queries.
-- ============================================================================

-- ============================================================================
-- USERS & AUTH
-- ============================================================================

CREATE OR ALTER PROCEDURE sp_GetUserByEmail
    @Email VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT TOP 1 Id, Email, Password, Role, IsVerified, FullName, Phone, Address, DateOfBirth, CreatedAt
    FROM Users WHERE Email = @Email;
END;
GO

CREATE OR ALTER PROCEDURE sp_GetUserVerificationStatus
    @Email VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT TOP 1 IsVerified FROM Users WHERE Email = @Email;
END;
GO

CREATE OR ALTER PROCEDURE sp_CheckUserExists
    @Email VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT TOP 1 Id FROM Users WHERE Email = @Email;
END;
GO

CREATE OR ALTER PROCEDURE sp_GetUserLoginInfo
    @Email VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT TOP 1 Id, Email, Role FROM Users WHERE Email = @Email;
END;
GO

CREATE OR ALTER PROCEDURE sp_RegisterUser
    @Email VARCHAR(255),
    @Password VARCHAR(255),
    @Role VARCHAR(50) = 'Student'
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM Users WHERE Email = @Email)
        THROW 50001, 'Email is already registered.', 1;
    INSERT INTO Users (Email, Password, Role, IsVerified)
    VALUES (@Email, @Password, @Role, 0);
    SELECT SCOPE_IDENTITY() AS NewUserId;
END;
GO

CREATE OR ALTER PROCEDURE sp_UpsertUserRegistration
    @Email VARCHAR(255),
    @Password VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM Users WHERE Email = @Email)
        UPDATE Users SET Password = @Password, Role = 'Student', IsVerified = 0 WHERE Email = @Email;
    ELSE
        INSERT INTO Users (Email, Password, Role, IsVerified) VALUES (@Email, @Password, 'Student', 0);
END;
GO

CREATE OR ALTER PROCEDURE sp_VerifyUserEmail
    @Email VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Users SET IsVerified = 1 WHERE Email = @Email;
END;
GO

CREATE OR ALTER PROCEDURE sp_CreateStudentFromUser
    @Email VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS (SELECT 1 FROM Students WHERE UserEmail = @Email)
        INSERT INTO Students (UserEmail, UserId, Email)
        SELECT Email, Id, Email FROM Users WHERE Email = @Email;
END;
GO

CREATE OR ALTER PROCEDURE sp_UpdateUserProfile
    @Email VARCHAR(255),
    @FullName NVARCHAR(150) = NULL,
    @Phone VARCHAR(20) = NULL,
    @Address NVARCHAR(500) = NULL,
    @DateOfBirth DATETIME = NULL
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Users
    SET FullName = COALESCE(@FullName, FullName),
        Phone = COALESCE(@Phone, Phone),
        Address = COALESCE(@Address, Address),
        DateOfBirth = COALESCE(@DateOfBirth, DateOfBirth)
    WHERE Email = @Email;
END;
GO

CREATE OR ALTER PROCEDURE sp_UpdatePassword
    @Email VARCHAR(255),
    @Password VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Users SET Password = @Password WHERE Email = @Email;
END;
GO

-- ============================================================================
-- STUDENTS
-- ============================================================================

CREATE OR ALTER PROCEDURE sp_GetStudentProfile
    @Email VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT TOP 1 * FROM Students WHERE UserEmail = @Email;
END;
GO

CREATE OR ALTER PROCEDURE sp_GetFingerprintTemplate
    @Email VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT FingerprintTemplate FROM Students WHERE UserEmail = @Email;
END;
GO

CREATE OR ALTER PROCEDURE sp_UpdateFingerprintTemplate
    @Email VARCHAR(255),
    @Template VARBINARY(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Students SET FingerprintTemplate = @Template WHERE UserEmail = @Email;
END;
GO

CREATE OR ALTER PROCEDURE sp_UpsertStudentProfile
    @UserEmail VARCHAR(255),
    @FullName NVARCHAR(150) = NULL,
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
    @District NVARCHAR(100) = NULL,
    @TownVillage NVARCHAR(150) = NULL,
    @MailingAddress NVARCHAR(500) = NULL,
    @PermanentAddress NVARCHAR(500) = NULL,
    @FingerprintTemplate VARBINARY(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM Students WHERE UserEmail = @UserEmail)
        UPDATE Students
        SET FullName = @FullName, FatherName = @FatherName, CNIC = @CNIC,
            MobileNumber = @MobileNumber, Gender = @Gender, Religion = @Religion,
            FamilyIncome = @FamilyIncome, SemesterYear = @SemesterYear,
            RollNumber = @RollNumber, Department = @Department,
            DegreeProgram = @DegreeProgram, UniversityName = @UniversityName,
            RegistrationNumber = @RegistrationNumber, CGPA = @CGPA,
            DateOfBirth = @DateOfBirth, DomicileDistrict = @DomicileDistrict,
            Province = @Province, District = @District,
            TownVillage = @TownVillage, MailingAddress = @MailingAddress,
            PermanentAddress = @PermanentAddress,
            FingerprintTemplate = COALESCE(@FingerprintTemplate, FingerprintTemplate),
            UpdatedAt = GETDATE()
        WHERE UserEmail = @UserEmail;
    ELSE
        INSERT INTO Students (UserEmail, FullName, FatherName, CNIC, MobileNumber,
            Gender, Religion, FamilyIncome, SemesterYear, RollNumber, Department,
            DegreeProgram, UniversityName, RegistrationNumber, CGPA, DateOfBirth,
            DomicileDistrict, Province, District, TownVillage, MailingAddress,
            PermanentAddress, FingerprintTemplate, DateOfAdmission)
        VALUES (@UserEmail, @FullName, @FatherName, @CNIC, @MobileNumber,
            @Gender, @Religion, @FamilyIncome, @SemesterYear, @RollNumber,
            @Department, @DegreeProgram, @UniversityName, @RegistrationNumber,
            @CGPA, @DateOfBirth, @DomicileDistrict, @Province, @District,
            @TownVillage, @MailingAddress, @PermanentAddress,
            @FingerprintTemplate, GETDATE());
END;
GO

CREATE OR ALTER PROCEDURE sp_UpdateDisabilityStatus
    @Email VARCHAR(255),
    @Value NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Students SET DisabilityStatus = @Value WHERE UserEmail = @Email;
END;
GO

-- ============================================================================
-- SCHOLARSHIPS
-- ============================================================================

CREATE OR ALTER PROCEDURE sp_GetAllActiveScholarships
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Id, Title, Description, Eligibility, Amount, Deadline, IsActive,
           RequiredDocuments, MinimumCGPA, MaxFamilyIncome, DegreeProgram,
           SemesterYear, NeedBased, CreatedAt
    FROM Scholarships WHERE IsActive = 1
    ORDER BY Deadline, Title;
END;
GO

CREATE OR ALTER PROCEDURE sp_GetScholarshipById
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Title, Description, Eligibility, Amount, Deadline, IsActive,
           RequiredDocuments, MinimumCGPA, MaxFamilyIncome, DegreeProgram,
           SemesterYear, NeedBased
    FROM Scholarships WHERE Id = @Id;
END;
GO

CREATE OR ALTER PROCEDURE sp_GetRequiredDocuments
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT RequiredDocuments FROM Scholarships WHERE Id = @Id;
END;
GO

CREATE OR ALTER PROCEDURE sp_GetDashboardStats
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        (SELECT COUNT(*) FROM Scholarships) AS TotalScholarships,
        (SELECT COUNT(*) FROM Applications) AS TotalApplications,
        (SELECT COUNT(*) FROM Applications WHERE Status = 'Pending') AS PendingReviews,
        (SELECT COUNT(*) FROM Applications WHERE Status = 'Approved') AS ApprovedCount,
        (SELECT COUNT(*) FROM Applications WHERE Status IN ('Approved', 'Rejected')) AS ReviewedCount;
END;
GO

CREATE OR ALTER PROCEDURE sp_GetApplicationStatusCounts
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Status, COUNT(*) AS Count FROM Applications GROUP BY Status ORDER BY Status;
END;
GO

CREATE OR ALTER PROCEDURE sp_DeleteScholarship
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Scholarships WHERE Id = @Id;
END;
GO

-- ============================================================================
-- APPLICATIONS
-- ============================================================================

CREATE OR ALTER PROCEDURE sp_CheckExistingApplication
    @ScholarshipId INT,
    @UserEmail VARCHAR(255),
    @StatusFilter NVARCHAR(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    IF @StatusFilter IS NULL
        SELECT COUNT(*) AS Count FROM Applications
        WHERE ScholarshipId = @ScholarshipId AND UserEmail = @UserEmail;
    ELSE
        SELECT COUNT(*) AS Count FROM Applications
        WHERE ScholarshipId = @ScholarshipId AND UserEmail = @UserEmail AND Status IN ('Pending', 'Approved');
END;
GO

CREATE OR ALTER PROCEDURE sp_CheckDraftApplication
    @ScholarshipId INT,
    @UserEmail VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(*) AS Count FROM Applications
    WHERE ScholarshipId = @ScholarshipId AND UserEmail = @UserEmail AND Status = 'Draft';
END;
GO

CREATE OR ALTER PROCEDURE sp_GetDraftApplicationId
    @ScholarshipId INT,
    @UserEmail VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Id FROM Applications
    WHERE ScholarshipId = @ScholarshipId AND UserEmail = @UserEmail AND Status = 'Draft';
END;
GO

CREATE OR ALTER PROCEDURE sp_GetApplicationComments
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Comments, StudentComments FROM Applications WHERE Id = @Id;
END;
GO

CREATE OR ALTER PROCEDURE sp_CheckApplicationStatus
    @Id INT,
    @UserEmail VARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    IF @UserEmail IS NULL
        SELECT Status FROM Applications WHERE Id = @Id;
    ELSE
        SELECT Status FROM Applications WHERE Id = @Id AND UserEmail = @UserEmail;
END;
GO

CREATE OR ALTER PROCEDURE sp_GetApprovedApplicationId
    @ScholarshipId INT,
    @UserEmail VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Id FROM Applications
    WHERE ScholarshipId = @ScholarshipId AND UserEmail = @UserEmail AND Status = 'Approved';
END;
GO

CREATE OR ALTER PROCEDURE sp_GetPendingApplicationId
    @ScholarshipId INT,
    @UserEmail VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Id FROM Applications
    WHERE ScholarshipId = @ScholarshipId AND UserEmail = @UserEmail AND Status = 'Pending';
END;
GO

CREATE OR ALTER PROCEDURE sp_GetRejectedApplicationsForResubmit
    @ScholarshipId INT,
    @UserEmail VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Id, Status FROM Applications
    WHERE ScholarshipId = @ScholarshipId AND UserEmail = @UserEmail
    AND Status IN ('Rejected', 'Withdrawn')
    ORDER BY AppliedDate DESC;
END;
GO

CREATE OR ALTER PROCEDURE sp_GetLatestApplicationId
    @ScholarshipId INT,
    @UserEmail VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT TOP 1 Id FROM Applications
    WHERE ScholarshipId = @ScholarshipId AND UserEmail = @UserEmail
    ORDER BY AppliedDate DESC;
END;
GO

CREATE OR ALTER PROCEDURE sp_SubmitApplicationWithComments
    @ScholarshipId INT,
    @UserEmail VARCHAR(255),
    @StudentComments NVARCHAR(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Applications (ScholarshipId, UserEmail, Status, AppliedDate, StudentComments)
    VALUES (@ScholarshipId, @UserEmail, 'Pending', GETDATE(), @StudentComments);
    SELECT SCOPE_IDENTITY() AS NewApplicationId;
END;
GO

CREATE OR ALTER PROCEDURE sp_SubmitDraftApplication
    @ScholarshipId INT,
    @UserEmail VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Applications (UserEmail, ScholarshipId, Status, AppliedDate)
    VALUES (@UserEmail, @ScholarshipId, 'Draft', GETDATE());
    SELECT SCOPE_IDENTITY() AS NewApplicationId;
END;
GO

CREATE OR ALTER PROCEDURE sp_UpdateApplicationStatus
    @ApplicationId INT,
    @Status NVARCHAR(50),
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

CREATE OR ALTER PROCEDURE sp_WithdrawApplication
    @Id INT,
    @UserEmail VARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    IF @UserEmail IS NULL
        UPDATE Applications SET Status = 'Withdrawn' WHERE Id = @Id AND Status = 'Pending';
    ELSE
        UPDATE Applications SET Status = 'Withdrawn' WHERE Id = @Id AND UserEmail = @UserEmail AND Status = 'Pending';
END;
GO

CREATE OR ALTER PROCEDURE sp_DeleteExpiredDrafts
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Applications
    WHERE UserEmail IN (SELECT UserEmail FROM Applications WHERE Status = 'Draft')
      AND Status = 'Draft'
      AND ScholarshipId IN (SELECT Id FROM Scholarships WHERE Deadline < CAST(GETDATE() AS DATE));
END;
GO

CREATE OR ALTER PROCEDURE sp_GetPendingApplications
AS
BEGIN
    SET NOCOUNT ON;
    SELECT a.Id, s.Title AS Scholarship, a.UserEmail AS Student,
           st.FullName, st.Department, st.DegreeProgram, st.CGPA,
           st.FamilyIncome, a.AppliedDate, a.StudentComments,
           s.NeedBased, a.FingerprintVerified AS FPVerified
    FROM Applications a
    JOIN Scholarships s ON a.ScholarshipId = s.Id
    LEFT JOIN Students st ON st.UserEmail = a.UserEmail
    WHERE a.Status = 'Pending'
    ORDER BY a.AppliedDate;
END;
GO

CREATE OR ALTER PROCEDURE sp_GetReceiptData
    @ApplicationId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        a.Id AS ApplicationId, a.Status, a.AppliedDate, a.ReviewDate, a.Comments,
        s.Title, s.Amount, s.Deadline, s.MinimumCGPA, s.MaxFamilyIncome,
        s.DegreeProgram AS ScholarshipDegreeProgram,
        s.SemesterYear AS ScholarshipSemesterYear, s.NeedBased,
        st.FullName, st.FatherName, st.CNIC, st.MobileNumber, st.UserEmail,
        st.Department, st.DegreeProgram, st.SemesterYear, st.CGPA,
        st.FamilyIncome, st.Province, st.District, st.MailingAddress,
        st.PermanentAddress, st.FingerprintTemplate, st.DisabilityStatus, st.DateOfBirth
    FROM Applications a
    JOIN Scholarships s ON s.Id = a.ScholarshipId
    LEFT JOIN Students st ON st.UserEmail = a.UserEmail
    WHERE a.Id = @ApplicationId;
END;
GO

CREATE OR ALTER PROCEDURE sp_GetVerificationDocuments
    @UserEmail VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT DocumentType, FileName, FilePath
    FROM Documents
    WHERE UserEmail = @UserEmail
      AND (DocumentType = 'Face Verification' OR DocumentType LIKE 'Identity%')
    ORDER BY UploadDate ASC;
END;
GO

-- ============================================================================
-- DOCUMENTS
-- ============================================================================

CREATE OR ALTER PROCEDURE sp_GetDocumentsByEmail
    @UserEmail VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ID, DocumentType, FileName, UploadDate, FilePath
    FROM Documents WHERE UserEmail = @UserEmail
    ORDER BY UploadDate DESC;
END;
GO

CREATE OR ALTER PROCEDURE sp_GetAllDocuments
    @UserEmail VARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    IF @UserEmail IS NULL
        SELECT d.Id, d.UserEmail AS Student, d.DocumentType, d.FileName, d.UploadDate, d.FilePath
        FROM Documents d ORDER BY d.UploadDate DESC;
    ELSE
        SELECT d.Id, d.UserEmail AS Student, d.DocumentType, d.FileName, d.UploadDate, d.FilePath
        FROM Documents d WHERE d.UserEmail = @UserEmail ORDER BY d.UploadDate DESC;
END;
GO

CREATE OR ALTER PROCEDURE sp_CountDocumentsByType
    @UserEmail VARCHAR(255),
    @DocumentType NVARCHAR(120)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(*) AS Count FROM Documents
    WHERE UserEmail = @UserEmail AND DocumentType = @DocumentType;
END;
GO

CREATE OR ALTER PROCEDURE sp_CountIdentityDocuments
    @UserEmail VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(*) AS Count FROM Documents
    WHERE UserEmail = @UserEmail
      AND (DocumentType LIKE 'Identity%' OR DocumentType = 'Face Verification');
END;
GO

CREATE OR ALTER PROCEDURE sp_GetStudentDocumentTypes
    @UserEmail VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT DocumentType FROM Documents WHERE UserEmail = @UserEmail;
END;
GO

CREATE OR ALTER PROCEDURE sp_InsertDocument
    @UserEmail VARCHAR(255),
    @DocumentType NVARCHAR(120),
    @FileName NVARCHAR(260),
    @FilePath NVARCHAR(1000)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Documents (UserEmail, DocumentType, FileName, FilePath)
    VALUES (@UserEmail, @DocumentType, @FileName, @FilePath);
    SELECT SCOPE_IDENTITY() AS NewDocumentId;
END;
GO

CREATE OR ALTER PROCEDURE sp_DeleteDocument
    @Id INT,
    @UserEmail VARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    IF @UserEmail IS NULL
        DELETE FROM Documents WHERE Id = @Id;
    ELSE
        DELETE FROM Documents WHERE Id = @Id AND UserEmail = @UserEmail;
END;
GO

CREATE OR ALTER PROCEDURE sp_DeleteIdentityDocuments
    @UserEmail VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Documents
    WHERE UserEmail = @UserEmail
      AND (DocumentType = 'Face Verification'
           OR DocumentType LIKE 'Fingerprint%'
           OR DocumentType LIKE 'Identity%');
END;
GO

-- ============================================================================
-- NOTIFICATIONS
-- ============================================================================

CREATE OR ALTER PROCEDURE sp_GetNotificationsByEmail
    @UserEmail VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Message, CreatedDate, IsRead FROM Notifications
    WHERE UserEmail = @UserEmail
    ORDER BY CreatedDate DESC;
END;
GO

CREATE OR ALTER PROCEDURE sp_MarkNotificationsRead
    @UserEmail VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Notifications SET IsRead = 1
    WHERE UserEmail = @UserEmail AND IsRead = 0;
END;
GO

CREATE OR ALTER PROCEDURE sp_InsertNotification
    @UserEmail VARCHAR(255),
    @Message NVARCHAR(500)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Notifications (UserEmail, Message) VALUES (@UserEmail, @Message);
END;
GO

-- ============================================================================
-- IDENTITY VERIFICATION TOKENS
-- ============================================================================

CREATE OR ALTER PROCEDURE sp_InsertIdentityVerificationToken
    @Token NVARCHAR(128),
    @UserEmail NVARCHAR(255),
    @StudentName NVARCHAR(255),
    @ExpiresAt DATETIME2
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM IdentityVerificationTokens WHERE UserEmail = @UserEmail AND IsUsed = 0;
    INSERT INTO IdentityVerificationTokens (Token, UserEmail, StudentName, ExpiresAt, IsUsed)
    VALUES (@Token, @UserEmail, @StudentName, @ExpiresAt, 0);
END;
GO

-- ============================================================================
-- STUDENT SEARCH
-- ============================================================================

CREATE OR ALTER PROCEDURE sp_SearchStudents
    @Department NVARCHAR(150) = NULL,
    @DegreeProgram NVARCHAR(150) = NULL,
    @SearchText NVARCHAR(150) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT UserEmail AS Email, FullName, CNIC, MobileNumber, DateOfBirth,
           Department, DegreeProgram, SemesterYear, CGPA, FamilyIncome, Province
    FROM Students WHERE 1 = 1
      AND (@Department IS NULL OR Department = @Department)
      AND (@DegreeProgram IS NULL OR DegreeProgram = @DegreeProgram)
      AND (@SearchText IS NULL OR FullName LIKE '%' + @SearchText + '%' OR CNIC LIKE '%' + @SearchText + '%')
    ORDER BY FullName;
END;
GO

PRINT 'All stored procedures created/updated successfully.';
GO
