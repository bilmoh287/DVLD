# 🚗 Driving and Vehicle License Department (DVLD)

A full-featured **Driving & Vehicle License Management System** that simulates real-world government workflows for issuing, renewing, and managing driving licenses using a clean **3-Tier Architecture**.

---

## 🎯 Project Goal

The goal of this project is to design and implement a **scalable, maintainable desktop application** that models how a real Driving and Vehicle License Department operates — from citizen registration to license issuance, testing, and renewals.

This project focuses on **business logic correctness**, **layered architecture**, and **real-world use cases**, making it ideal for demonstrating backend and system design skills.

---

## ✨ Key Features

* 🔐 **User Authentication & Role Management**
* 👤 **Citizen (People) Management**
* 📝 **Driving License Applications Workflow**
* 🧪 **Driving Test Management**

  * Vision Test
  * Written (Theory) Test
  * Practical Driving Test
* 📄 **License Issuance & History Tracking**
* 🔄 **License Renewal & Replacement (Lost/Damaged)**
* 🌍 **International License Issuance**
* ⛔ **License Detainment & Release**
* 📊 **Application Status Tracking**

---

## 🛠️ Tech Stack

### 🖥️ Frontend

* C# WinForms
* Windows Desktop UI

### 🧠 Backend / Business Logic

* C# (.NET Framework)
* Object-Oriented Programming (OOP)
* 3-Tier Architecture (Presentation, Business, Data Access)

### 🗄️ Database

* Microsoft SQL Server
* ADO.NET

### 🔧 Tools & Concepts

* Visual Studio
* SQL Server Management Studio (SSMS)
* Layered Architecture
* Separation of Concerns
* CRUD Operations

---

## 🤔 Why This Project?

Government systems like driving license departments involve **complex workflows, strict rules, and multiple dependencies**.

I built this project to:

* Practice **enterprise-level application design**
* Apply **realistic business rules** instead of simple CRUD
* Gain hands-on experience with **multi-layer architecture**
* Simulate how large administrative systems are structured and maintained

This project bridges the gap between **academic projects** and **real-world software systems**.

---

## 🧩 Technical Challenges & Solutions

### 🔹 1. Managing Complex Application Workflows

**Challenge:**
Driving license applications must follow a strict sequence (Vision → Written → Practical). Handling test results, failures, retries, and application status transitions introduced complexity.

**Solution:**
I centralized workflow rules in the **Business Logic Layer**, ensuring:

* Tests must be passed in order
* Application status updates automatically
* UI remains clean and logic-free

This design makes the system easy to extend or modify without breaking existing flows.

---

### 🔹 2. Enforcing Business Rules Across the System

**Challenge:**
Rules like age restrictions, license eligibility, renewal conditions, and international license requirements must be consistently enforced.

**Solution:**
I implemented **rule validation methods** in the Business Layer rather than the UI or database.
This guarantees:

* Data integrity
* Single source of truth for rules
* Reusable and testable logic

---

## 🚀 Getting Started

Follow these steps to run the project locally:

```bash
# 1. Clone the repository
git clone https://github.com/bilmoh287/DVLD.git

# 2. Open the solution in Visual Studio
#    (DVLD.sln)

# 3. Restore database
- Open SQL Server Management Studio
- Restore the provided database backup (if available)
- Update the connection string in the Data Access Layer

# 4. Build & Run
Press F5 in Visual Studio
```

> ⚠️ Make sure SQL Server is running before launching the application.

---

## 🏗️ Architecture Overview

```
DVLDPresentationLayer   →  UI & User Interaction
DVLDBusinessLayer       →  Business Rules & Workflows
DVLDDataAccessLayer     →  Database Operations (ADO.NET)
```

This separation ensures:

* Maintainability
* Scalability
* Clean and testable code

