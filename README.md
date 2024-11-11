# Japanese Quiz Web App - Ganbare 🇯🇵

## Project Overview
A Quiz web app to prepare you for JLPT which stands for Japanese Language Proficiency Test (which is similar to TOEFL but focuses on the Japanese Language). This fullstack project was built with .Net 8 and React JS.

## Features ✨
- **User Management**:
  - Register new user (Sign Up)
  - Sign In
  - User authentication with JWT token
  - User Password is hashed upon registering
  - Role-based access control (Admin, Customer)
  - Update user info
  - Delete User

- **Quiz Management**:
  - Add, update and delete quizzes by Admin
  - Get all quizzes
  - Custom exception handling

- **Question Management**:
  - Add, update and delete questions by Admin
  - Get all questions
  - Custom exception handling


- **Option Management**:
  - Add, update and delete options by Admin
  - Get all options
  - Custom exception handling


- **Result Management**:
  - Get all results by Admin
  - Custom exception handling


- **Leaderboard Management**:
  - Create leaderboard 
  - Update leaderboard
  - Custom exception handling


## Technologies Used

- **.Net 8**: Web API Framework
- **Entity Framework Core**: ORM for database interactions
- **PostgreSQl**: Relational database for storing data
- **JWT**: For user authentication and authorization
- **AutoMapper**: For object mapping
- **Swagger**: API documentation

## Prerequisites

- .Net 8 SDK
- SQL Server
- VSCode

## Project structure

```bash
|-- Controllers: API controllers with request and response
|-- Database # DbContext and Database Configurations
|-- DTO # Data Transfer Objects
|-- Entity # Database Entities (Quiz, Question, Option, Result, Leaderboard, User)
|-- Middlewares # Logging request, response and Error Handler
|-- Repository # Repository Layer for database operations
|-- Services # Business Logic Layer
|-- Utils # Customs Exception, Mapper Profile, Password Utils, Token Utils
|-- Migrations # Entity Framework Migrations
|-- Program.cs # Application Entry Point
```

## API Endpoints
**Options**
  - `GET /api/v1/Options`
  - `POST /api/v1/Options`
  - `GET /api/v1/Options/{id}`
  - `DELETE /api/v1/Options/{id}`
  - `PUT /api/v1/Options/{id}`
  - `GET /api/v1/questions/{questionsId}`

**Questions**
  - `POST /api/v1/Questions`
  - `GET /api/v1/Questions`
  - `GET /api/v1/Questions/{id}`
  - `DELETE /api/v1/Questions/{id}`
  - `PUT /api/v1/Questions/{id}`

**Results**
  - `POST /api/v1/Results`
  - `GET /api/v1/Results`
  - `GET /api/v1/Results/{id}`
  - `DELETE /api/v1/Results/{id}`
  - `PUT /api/v1/Results/{id}`
  - `GET /api/v1/Results/scores`


**Quizzes**
  - `POST /api/v1/Quizzes`
  - `GET /api/v1/Quizzes`
  - `GET /api/v1/Quizzes/{id}`
  - `PUT /api/v1/Quizzes/{id}`
  - `DELETE /api/v1/Quizzes/{id}`
  - `GET /api/v1/Quizzes/quizzes`


**Leaderboards**
  - `POST /api/v1/Leaderboards`
  - `GET /api/v1/Leaderboards`
  - `DELETE /api/v1/Leaderboards/{id}`
  - `PUT /api/v1/Leaderboards/{id}`
  - `GET /api/v1/Orders/userId/{id}`
  - `GET /api/v1/Leaderboards/{id}`

**Users**
  - `GET /api/v1/Users`
  - `GET /api/v1/Users/{id}`
  - `POST /api/v1/Users/auth`
  - `PUT /api/v1/Users/{id}`
  - `PATCH /api/v1/Users/{id}`
  - `DELETE /api/v1/Users/{id}`
  - `POST /api/v1/Users/signUp`
  - `POST /api/v1/Users/signIn`
  - `POST /api/v1/Users/create-admin`
  - `PATCH /api/v1/Users/make-admin`



  
## Deployment

The application is deployed and can be accessed at: [https://ganbare.onrender.com/](https://ganbare.onrender.com/)


## License

This project is licensed under the MIT License.
