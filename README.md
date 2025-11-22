# TransConnect - Transportation Management System

## Description

TransConnect is a console application for managing a transportation company developed in C#. The system allows you to manage clients, employees, vehicles, orders, and the company's organizational chart.

## Features

### Client Management
- Add new clients
- Delete existing clients
- Modify client information
- Display client list
- Search clients by city
- Sort clients by name
- Sort clients by purchase amount
- Automatic save to CSV file

### 👥 Employee Management
- Visualize company organizational chart
- Add new employees
- Remove employees
- Manage hierarchical relationships (colleagues, successors)
- Display organizational structure

### Vehicle Management
- Passenger cars
- Heavy trucks
- Assigned driver management

### Order Management
- Create new orders
- View existing orders
- Client-vehicle-driver association
- Delivery date tracking

### City Management
- Calculate distances between cities
- Distance graph support (via Excel file)
- **Dijkstra's algorithm** implementation for finding the shortest path between two cities
- Optimal route calculation



## Technologies Used

- **Language**: C# (.NET 10.0)
- **Type**: Console Application
- **Persistence**: CSV Files
- **Geographic Data**: Excel File
- **Algorithms**: Dijkstra's shortest path algorithm

## Algorithms & Key Features

### Dijkstra's Algorithm
The project implements **Dijkstra's algorithm** to calculate the shortest path between two cities. This feature:
- Finds the optimal route for deliveries
- Minimizes travel distance and costs
- Uses the distance matrix from `Distances.xlsx`
- Provides efficient pathfinding for logistics optimization




### Client Management

- **Add a client**: Enter the requested information (name, first name, date of birth, address, etc.)
- **Delete a client**: Enter the social security number of the client to delete
- **Modify a client**: Select the client and modify the desired fields
- **Display clients**: View the complete list of clients
- **Search by city**: Filter clients by city

### CSV File Format

The `Data/Client.csv` file uses the following format:
```
SSNumber;LastName;FirstName;BirthDate;Address;Email;Phone;City;PurchaseAmount
```

Example:
```
123456789;Dupont;Jean;1980-05-15;123 Rue A;jean@test.com;0612345678;Paris;1500.50
```

## Organigramme de l'Entreprise

The TransConnect company is structured as follows:

```
General Manager
└── Commercial Director
    ├── Operations Director
    │   ├── Team Leader 1
    │   │   └── Drivers
    │   └── Team Leader 2
    │       └── Drivers
    ├── HR Director
    │   ├── Training
    │   └── Contracts
    └── Financial Director
        └── Accounting Department
            ├── Management Controller
            └── Accountants
```

## Data Model

### Main Classes

- **Personne**: Abstract base class (name, first name, date of birth, etc.)
- **Client**: Inherits from Personne, adds city and purchase amount
- **Employe**: Manages employees with hierarchical relationships
- **Commande**: Associates a client, vehicle, and driver
- **Vehicule**: Abstract class for vehicles
- **Ville**: Manages cities and distances

## Data Persistence

Client data is automatically saved to the `Data/Client.csv` file after each modification:
- Client addition
- Client deletion
- Client modification

The file is created automatically if it doesn't exist, and the `Data/` folder is generated if necessary.

## Feature Examples

### Add a client
```csharp
AjouterClient(clients);
// Interactive information entry
// Automatic save to Client.csv
```

### Search for clients by city
```csharp
AfficheClientville(clients);
// Enter the city name
// Displays all clients in that city
```

### Display the organizational chart
```csharp
transconnect.Affichage(directeurGeneral);
// Displays the complete hierarchical structure
```

## Author

Project developed as part of a school project.

### Key Skills Demonstrated
- Object-oriented programming in C#
- Data structures and algorithms (Dijkstra's shortest path)
- File I/O and data persistence (CSV)
- Graph theory implementation
- Hierarchical data structures (organizational chart)
- Console application development

