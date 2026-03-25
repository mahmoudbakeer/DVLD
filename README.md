# Driving and Vehicle License Department (DVLD)
## System #1: Driver License Issuance and Management System

> A professional desktop application built with **C#**, **Windows Forms**, **ADO.NET**, and **SQL Server** that automates and manages all operations related to driver licensing services.

---

## Table of Contents

1. [Project Overview](#1-project-overview)
2. [System Objectives](#2-system-objectives)
3. [Technology Stack](#3-technology-stack)
4. [System Architecture](#4-system-architecture)
5. [Features and Core Services](#5-features-and-core-services)
6. [Application Management](#6-application-management)
7. [Person Management](#7-person-management)
8. [License Classes](#8-license-classes)
9. [Testing System](#9-testing-system)
10. [License Issuance Workflow](#10-license-issuance-workflow)
11. [Additional Services](#11-additional-services)
12. [User Management](#12-user-management)
13. [Audit and Tracking](#13-audit-and-tracking)
14. [Database Design](#14-database-design)
15. [Modules Description](#15-modules-description)
16. [Business Rules and Constraints](#16-business-rules-and-constraints)
17. [User Interface and System Screens](#17-user-interface-and-system-screens)

---

## 1. Project Overview

The **Driving and Vehicle License Department (DVLD)** system is a comprehensive desktop application engineered to automate and centrally manage all operations pertaining to driver licensing services. It simulates the operational environment of a real-world government department responsible for issuing, renewing, replacing, and managing driving licenses for qualified applicants.

The system provides a structured and rule-enforced digital workflow for managing individuals, applications, tests, license classes, system users, and audit logs. It ensures that all applicants meet mandatory legal, medical, and procedural requirements before a license is issued or renewed.

| Attribute | Details |
|---|---|
| System Name | Driver License Issuance and Management System |
| Department | Driving and Vehicle License Department (DVLD) |
| Application Type | Desktop Application (Windows) |
| Primary Language | C# (.NET Framework) |
| User Interface | Windows Forms (WinForms) |
| Data Access Layer | ADO.NET |
| Database Engine | Microsoft SQL Server |
| Architecture | Layered (Presentation, Business Logic, Data Access, Database) |

---

## 2. System Objectives

### Primary Objectives

- Automate the complete workflow of driver license issuance, from initial application to final license generation.
- Provide a centralized repository for all persons, applications, licenses, and test records.
- Enforce legal, procedural, and age-based eligibility requirements for all license classes.
- Support multiple license service types including first-time issuance, renewal, replacement, and international licensing.
- Manage and sequence the three mandatory testing stages: vision test, theory test, and practical driving test.
- Enable user account management with role-based access control and authentication.
- Maintain comprehensive audit trails for all system actions to ensure accountability and traceability.
- Prevent duplicate person records and duplicate active applications through enforced validation rules.

### Secondary Objectives

- Provide an intuitive graphical user interface suitable for departmental staff.
- Ensure data integrity through referential constraints and business rule enforcement at the application layer.
- Support configurable license class parameters including age limits, validity durations, and associated fees.
- Enable license detention, release, and international licensing as supplementary administrative services.

---

## 3. Technology Stack

### C# (.NET Framework)

C# serves as the primary programming language for the entire application. It implements all business logic, processes user input, enforces validation rules, manages application workflows, and orchestrates data access operations.

### Windows Forms (WinForms)

Windows Forms provides the graphical user interface framework. Each functional module is implemented as a dedicated form. WinForms enables event-driven programming where user interactions trigger the corresponding business logic methods implemented in C#.

### ADO.NET

ADO.NET functions as the data access layer, managing the lifecycle of database connections, executing parameterized SQL queries and stored procedures, and retrieving or modifying data within SQL Server.

| Component | Responsibility |
|---|---|
| `SqlConnection` | Opens and closes the connection to the SQL Server database |
| `SqlCommand` | Executes parameterized SQL queries and stored procedures |
| `SqlDataReader` | Forward-only reading of query results |
| `SqlDataAdapter` | Populates `DataTable` and `DataSet` objects for UI binding |

### Microsoft SQL Server

SQL Server provides the relational database management system for persistent storage of all application data, including normalized tables, referential integrity constraints, and stored procedures.

### Technology Integration

| Technology | Role |
|---|---|
| Windows Forms | Renders the UI and captures user input through event-driven controls |
| C# | Applies business rules and delegates data operations to ADO.NET |
| ADO.NET | Translates C# requests into SQL commands and communicates with SQL Server |
| SQL Server | Executes queries, enforces relational integrity, and persists all data |

---

## 4. System Architecture

The DVLD system follows a four-tier layered architecture that separates concerns across distinct tiers.

```
┌─────────────────────────────────────────────────────────────┐
│              PRESENTATION LAYER                             │
│         Windows Forms — UI Forms, Controls, Events          │
├─────────────────────────────────────────────────────────────┤
│              BUSINESS LOGIC LAYER                           │
│         C# Classes — Rules, Validation, Workflows           │
├─────────────────────────────────────────────────────────────┤
│              DATA ACCESS LAYER                              │
│    ADO.NET — SqlConnection, SqlCommand, SqlDataReader        │
├─────────────────────────────────────────────────────────────┤
│              DATABASE LAYER                                 │
│     SQL Server — Tables, Stored Procedures, Constraints      │
└─────────────────────────────────────────────────────────────┘
```

### Presentation Layer
Implemented using Windows Forms. Responsible for rendering the user interface, capturing user input, and displaying results. Does not contain business logic.

### Business Logic Layer
Implemented as C# classes and methods that encapsulate all system rules, workflows, and validations. Invoked by the presentation layer and in turn invokes the data access layer.

### Data Access Layer
Implemented using ADO.NET. Manages database connections, prepares and executes SQL commands, and returns structured data to the business logic layer. Parameterized queries are used throughout to prevent SQL injection.

### Database Layer
A Microsoft SQL Server database containing all tables, relationships, constraints, and stored procedures required by the system.

---

## 5. Features and Core Services

The system provides seven primary license service operations.

### 5.1 First-Time Local Driving License Issuance

The applicant submits an application linked to their person record. The system validates eligibility including age requirements and the absence of an existing active license of the same class. Upon approval, the applicant is scheduled for the three sequential tests. After passing all tests, the license is formally issued and a driver record is created.

**Conditions:**
- Applicant must meet the minimum age requirement for the selected license class.
- No existing active license of the same class must be present.
- All three tests must be passed in sequence.

### 5.2 Retake Test Service

Allows an applicant who has failed one of the three tests to register for a retake. The system identifies the most recently failed test for the active application and creates a new appointment for that specific stage.

**Conditions:**
- The applicant must have an active application with at least one failed test.
- Retake is permitted only for the specific stage that was failed.
- A retake fee is charged per attempt.

### 5.3 License Renewal

Allows a holder of an expired or about-to-expire local driving license to renew it. A renewal application is created, and upon processing, a new license record is issued with an updated expiration date. The previous license is marked as inactive.

### 5.4 Replacement for Lost License

Issues a replacement license to an applicant who has reported their license as lost. The original license is marked as replaced and a new license is issued with the same class.

### 5.5 Replacement for Damaged License

Issues a replacement license when the physical license card is reported as damaged. The replacement reason is recorded distinctly from a lost license scenario.

### 5.6 License Release (Unblock)

Releases a detained or blocked driving license, restoring it to active status. The detention record is closed and the license is reinstated after administrative review.

### 5.7 International Driving License Issuance

Issues an international driving license to a holder of a valid local license. The applicant's active local license is validated before the international license is issued with a defined validity period.

---

## 6. Application Management

Applications represent the formal administrative requests submitted by individuals for license-related services.

### Application Lifecycle

| Status | Description |
|---|---|
| New | The application has been submitted and is actively being processed. Tests and approvals are pending. |
| Completed | All required steps have been fulfilled. The license has been issued or the service has been delivered. |
| Cancelled | The application has been withdrawn or administratively terminated prior to completion. |

### Validation Rules

- No two active (New status) applications for the same service type and license class may exist for the same person simultaneously.
- Every application must be linked to an existing person record.
- Fees are calculated and recorded at the time of application creation.

### Stored Attributes

| Field | Description |
|---|---|
| Application ID | Unique system-generated identifier |
| Application Date | The date the application was submitted |
| Application Type | Category of service requested (e.g., First Time, Renewal, Replacement) |
| Status | Current lifecycle state: New, Completed, or Cancelled |
| Fees | Total fees charged, calculated at submission |
| Person ID | Foreign key to the applicant's person record |
| Created By | User ID of the system user who created the application |

---

## 7. Person Management

The person management module maintains a centralized registry of all individuals who interact with the DVLD system.

### Key Rules

- Each person is uniquely identified by their **National ID number**. Duplicate entries are rejected.
- Full CRUD operations are supported: Create, Read, Update, Delete.
- A person record cannot be deleted if it is referenced by any application, license, or user account.

### Stored Attributes

| Field | Description |
|---|---|
| Person ID | Unique system-generated primary key |
| First / Second / Third / Last Name | Legal full name components |
| National ID | Government-issued unique identifier. Must be unique. |
| Date of Birth | Used for age validation during eligibility checks |
| Gender | Recorded for administrative purposes |
| Address | Residential address |
| Phone | Primary contact telephone number |
| Email | Electronic mail address |
| Nationality | Citizenship or national origin |
| Photo | Profile photograph for identification |

---

## 8. License Classes

The system supports multiple categories of driving licenses, each with distinct parameters. Classes are pre-configured in the database but can be administratively adjusted without code changes.

| Class | Description | Min. Age | Validity | Fee |
|---|---|---|---|---|
| Class 1 | Motorcycles and motor-driven cycles | 18 | 5 years | Standard |
| Class 2 | Private passenger vehicles and light trucks | 18 | 10 years | Standard |
| Class 3 | Taxis and limousines for hire | 21 | 5 years | Standard |
| Class 4 | Buses and large passenger vehicles | 21 | 5 years | Higher |
| Class 5 | Heavy trucks and freight vehicles | 21 | 5 years | Higher |
| Class 6 | Agricultural machinery and tractors | 21 | 5 years | Standard |
| Class 7 | Special purpose and construction vehicles | 21 | 5 years | Higher |

> Exact fee values and validity durations are stored in the database configuration and are subject to departmental policy.

---

## 9. Testing System

Before a first-time local driving license can be issued, every applicant must successfully complete **three sequential mandatory tests**. Each test must be passed before the applicant is eligible to proceed to the next stage.

```
Vision Test  ──►  Theory Test  ──►  Practical Driving Test  ──►  License Issued
```

### 9.1 Vision Test

Verifies that the applicant possesses adequate visual acuity required for safe driving. Scheduled upon creation of the initial application. If failed, a retake application is created.

### 9.2 Theory Test

Evaluates the applicant's knowledge of traffic laws, road signs, and safety regulations. Available **only after the vision test has been passed**. Failed applicants may retake upon payment of the retake fee.

### 9.3 Practical Driving Test

Assesses the applicant's ability to operate a vehicle safely under real driving conditions. Available **only after both vision and theory tests have been passed**.

### Test Record Attributes

| Field | Description |
|---|---|
| Test Appointment ID | Unique identifier for each test booking |
| Application ID | Reference to the associated license application |
| Test Type | Vision, Theory, or Practical |
| Scheduled Date | Date on which the test is scheduled |
| Result | Pass or Fail |
| Test Fee | Fee charged for this attempt |
| Attempt Number | Sequential count for retake tracking |
| Administered By | User ID of the operator who recorded the result |

---

## 10. License Issuance Workflow

The full workflow for first-time local driving license issuance follows a structured sequence of stages.

| Step | Stage | Description |
|---|---|---|
| 1 | Person Lookup | The applicant's person record is located via National ID. If none exists, a new record is created. |
| 2 | Application Submission | A new First Time Issuance application is created. Eligibility and duplicate checks are performed. |
| 3 | Vision Test | The vision test is scheduled and the result is recorded. |
| 4 | Theory Test | Upon passing the vision test, the theory test is scheduled. |
| 5 | Practical Test | Upon passing the theory test, the practical driving test is scheduled. |
| 6 | Approval | Upon passing all three tests, the application is marked for license issuance. |
| 7 | License Issuance | The license record is created with a unique number, issue date, expiry date, and class. Application is marked Completed. |
| 8 | Driver Record | A driver record is created or updated to reflect the newly issued license class. |

### License Record Attributes

| Field | Description |
|---|---|
| License ID | Unique system-generated identifier |
| License Number | Formatted license card number |
| Application ID | Reference to the originating application |
| License Class ID | Reference to the applicable license class |
| Issue Date | Date on which the license was formally issued |
| Expiry Date | Calculated from issue date plus class validity duration |
| Status | Active, Expired, Detained, or Replaced |
| Notes | Optional administrative notes |
| Issued By | User ID of the issuing operator |

---

## 11. Additional Services

### License Renewal

A renewal application is submitted, and upon processing, a new license record is generated. The old record is deactivated and the new license inherits the same class with a freshly calculated expiry date.

### Replacement Services

- **Lost License Replacement:** The applicant formally declares the loss. The original license is marked Replaced and a new license is issued.
- **Damaged License Replacement:** Issued when the physical card is rendered unusable. The replacement reason is recorded distinctly.

### License Detention and Release

A license may be placed in a detained state by an authorized user. While detained, the license is not valid for use. License release reverses the detention by closing the detention record and restoring the license to active status. The release date and approving user are recorded.

### International Driving License

An international driving license may be issued to any applicant who holds a valid and active local driving license. The international license is issued for a fixed validity period. The system links the international license record to the applicant's local license and person record.

---

## 12. User Management

### User Accounts and Authentication

Each system operator is assigned a unique user account consisting of a username and a secured password, linked to a corresponding person record. The system enforces credential-based authentication at the login screen.

### User Record Attributes

| Field | Description |
|---|---|
| User ID | Unique system-generated identifier |
| Username | Unique login identifier |
| Password | Hashed credential for authentication |
| Person ID | Foreign key linking the user to their personal record |
| Is Active | Indicates whether the account is currently enabled |
| Permissions Level | Defines the scope of accessible system modules and actions |

---

## 13. Audit and Tracking

All significant actions performed within the system are recorded in an audit log. Audit entries cannot be edited or deleted by standard users, ensuring the integrity of the historical record.

### Audit Log Attributes

- **Action Type:** Describes the nature of the operation (e.g., Create Application, Issue License, Record Test Result).
- **User ID:** The identifier of the user who performed the action.
- **Timestamp:** The precise date and time of the action.
- **Target Record ID:** The identifier of the affected record.
- **Module:** The system module in which the action occurred.

### Purpose

- **Accountability:** All actions are traceable to a specific user.
- **Fraud Detection:** Unusual activity patterns can be identified through audit review.
- **Compliance:** Operations can be audited against regulatory requirements.
- **Dispute Resolution:** Audit logs provide authoritative records for disputed transactions.

---

## 14. Database Design

### Core Tables

| Table | Description |
|---|---|
| `People` | Stores all personal information for every registered individual |
| `Users` | Stores system user accounts linked to person records |
| `LicenseClasses` | Configuration table defining license categories, age limits, validity, and fees |
| `Applications` | Stores all service applications submitted by individuals |
| `LocalDrivingLicenses` | Stores issued local driving license records |
| `InternationalLicenses` | Stores issued international license records linked to local licenses |
| `TestAppointments` | Stores all scheduled and completed test records |
| `DetainedLicenses` | Records licenses placed in detained status |
| `Drivers` | Records driver profiles created upon successful first-time issuance |

### Key Relationships

- **People → Users:** One-to-one. Each user account is linked to exactly one person record.
- **People → Applications:** One-to-many. A person may have multiple applications over time.
- **Applications → LocalDrivingLicenses:** One-to-one per issuance. Each issued license traces back to its originating application.
- **Applications → TestAppointments:** One-to-many. A first-time application may have multiple test records across stages and retakes.
- **LocalDrivingLicenses → InternationalLicenses:** One-to-many. A local license may be the basis for multiple international licenses.
- **LocalDrivingLicenses → DetainedLicenses:** One-to-one per active detention.
- **LicenseClasses → LocalDrivingLicenses:** One-to-many. Multiple licenses may belong to the same class.

---

## 15. Modules Description

| Module | Description |
|---|---|
| People Management | Full CRUD for person records. Search by National ID, add, update, attach photos, and view profiles. |
| User Management | Manage system user accounts. Create, assign permissions, activate or deactivate, and update credentials. |
| Local License Applications | Handles first-time issuance, retake registration, renewal, replacement, and release applications. |
| Test Appointments | Schedule and record all three test types. Trigger retake creation on failure. |
| International Licenses | Issue and view international driving licenses with local license validation. |
| Detained Licenses | View all detained licenses and process release requests. |
| Drivers | Registry of all licensed drivers with full license history per person. |

---

## 16. Business Rules and Constraints

### Person Rules
- National ID must be unique across all person records.
- Date of birth is mandatory and must be a valid past date.
- A person record cannot be deleted if referenced by any dependent record.

### Application Rules
- Only one active application of the same type and license class may exist per person at any time.
- Applications can only be cancelled if no license has been issued from them.
- Application fees are calculated at creation time and are not retroactively modified.

### License Class Eligibility
- The applicant's age must meet or exceed the minimum age defined for the selected license class.
- An applicant may not hold two active licenses of the same class simultaneously.

### Testing Rules
- Tests must be completed in sequence: vision → theory → practical.
- A failed test prevents progression until that test is passed.
- Each retake requires a separate application and payment of the retake fee.

### License Issuance Rules
- All three tests must be passed before a license can be issued.
- The expiry date is automatically calculated from the issue date plus the class validity duration.
- Each issued license must have a unique license number.

### Renewal and Replacement Rules
- A detained license cannot be renewed or replaced until the detention is resolved.
- Replacement licenses retain the original license class but generate a new license record.
- International licenses cannot be renewed through the standard renewal process.

---

## 17. User Interface and System Screens

### Authentication

#### Login Screen
This screen provides secure access to the DVLD system. Users enter their username and password to authenticate before gaining access to any system module. Invalid credentials are rejected with an appropriate error notification.

![Login Screen](pictures/LoginScreen.png)

---

#### Main Screen
The main screen serves as the central navigation hub of the application. It presents the primary menu structure enabling authorized users to navigate to any major system module including People Management, Applications, License Services, Tests, and User Administration.

![Main Screen](pictures/MainScreen.png)

---

### People Management

#### Manage People
Provides a searchable list of all registered persons. Staff can search by National ID or name, and from this screen initiate create, view, update, or delete operations on individual person records.

![Manage People](pictures/ManagePeople.png)

---

#### Person Details
Displays a complete profile of a selected individual, including personal information, contact details, photograph, and associated records such as applications and licenses.

![Person Details](pictures/PersonDetails.png)

---

#### Add New Person
Allows authorized staff to create a new person record. All required personal details are captured through validated input fields. Duplicate National ID entries are prevented by the system.

![Add New Person](pictures/AddNewPicture.png)

---

#### Update Person Information
Enables staff to modify the contact details, address, or other mutable attributes of an existing person record. Identity fields such as National ID remain locked after creation.

![Update Person Information](pictures/UpdatePersonInfo.png)

---

### User Management

#### Manage Users
Provides a list of all system user accounts. Administrators can view account status, navigate to individual user records, and initiate account management actions.

![Manage Users](pictures/ManageUsers.png)

---

#### Add New User
Allows administrators to create a new system user account. The account must be linked to an existing person record, and a username and initial password must be assigned.

![Add New User](pictures/AddNewUser.png)

---

#### Update User Information
Enables administrators to modify user account attributes such as permission level and active status.

![Update User Information](pictures/UpdateUserInfo.png)

---

#### Change User Credentials
Provides a secure interface for updating a user's authentication credentials. The process requires entry of the current password before a new one can be applied.

![Change User Credentials](pictures/ChangeUserInfo.png)

---

#### User Details
Presents a summary view of an individual user account including linked person information, assigned permissions, account status, and recent activity indicators.

![User Details](pictures/UserDetails.png)

---

#### Manage User Account Menu
Provides a structured menu of account-level operations, allowing users to access credential management, profile review, and permission-related settings from a single point.

![Manage User Account Menu](pictures/ManageUserAccountMenue.png)

---

### Applications

#### Applications Menu
Presents the main categorized entry point for all license service types available within the system.

![Applications Menu](pictures/ApplicationsMenue.png)

---

#### Driving License Services Menu
Provides direct navigation to each specific license service operation. Staff select the applicable service type to proceed with the corresponding application workflow.

![Driving License Services Menu](pictures/DrivingLicenseServicesMenue.png)

---

### Local Driving License Applications

#### Manage Local Driving License Applications
Provides a comprehensive management view of all local driving license applications. Applications can be filtered by type, status, date range, and applicant.

![Manage Local Driving License Applications](pictures/ManageLocalDrivingLicenseApplications.png)

---

#### Add New Local Driving Application
Initiates the first-time license issuance process. The operator selects the applicant from the person registry and assigns the applicable license class. Eligibility checks are performed prior to submission.

![Add New Local Driving Application](pictures/AddnewLocalDrivingApplication.png)

---

#### Issue Local Driving License — First Time
Manages the final stage of the first-time license issuance workflow. Confirms that all three tests have been passed and enables the operator to formally issue the license, generating the license record and driver profile.

![Issue Local Driving License First Time](pictures/IssueLocalDrivingLicenseFirsTime.png)

---

#### Renew Local Driving License
Enables processing of license renewal applications. Displays the current license details, calculates the new expiry date, and records the renewal upon confirmation.

![Renew Local Driving License](pictures/RenewLocalDrivingLicense.png)

---

#### Replace Local Driving License
Handles replacement of a lost or damaged driving license. The operator selects the replacement reason and the system deactivates the original license record before issuing the replacement.

![Replace Local Driving License](pictures/ReplaceLocalDrivingLicense.png)

---

#### Release Local Driving License
Processes the unblocking of a detained license. After administrative review, the operator confirms the release, which closes the detention record and reinstates the license to active status.

![Release Local Driving License](pictures/ReleaseLocalDrivingLicense.png)

---

### International Licenses

#### Manage International Licenses
Provides a list of all issued international driving licenses. Operators can search by person or local license reference and access full details of any record.

![Manage International Licenses](pictures/ManageInternationalLicenses.png)

---

#### International License Details
Displays the full details of a specific international license including the linked local license, issue date, expiry date, and issuing officer.

![International License Details](pictures/InternationalLicenseDetails.png)

---

### Detained Licenses

#### Detain License
Enables authorized staff to place a driving license in detained status. The detention reason, date, and administering officer are recorded as part of the detention record.

![Detain License](pictures/DetainLicense.png)

---

#### Manage Detained Licenses
Presents a consolidated view of all currently detained licenses. Each entry displays the detention date, reason, and holder information. Operators can initiate release actions from this screen.

![Manage Detained Licenses](pictures/ManageDetainedLicenses.png)

---

### Tests and Appointments

#### Manage Test Appointments
Displays all scheduled and completed test appointments. Enables filtering by test type, date range, and result.

![Manage Test Appointments](pictures/ManageTestsAppointments.png)

---

#### Schedule Vision Test
Facilitates the creation of a vision test appointment for a new applicant. Links the appointment to the active application and records the scheduled date and associated fee.

![Schedule Vision Test](pictures/ScheduleVisionTest.png)

---

#### Schedule Written (Theory) Test
Manages the creation of a theory test appointment. Accessible only after the corresponding vision test has been passed.

![Schedule Written Test](pictures/ScheduleWrittenTest.png)

---

#### Take Test / Record Result
Used by examiners to record the outcome of a scheduled test. The pass or fail result is entered and confirmed, triggering the appropriate next action — progression or retake registration.

![Take Test](pictures/TakeTest.png)

---

### Drivers and License History

#### Manage Drivers
Provides a registry of all individuals who have been issued at least one local driving license. Records can be searched by person details and linked to the full license history.

![Manage Drivers](pictures/ManageDrivers.png)

---

#### Local License Details
Displays the complete record of a specific issued license, including license number, class, issue date, expiry date, current status, and the history of any service transactions applied to it.

![Local License Details](pictures/LocalLicenseDetails.png)

---

#### Person License History
Provides a chronological view of all licenses and license-related transactions associated with a specific individual. Serves as a comprehensive audit trail of the person's entire licensing record.

![Person License History](pictures/PersonLicenseHistory.png)

---

## Conclusion

The DVLD system represents a complete, production-quality desktop application that automates and centralizes the full spectrum of driver licensing operations. It demonstrates the effective integration of C#, Windows Forms, ADO.NET, and SQL Server within a cleanly layered architectural framework.

The application addresses real-world operational requirements through a structured set of services including first-time license issuance, test management, renewal, replacement, international licensing, and administrative functions such as detention and release. Every workflow is governed by well-defined business rules and validation logic that reflect the procedural standards expected of a government licensing department.

The system design emphasizes data integrity through normalized database structures and enforced referential constraints, security through credential-based authentication and audit logging, and usability through a consistent and navigable interface organized around clearly defined functional modules.
