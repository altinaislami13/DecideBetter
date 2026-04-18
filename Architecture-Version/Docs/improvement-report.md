# DecideWise - Improvement Sprint Report

## Overview
This sprint focused on improving the architecture, reliability, and documentation of the DecideWise system. The goal was not to add new features, but to improve code quality and software engineering practices.

---

# 🔧 Improvement 1: Code Structure Refactoring

## Problem
- Business logic and validation were mixed inside the service layer
- No separation of responsibilities
- Code was harder to maintain and extend

## Solution
- Introduced separation between validation and service logic
- Improved DecisionService by removing unnecessary responsibilities
- Applied cleaner architecture principles (SRP)

## Why it's better
- Easier to maintain and extend
- Follows Single Responsibility Principle
- Improves readability and scalability

---

# 🛡️ Improvement 2: Reliability & Error Handling

## Problem
- Application could crash on invalid input
- File loading was not safe (missing or corrupted JSON)
- Repository returned inconsistent error handling (Console.WriteLine)

## Solution
- Replaced silent failures with exceptions (KeyNotFoundException, ArgumentException)
- Added validation for ID, score, and input values
- Added safe file loading with corruption recovery
- Centralized error handling in UI layer

## Why it's better
- Prevents unexpected crashes
- Makes system more stable (production-like behavior)
- Clear error propagation between layers

---

# 📚 Improvement 3: Documentation & Readability

## Problem
- Limited explanation of system architecture
- No structured documentation for understanding improvements

## Solution
- Added structured improvement report
- Improved clarity of system design explanation
- Documented reasons behind each architectural decision

## Why it's better
- Easier onboarding for new developers
- Better project evaluation for grading
- Shows engineering thinking, not just coding

---

# ⚠️ Remaining Weaknesses

- No real database (uses JSON file storage)
- Limited unit test coverage
- Console-based UI (no graphical interface)
- No authentication or user roles

---

# 🧠 Reflection

This sprint improved both the technical quality and architectural understanding of the project. The focus shifted from "making it work" to "making it maintainable, safe, and structured like a real-world system".

Key learnings:
- Importance of separation of concerns
- Proper error handling strategies
- Writing maintainable and testable code