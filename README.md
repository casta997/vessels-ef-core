# Vessel Console App

## Overview
The Vessel Console App is a .NET 8 console application designed to manage a list of vessels. The application follows object-oriented principles, utilizing classes to encapsulate responsibilities and operations.

## Features
- **Initialize and Display**: At startup, the application initializes and displays a list of vessels with static values.
- **CRUD Operations**: The application supports the following operations:
  - **Create (C)**: Add a new vessel to the list.
  - **Read (R)**: Print the entire list of vessels.
  - **Update (U)**: Update the details of an existing vessel.
  - **Delete (D)**: Remove a vessel from the list.

## Vessel Class
The `Vessel` class represents a vessel with the following properties:
- `Id` (int): The unique identifier for the vessel, autogenerated and cannot be updated.
- `ImoNumber` (string): The IMO number of the vessel.

## Usage
After performing any operation, the current state of the vessel list is displayed.

### Commands
- **C**: Create a new vessel.
- **R**: Read and display the list of vessels.
- **U**: Update the IMO number of an existing vessel.
- **D**: Delete a vessel from the list.

## Branching
The person taking the assessment should create a branch from this repository named `test/<their-name>`.

## Conclusion
This application demonstrates basic CRUD operations in a console environment using object-oriented principles. It provides a simple yet effective way to manage a list of vessels.
