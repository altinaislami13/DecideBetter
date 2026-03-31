# Class Diagram

## Option
- Id : int
- Name : string
- Score : int

## Criterion
- Name : string
- Weight : int

## IRepository<T>
+ GetAll()
+ GetById()
+ Add()
+ Save()

## FileRepository
Implements IRepository

## DecisionService
Uses Option

## ConsoleUI
Uses DecisionService