# 🎓 Student Personal Details — CRUD Application

> A Windows desktop application for managing student personal records, built with C# (.NET Framework) and Microsoft SQL Server.

![Platform](https://img.shields.io/badge/Platform-Windows-blue)
![Language](https://img.shields.io/badge/Language-C%23-purple)
![Framework](https://img.shields.io/badge/Framework-.NET-blueviolet)
![Database](https://img.shields.io/badge/Database-SQL%20Server-red)
![IDE](https://img.shields.io/badge/IDE-Visual%20Studio%202022-5C2D91)
![Status](https://img.shields.io/badge/Status-Completed-brightgreen)

---

## 📖 Overview

**Student Personal Details** is a Windows Forms desktop application that demonstrates full **CRUD (Create, Read, Update, Delete)** functionality using C# connected to a Microsoft SQL Server Express database.

Developed as an individual assignment for the **Visual Programming** subject of MIT at the **South Eastern University of Sri Lanka** 

---

## ✅ Features

| Operation | Description |
|---|---|
| ➕ **Add** | Insert a new student record into the database |
| 👁️ **View** | Load and display all student records in a data grid |
| ✏️ **Update** | Modify an existing student's details |
| 🗑️ **Delete** | Remove a student record by Registration Number |
| 🔄 **Auto-fill** | Click any row in the grid to auto-populate all form fields |
| 🧹 **Clear** | Reset all form fields after an operation |

---

## 🗄️ Database

- **Database Engine:** Microsoft SQL Server Express
- **Database Name:** `student_info`
- **Table:** `dbo.student_info`

### Table Schema

| Column | Type | Description |
|---|---|---|
| `Reg_No` | `VARCHAR` | Registration number (Primary Key) |
| `First_Name` | `VARCHAR` | Student's first name |
| `Last_Name` | `VARCHAR` | Student's last name |
| `Street` | `VARCHAR` | Street address |
| `City` | `VARCHAR` | City |
| `District` | `VARCHAR` | District (ComboBox selection) |
| `NIC_No` | `VARCHAR` | National Identity Card number |
| `Mobile_Phone` | `VARCHAR` | Mobile phone number |
| `Email` | `VARCHAR` | Email address |

---

## 🏗️ Architecture

```
┌──────────────────────────────────────────────┐
│              UI Layer                         │
│     Windows Forms — Form1 (WinForms)          │
│  TextBoxes, ComboBox, DataGridView, Buttons   │
└───────────────────┬──────────────────────────┘
                    │
┌───────────────────▼──────────────────────────┐
│              Logic Layer                      │
│    C# Event Handlers (Add / Save / Update /   │
│    Delete / View / Cell Double-Click)         │
│    Parameterized SQL Queries                  │
└───────────────────┬──────────────────────────┘
                    │
┌───────────────────▼──────────────────────────┐
│              Data Layer                       │
│    Microsoft SQL Server Express               │
│    SqlConnection / SqlCommand / SqlDataReader │
└──────────────────────────────────────────────┘
```

---

## 🧩 Key Code Highlights

### Database Connection
```csharp
SqlConnection con = new SqlConnection(
    @"Data Source=ACER\SQLEXPRESS;
      Initial Catalog=student_info;
      Integrated Security=True"
);
```

### Insert (Add / Save)
```csharp
string query = "INSERT INTO student_info " +
    "(Reg_No, First_Name, Last_Name, Street, City, District, NIC_No, Mobile_Phone, Email) " +
    "VALUES (@r, @f, @l, @s, @c, @d, @n, @m, @e)";
```

### Update
```csharp
string sql = "UPDATE student_info SET " +
    "Reg_No = @r, First_Name = @f, Last_Name = @l, Street = @s, " +
    "City = @c, District = @d, NIC_No = @n, Mobile_Phone = @m, Email = @e " +
    "WHERE Reg_No = @r";
```

### Delete
```csharp
string sql = "DELETE from student_info WHERE Reg_No = @r";
```

### View (Read)
```csharp
string sql = "SELECT * FROM student_info";
// Results are populated into DataGridView1
```

---

## 🖥️ Tech Stack

| Component | Technology |
|---|---|
| Programming Language | C# (C Sharp) |
| Framework | .NET Framework |
| IDE | Microsoft Visual Studio 2022 |
| Database Engine | Microsoft SQL Server Express |
| Database Tool | SQL Server Management Studio (SSMS) |
| UI Layer | Windows Forms (WinForms) |

---

## 🚀 Getting Started

### Prerequisites
- Windows OS
- Visual Studio 2022
- Microsoft SQL Server Express
- SQL Server Management Studio (SSMS)

### Setup

1. **Clone the repository**
   ```bash
   git clone https://github.com/your-username/student-crud-app.git
   ```

2. **Create the database** — Open SSMS and run:
   ```sql
   CREATE DATABASE student_info;

   USE student_info;

   CREATE TABLE student_info (
       Reg_No       VARCHAR(20) PRIMARY KEY,
       First_Name   VARCHAR(50),
       Last_Name    VARCHAR(50),
       Street       VARCHAR(100),
       City         VARCHAR(50),
       District     VARCHAR(50),
       NIC_No       VARCHAR(20),
       Mobile_Phone VARCHAR(15),
       Email        VARCHAR(100)
   );
   ```

3. **Update the connection string** in `Form1.cs` if your SQL Server instance name differs:
   ```csharp
   @"Data Source=YOUR_SERVER_NAME\SQLEXPRESS;Initial Catalog=student_info;Integrated Security=True"
   ```

4. **Open the solution** in Visual Studio 2022, build, and run.

---

## 📄 License

This project was developed for academic purposes as part of the MIT 22033 Visual Programming course assignment at the South Eastern University of Sri Lanka. All rights reserved by K.D. Tharusha Iduwara (SEU/IS/21/MIT/007).
