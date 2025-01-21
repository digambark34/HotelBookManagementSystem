
# Hotel Booking System

This is a simple hotel booking system written in C#. The system allows users to view available rooms, book a room, and view all bookings. It includes functionality for checking room availability, calculating the total price based on the number of nights, and sending notifications upon successful booking.

## Features

- **View Available Rooms**: Displays all rooms that are currently available.
- **Book a Room**: Allows customers to book a room by specifying their name, desired room number, check-in date, and check-out date.
- **View All Bookings**: Displays all existing bookings with booking details.
- **Booking Notifications**: Sends a notification whenever a booking is successfully made.

## Classes

### `Room`
Represents a room in the hotel, with properties like `RoomNumber`, `Type`, `Price`, and `IsAvailable`. It also includes a method to display room details.

### `Booking`
Represents a customer booking, including details like `BookingId`, `CustomerName`, `RoomNumber`, `CheckInDate`, `CheckOutDate`, and `TotalPrice`. It also includes a method to display booking details.

### `IBookingManager`
An interface that defines methods for booking rooms and viewing bookings.

### `HotelBase`
An abstract class containing lists for rooms and bookings.

### `HotelBookingManager`
A class that manages the booking process and contains logic for booking rooms, viewing available rooms, and viewing all bookings. It also handles notifications for successful bookings.

### `Program`
The main entry point of the application, providing a simple console interface for interacting with the system.

## Usage

Once the application is running, you can choose from the following options:

1. **View Available Rooms**: This option displays all the rooms that are available for booking.
2. **Book a Room**: This option allows you to book a room by entering your name, room number, check-in date, and check-out date.
3. **View All Bookings**: This option shows all the bookings made in the system.
4. **Exit**: This option closes the program.

## Example

1. View Available Rooms
2. Book a Room
3. View All Bookings
4. Exit
Select an option: 2
Enter your name: John Doe
Enter Room Number: 101
Enter Check-in Date (yyyy-mm-dd): 2025-02-01
Enter Check-out Date (yyyy-mm-dd): 2025-02-05
Booking confirmed. Total Price: $400
Notification: Booking successful for John Doe (Room: 101).
```

## Contributing

If you'd like to contribute to this project, feel free to fork the repository, make changes, and submit a pull request. Contributions are always welcome!

