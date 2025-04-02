

# School Management API

## Overview
The **School Management API** is a RESTful backend service designed to manage various aspects of a school, including **students**, **courses**, and **teachers**. Built with **ASP.NET Core**, this API provides the ability to perform CRUD (Create, Read, Update, Delete) operations for managing student and course data, along with functionality for teachers. It supports secure JWT authentication for user management.

---

## Features
- **Student Management**: Register, update, retrieve, and delete student data.
- **Course Management**: Add, update, retrieve, and delete course data.
- **Teacher Management**: Handle teacher-related information with basic CRUD operations.
- **Authentication & Authorization**: Secure user authentication with JWT tokens.
- **Password Security**: Secure password handling using BCrypt hashing.
- **RESTful Endpoints**: Designed for scalability and easy maintenance.

---

## Technologies Used
- **ASP.NET Core**: Framework for building the API backend.
- **Entity Framework Core**: ORM for database interactions.
- **JWT (JSON Web Tokens)**: Secure user authentication and authorization.
- **BCrypt.Net**: Library for password hashing.
- **AutoMapper**: To map between entities and DTOs (Data Transfer Objects).
- **SQL Server / Database**: Storage for teacher, student, and course data.

---

## Prerequisites
Before running the API, ensure the following tools are installed:

- [.NET SDK 6.0 or later](https://dotnet.microsoft.com/download/dotnet)
- **SQL Server** or **SQL Server Express** for the database.
- **Postman** or any API client for testing the endpoints.

---

## Setup & Installation

1. **Clone the repository**:
    ```bash
    git clone https://github.com/Tondwani/SchoolManagementAPI.git
    cd SchoolManagementAPI
    ```

2. **Configure the Database**:
    - Open the `appsettings.json` file and update the connection string for SQL Server:
    ```json
    "ConnectionStrings": {
        "DefaultConnection": "Server=your_server;Database=SchoolDb;Trusted_Connection=True;"
    }
    ```

3. **Install Dependencies**:
    Run the following command to restore the required packages:
    ```bash
    dotnet restore
    ```

4. **Run Migrations** (optional):
    To apply migrations and set up the database schema:
    ```bash
    dotnet ef database update
    ```

5. **Run the API**:
    Start the application:
    ```bash
    dotnet run
    ```

    The API will be available at `http://localhost:5000` or `https://localhost:5001`.

---

## API Endpoints

### Teacher Endpoints

#### Teacher Registration
- **POST** `/api/teacher/register`
    - Registers a new teacher.
    - **Request Body**:
      ```json
      {
        "FirstName": "John",
        "LastName": "Doe",
        "Password": "your_password",
        "NationalIDNumber": "123456789",
        "MaritalStatus": "Single",
        "Gender": "Male"
      }
      ```

#### Teacher Login
- **POST** `/api/teacher/login`
    - Logs in a teacher by verifying credentials.
    - **Request Body**:
      ```json
      {
        "NationalIDNumber": "123456789",
        "Password": "your_password"
      }
      ```
    - **Response**: Returns a JWT token.

#### Get All Teachers
- **GET** `/api/teacher/all`
    - Retrieves a list of all teachers. **Authorization required**.

#### Get Teacher by ID
- **GET** `/api/teacher/{id}`
    - Retrieves a specific teacher's details by their ID. **Authorization required**.

#### Update Teacher Details
- **PUT** `/api/teacher/{id}`
    - Updates a teacher's details by their ID. **Authorization required**.

#### Delete Teacher
- **DELETE** `/api/teacher/{id}`
    - Deletes a teacher by their ID. **Authorization required**.

---

### Student Endpoints

#### Get All Students
- **GET** `/api/student`
    - Retrieves a list of all students.
    - **Authorization required** for private endpoints.

#### Get Student by ID
- **GET** `/api/student/{id}`
    - Retrieves a specific student's details by their ID.
    - **Authorization required** for private endpoints.

#### Add New Student
- **POST** `/api/student`
    - Registers a new student.
    - **Request Body**:
      ```json
      {
        "FirstName": "Jane",
        "LastName": "Smith",
        "DateOfBirth": "2005-09-10",
        "Gender": "Female",
        "NationalIDNumber": "987654321",
        "EnrollmentDate": "2021-01-15"
      }
      ```

#### Update Student Details
- **PUT** `/api/student/{id}`
    - Updates an existing student's details.
    - **Request Body**: Same as the add new student body.

#### Delete Student
- **DELETE** `/api/student/{id}`
    - Deletes a student by their ID.

---

### Course Endpoints

#### Get All Courses
- **GET** `/api/course`
    - Retrieves a list of all courses.

#### Get Course by ID
- **GET** `/api/course/{id}`
    - Retrieves a specific course's details by ID.

#### Add New Course
- **POST** `/api/course`
    - Adds a new course.
    - **Request Body**:
      ```json
      {
        "CourseName": "Mathematics 101",
        "CourseDescription": "Introduction to basic mathematics.",
        "Credits": 3
      }
      ```

#### Update Course Details
- **PUT** `/api/course/{id}`
    - Updates an existing course's details.

#### Delete Course
- **DELETE** `/api/course/{id}`
    - Deletes a course by its ID.

---

## Authentication & Authorization

The API uses **JWT (JSON Web Tokens)** for authentication. After a successful login, the API will return a JWT token that should be included in the `Authorization` header as `Bearer <your_jwt_token>` for accessing protected endpoints.

---

## Example Request (Login)

```bash
curl --request POST \
  --url http://localhost:5000/api/teacher/login \
  --header 'Content-Type: application/json' \
  --data '{
    "NationalIDNumber": "123456789",
    "Password": "your_password"
  }'
```

---

## Role-Based Access


- **Teacher**: Can manage their own data and access teacher-related endpoints.
- **Student**: Can view and interact with their personal data and course information.

---

## Contributing

We welcome contributions to improve and enhance this API. To contribute:

1. Fork the repository.
2. Create a new branch.
3. Make your changes and commit them.
4. Push the changes to your forked repository.
5. Submit a pull request.

---

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

## Contact

For any questions or issues, feel free to open an issue on the repository, or reach out to the project maintainer at [youremail@example.com].

---

## Acknowledgments

- [ASP.NET Core Documentation](https://docs.microsoft.com/en-us/aspnet/core)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [AutoMapper](https://automapper.org/)
- [BCrypt.Net](https://github.com/BcryptNet/bcrypt.net)

---

## GitHub Repository
- [School Management API GitHub Repository](https://github.com/Tondwani/SchoolManagementAPI)


