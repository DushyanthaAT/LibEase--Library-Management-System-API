# LibEase - Backend (C# .NET with SQLite)

This is the backend for the **LibEase Library Management System**, built with **C# .NET** and **SQLite**. It provides RESTful API endpoints to manage the library's book records, including CRUD operations.

## Prerequisites

Ensure you have the following installed:
- **Visual Studio** (version 2019 or later) with the **.NET SDK**.
  - When installing Visual Studio, ensure to select the **.NET desktop development** and **ASP.NET and web development** workloads.
- **.NET SDK** (for backend development): [Download .NET SDK](https://dotnet.microsoft.com/download)
- **SQLite**: [Download SQLite](https://www.sqlite.org/download.html)

## Installation

1. Clone the repository:

   ```bash
   git clone [Insert GitHub Repo Link]
   cd backend
   ```
2. Open the backend project in Visual Studio:
- Launch Visual Studio.
- Go to File > Open > Project/Solution, and select the .sln file located in the backend folder.
- Apply database migrations:
  ```bash
  database-update
  ```
  
3. Build and run the backend:
- In Visual Studio, click Build > Build Solution or press Ctrl + Shift + B.
- Then, run the project by clicking Debug > Start Without Debugging or pressing Ctrl + F5.
- The backend should now be running at http://localhost:5000.

## API Endpoints
- POST /books: Create a new book.
- GET /books: Fetch all books.
- GET /books/{bookId}: Fetch details of a specific book.
- PUT /books/{bookId}: Update an existing book.
- DELETE /books/{bookId}: Delete a book.
- POST /auth/login: User login (librarian authentication).

## JWT Authentication
JWT is used for user authentication. The librarian needs to log in using valid credentials to perform book management operations.

## Technologies Used
- C# .NET (Core)
- SQLite (Database)
- Entity Framework Core (ORM for database operations)
- JWT (for authentication)
- RESTful API (for CRUD operations)

### Frontend Repo: [Link](https://github.com/DushyanthaAT/LibEase--Library-Management-System.git)
