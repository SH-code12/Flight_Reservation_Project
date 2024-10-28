# Flight Reservation System

## Description

The Flight Reservation System is a web-based application designed to manage flight bookings and reservations efficiently. Inspired by real-world systems like [EgyptAir](http://www.egyptair.com), this project includes functionalities for both administrators and customers to interact seamlessly with flight data.

## Proposed Functionalities

### User Management
- **Sign Up**: Allows new users (both admin and customers) to create accounts.
- **Update User Details**: Users can modify their account information as needed.

### Aircraft Management (Admin Only)
- **Add Aircraft**: Admin can add new aircraft to the system.
- **Update Aircraft Details**: Admin can update the specifications of existing aircraft.

### Flight Management (Admin Only)
- **Add Flight**: Admin can add new flights to the system.
- **Update Flight Details**: Admin can update flight information.

### Flight Availability
- **View Available Flights**: Users can view a list of available flights based on specific criteria (e.g., date, source, destination, required number of seats).
- **Booking Operations**: Users can book flights, cancel bookings, or change flight classes.

### Reporting
- **Generate Reports**: The system can generate meaningful reports for administrative purposes (bonus functionality).

### Database
- The system utilizes a SQL Server database, which is generated from the physical Entity Relationship Diagram (ERD). The database includes populated data for testing and demonstration.

## Entity Relationship Diagram (ERD)

### Conceptual ERD
- A conceptual ERD has been constructed to represent the initial design of the system, showcasing entities, relationships, and attributes.

### Physical ERD
- The conceptual ERD has been converted into a physical ERD, defining primary keys, foreign keys, and the relationships between entities clearly.

### Bonus Features
- The ERD includes at least five entities, with one many-to-many relationship and one weak entity.

## SQL Server Database
- The SQL Server database has been generated based on the physical ERD and contains populated data to simulate real-world usage.

## Application Implementation

The application is implemented in C#, featuring the following SQL operations:

- **Insert Statements**: 
  - Insert a new user into the Users table.
  - Insert a new flight into the Flights table.

- **Delete Statements**: 
  - Delete a user from the Users table with specific conditions.
  - Delete a flight from the Flights table with specific conditions.

- **Update Statements**: 
  - Update user details in the Users table based on user ID.
  - Update flight details in the Flights table based on flight ID.

- **Select Operations**:
  - Select all users from the Users table.
  - Select flights that satisfy criteria using joins between Flights and Aircraft tables.

## GUI (Bonus)
- A Graphical User Interface (GUI) has been implemented to enhance user interaction with the system.

## Review Process
- The system's ERD has been reviewed with the TA, and necessary updates have been made to ensure accuracy and completeness.

## Installation and Usage
1. Clone the repository to your local machine.
2. Open the solution file in Visual Studio.
3. Ensure that SQL Server is running and the database is set up according to the provided schema.
4. Run the application and navigate through the functionalities.


## Contact
For inquiries, please contact:
- **Mail**: [MyEmail](shahdelnassag@gmail.com)
- **GitHub**: [Shand Elnassag](https://github.com/SH-code12)
