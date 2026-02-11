# Driving & Vehicle Licensing Department (DVLD) Database System

## Overview
This project represents a relational database system designed for managing a Driving & Vehicle Licensing Department (DVLD) using Microsoft SQL Server.  
The system manages citizens, users, applications, driving tests, licenses, international licenses, and detained licenses while enforcing referential integrity and proper normalization.

The database follows standard relational modeling principles and applies normalization (up to Third Normal Form) to reduce redundancy and maintain data consistency.

---

## Technologies Used
- Microsoft SQL Server
- Transact-SQL (T-SQL)
- Relational Database Model
- INT IDENTITY(1,1) for auto-increment primary keys
- DATETIME2 for date and time precision
- DECIMAL(10,2) for financial values
- BIT for boolean values
- NVARCHAR for Unicode text support

---

## Database Design Principles

### Primary Keys
All primary keys are defined as:
INT IDENTITY(1,1) PRIMARY KEY  
This ensures automatic incremental ID generation.

### Foreign Keys
All relationships are enforced using FOREIGN KEY constraints to maintain referential integrity between tables.

### Normalization
The database structure follows Third Normal Form (3NF):
- Lookup tables are separated (ApplicationTypes, TestTypes, LicenseClasses).
- No repeating groups.
- No transitive dependencies.
- Reduced data duplication.

---

## Tables Overview

### Core Entities
- Peoples
- Countries
- Users

### Application Management
- Applications
- ApplicationTypes
- LocalDrivingLicenseApplications

### Testing System
- TestTypes
- TestAppointments
- Tests

### Licensing System
- LicenseClasses
- Drivers
- Licenses
- InternationalLicenses
- DetainedLicenses

---

## Data Type Standards

Primary Keys: INT IDENTITY  
Dates: DATETIME2  
Financial Values: DECIMAL(10,2)  
Boolean Fields: BIT  
Text Fields: NVARCHAR  

All financial fields use DECIMAL instead of INT to preserve monetary precision.  
All date fields use DATETIME2 for higher accuracy and better future compatibility.

---

## Inserted Lookup Data

### LicenseClasses
- Small Motorcycle  
- Heavy Motorcycle  
- Private Car  
- Commercial  
- Agricultural  
- Small & Medium Bus  
- Heavy Truck  

### TestTypes
- Vision Test  
- Written Test  
- Street Test  

### ApplicationTypes
- New Driving License Service  
- Renew Driving License Service  
- Replacement for Lost License  
- Replacement for Damaged License  
- Release Detained License  
- New International Driving License  

---

## Relationships Summary

- A Person can submit multiple Applications.
- A User is linked to exactly one Person.
- An Application references:
  - ApplicantPersonID (Peoples)
  - CreatedByUserID (Users)
  - ApplicationTypeID (ApplicationTypes)
- LocalDrivingLicenseApplications references:
  - Applications
  - LicenseClasses
- TestAppointments references:
  - Users
  - TestTypes
  - LocalDrivingLicenseApplications
- Tests references:
  - Users
  - TestAppointments
- Drivers references:
  - Peoples
  - Users
- Licenses references:
  - Drivers
  - Applications
  - LicenseClasses
  - Users
- InternationalLicenses references:
  - Drivers
  - Licenses
  - Applications
  - Users
- DetainedLicenses references:
  - Licenses
  - Applications
  - Users

All relationships are strictly enforced via foreign key constraints.

---

## Purpose of the Project
This project demonstrates:
- Practical relational database modeling
- Proper SQL Server data typing
- Referential integrity enforcement
- Lookup table normalization
- Structured DDL scripting
- Clean schema design for enterprise systems

---

## Future Enhancements
- Add UNIQUE constraints (Email, NationalNo, UserName)
- Add CHECK constraints for positive fee values
- Add indexing for performance optimization
- Implement stored procedures
- Integrate with ASP.NET Core application layer

---
## SCHEMA
![Database Schema](DVLD-SCHEMA/drawSQL-image-export-2026-02-09.png)

## Author
Mahmoud Bakir  



