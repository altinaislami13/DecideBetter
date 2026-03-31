# Implementation – DecideWise (Premium Version)

## Overview

This project implements a fully functional decision-making system using a layered architecture.  
The application supports full CRUD operations with persistent storage using a CSV file.

The system follows clean architecture principles and demonstrates separation of concerns across layers.

---

## Architecture Flow

The application follows this execution flow:

UI → Service → Repository → CSV File

### Explanation:

- **UI (ConsoleUI)**
  - Handles user interaction
  - Reads input and displays output

- **Service (DecisionService)**
  - Contains business logic
  - Validates input
  - Applies filtering, ranking, and calculations

- **Repository (FileRepository)**
  - Handles data persistence
  - Reads/Writes data from/to CSV file

- **Data Source (options.csv)**
  - Stores all records persistently

---

## Implemented Features

### Core CRUD Operations

- Create → Add new option
- Read → List all options / Get by ID
- Update → Modify existing option
- Delete → Remove option

---

### Advanced Features

- Filter options by category
- Add score dynamically
- Calculate best option based on score
- Show Top 3 ranked options
- ValueScore calculation (Score / Price)

---

## Input Validation

The system includes strong validation:

- Name cannot be empty
- Price must be greater than 0
- ID must be numeric
- Safe parsing using `TryParse`

This prevents runtime errors and improves system reliability.

---

## Example Usage Flow

1. User selects "Add Option"
2. UI collects input (Name, Category, Price)
3. Service validates data
4. Repository saves data to CSV
5. Data persists for future runs

---

## Example Output
# Implementation – DecideWise (Premium Version)

## Overview

This project implements a fully functional decision-making system using a layered architecture.  
The application supports full CRUD operations with persistent storage using a CSV file.

The system follows clean architecture principles and demonstrates separation of concerns across layers.

---

## Architecture Flow

The application follows this execution flow:

UI → Service → Repository → CSV File

### Explanation:

- **UI (ConsoleUI)**
  - Handles user interaction
  - Reads input and displays output

- **Service (DecisionService)**
  - Contains business logic
  - Validates input
  - Applies filtering, ranking, and calculations

- **Repository (FileRepository)**
  - Handles data persistence
  - Reads/Writes data from/to CSV file

- **Data Source (options.csv)**
  - Stores all records persistently

---

## Implemented Features

### Core CRUD Operations

- Create → Add new option
- Read → List all options / Get by ID
- Update → Modify existing option
- Delete → Remove option

---

### Advanced Features

- Filter options by category
- Add score dynamically
- Calculate best option based on score
- Show Top 3 ranked options
- ValueScore calculation (Score / Price)

---

## Input Validation

The system includes strong validation:

- Name cannot be empty
- Price must be greater than 0
- ID must be numeric
- Safe parsing using `TryParse`

This prevents runtime errors and improves system reliability.

---

## Example Usage Flow

1. User selects "Add Option"
2. UI collects input (Name, Category, Price)
3. Service validates data
4. Repository saves data to CSV
5. Data persists for future runs

---

## Example Output
=== MENU PREMIUM ===

List Options
Add Option
Update Option
Delete Option
Filter by Category
Best Option
Top 3 Options
Add Score
Exit

---

## Design Patterns Used

### Repository Pattern
- Abstracts data access
- Allows easy replacement of storage (e.g., database)

### Dependency Injection
- Service receives repository via constructor
- Improves testability and flexibility

### Separation of Concerns
- UI, Service, and Data layers are independent

---

## SOLID Principles Applied

- **S (Single Responsibility)**  
  Each class has one responsibility (UI, Service, Repository)

- **D (Dependency Inversion)**  
  Service depends on abstraction (IRepository), not concrete class

---

## Conclusion

The system is fully functional and demonstrates:

- Clean architecture
- Professional error handling
- Scalable design
- Real-world CRUD implementation

This implementation is production-ready in structure and follows software engineering best practices.