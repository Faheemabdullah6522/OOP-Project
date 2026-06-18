# QuasarEdu 🔹 Scholarship Management System

![C#](https://img.shields.io/badge/C%23-10.0-blue)
![.NET](https://img.shields.io/badge/.NET-10.0-purple)
![SQL Server](https://img.shields.io/badge/SQL%20Server-2022-red)

A Windows Forms-based scholarship management system with fingerprint verification, AI-powered document extraction, and role-based dashboards for students and admins.

## Features 🔹

| Feature                  | Description                                               |
| ------------------------ | --------------------------------------------------------- |
| User Authentication      | Register, login, OTP email verification, forgot password  |
| Role-Based Dashboards    | Separate views for Students and Admins                    |
| Scholarship Management   | Create, edit, activate/deactivate scholarships            |
| Student Profiles         | Manage personal/academic info, upload documents           |
| Apply for Scholarships   | Submit applications with required documents               |
| AI Document Extraction   | Google Gemini extracts structured data from uploaded docs |
| Application Tracking     | Track status (Pending/Approved/Rejected) with comments    |
| PDF Receipt Generation   | Auto-generated application receipts via QuestPDF          |
| QR Codes                 | QR generation for applications and documents              |
| Dashboard Analytics      | Guna Charts showing scholarships, applications, stats     |
| Smart Chatbot            | Gemini-powered assistant for scholarship queries          |
| Real-Time Notifications  | Toast notifications for system events                     |

## Screenshots 🖼

<img width="702" alt="Register" src="https://raw.githubusercontent.com/Faheemabdullah6522/OOP-Project/main/Window%20Forms/screenshots/Screenshot%202026-06-15%20111743.png">

<img width="702" alt="Student Dashboard" src="https://raw.githubusercontent.com/Faheemabdullah6522/OOP-Project/main/Window%20Forms/screenshots/Screenshot%202026-06-15%20111754.png">

<img width="702" alt="Apply Form" src="https://raw.githubusercontent.com/Faheemabdullah6522/OOP-Project/main/Window%20Forms/screenshots/Screenshot%202026-06-15%20111829.png">

<img width="702" alt="Admin Dashboard" src="https://raw.githubusercontent.com/Faheemabdullah6522/OOP-Project/main/Window%20Forms/screenshots/Screenshot%202026-06-15%20111851.png">

## Tech Stack ⚙

| Layer     | Technology                                         |
| --------- | -------------------------------------------------- |
| Frontend  | Windows Forms, Guna.UI2, Guna.Charts               |
| Backend   | C# .NET 10.0                                       |
| Database  | SQL Server (stored procedures)                     |
| AI        | Google Gemini 2.5 Flash Lite (document extraction) |
| Biometric | SecuGen FDx SDK Pro (fingerprint)                  |
| PDF       | QuestPDF, PDFtoImage                               |
| Security  | BCrypt, login attempt throttling, OTP verification |

## Build Instructions 🚀

### Prerequisites

- Visual Studio 2022+ with .NET 10.0 SDK
- SQL Server 2022 (LocalDB or Express)

### Clone & Run

```bash
git clone https://github.com/faheemabdullah6522/QuasarEdu.git
cd QuasarEdu/"Window Forms"

# Restore NuGet packages
dotnet restore

# Create the database
# Run CreateScholarshipDatabase.sql against your SQL Server instance

# Update the connection string in Database.cs if needed

# Build & run
dotnet run
```

## Database 📊

The system uses SQL Server with all database operations implemented as stored procedures.

- `CreateScholarshipDatabase.sql` — original schema with tables, indexes, seed data
- `StoredProcedures.sql` — complete set of 40+ stored procedures

## License 📄

This project is developed as an OOP course project.
