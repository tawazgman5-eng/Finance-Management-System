Finance Management System
==========================

Overview:
---------
This is a Windows Forms application built with C# (.NET Framework) and MySQL.
It manages users, admins, finance managers, expenses, and balances.

Requirements:
-------------
- Windows 10/11
- .NET Framework 4.7.2 (or higher)
- MySQL Server installed and running
- Visual Studio 2022 Community Edition (for source build)

Installation:
--------------------------
1. Open Finance Management System.zip.
2. Extract the Files.
3. Open Finance Management System main folder.
4. Open App Installation
5. Click FinanceManagementSysSetup msi file
6. Proceed with the database setup below

=== DATABASE SETUP ===
1. Open MySQL Workbench or phpMyAdmin.
2. Run the provided finance_db.sql script.
3. This will create:
   - users (with Admin and FinanceManager seed accounts)
   - employees
   - accounts (with starting balance 10000.00)
   - expenses
4. Default logins:
   - Admin:    Email=admin@company.com | Password=admin123
   - Finance:  Email=finmanager@company.com | Password=fin123

How to Build:
-------------
1. Open `Finance Management Sys.sln` in Visual Studio.
2. Build the solution (`Ctrl + Shift + B`).
3. Run the application (`F5`).

Deployment / Installation:
--------------------------
1. Use the generated installer (see below).
2. If publishing with ClickOnce, install from the given link.
3. Ensure MySQL service is running before starting the app.

 
Login:
------
- Admins can manage users and employees.
- Finance Managers can manage balances and approve expenses.
- Users can only submit/view their expenses.

 

