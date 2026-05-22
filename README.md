# 🩺 CliniQ - Clinic Management System

CliniQ is a Clinic Management System developed using ASP.NET Core MVC and N-Tier Architecture to manage patients, appointments, and clinic workflow efficiently.
---
 🚀 Features

 👤 Patient Management
- Add new patients
- Edit patient information
- Delete patients
- Search patients by name
- View active patients

 📅 Appointment Management
- Create appointments
- Update appointment status
- Delete appointments
- View today's appointments
- Filter appointments by status

 📊 Dashboard
- Total patients count
- Active patients
- Pending appointments
- Today's schedule overview

 🔐 Authentication
- User Registration
- Login & Logout
- Password Hashing
- Authorization using ASP.NET Identity

---

 🛠 Technologies Used

- ASP.NET Core MVC
- C#
- Entity Framework Core
- SQL Server
- ASP.NET Identity
- Bootstrap 5
- LINQ
- Dependency Injection

---

 🧩 Architecture

The project follows N-Tier Architecture:

### DAL (Data Access Layer)
- Entities
- DbContext
- Repositories

 BLL (Business Logic Layer)
- Services
- Business Logic

PL (Presentation Layer)
- Controllers
- Views
- UI

---

 📂 Project Structure

CliniQ
│
├── Cliniq.DAL
├── Cliniq.BLL
├── Cliniq.PL
```

---
⚙️ Setup Instructions

 1️⃣ Clone the Repository

git clone https://github.com/yara-mohamedd/CliniQ

 2️⃣ Open Solution

Open the solution using Visual Studio.
 3️⃣ Update Database Connection

Edit `appsettings.json` or DbContext connection string.
 4️⃣ Apply Migrations


Add-Migration InitialCreate
Update-Database

5️⃣ Run the Project


Ctrl + F5
---

💡 Concepts Practiced

- MVC Pattern
- N-Tier Architecture
- Repository Pattern
- CRUD Operations
- Authentication & Authorization
- LINQ Queries
- Dependency Injection
- Entity Relationships

---

## 👩‍💻 Author

Developed by Yara Mohamed
