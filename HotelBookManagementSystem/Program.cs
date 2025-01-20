using System;
using System.Collections.Generic;
using System.Linq;

public class Room
{
    public int RoomNumber { get; set; }
    public string Type { get; set; }
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; } = true;

    public void ShowRoomDetails()
    {
        Console.WriteLine($"Room Number: {RoomNumber} - Type: {Type} - Price: ${Price} - Available: {IsAvailable}");
    }
}

public class Booking
{
    public int BookingId { get; set; }
    public string CustomerName { get; set; }
    public int RoomNumber { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public decimal TotalPrice { get; set; }

    public void ShowBookingDetails()
    {
        Console.WriteLine($"Booking ID: {BookingId} - Customer Name: {CustomerName} - Room Number: {RoomNumber} - Check-in: {CheckInDate:yyyy-MM-dd} - Check-out: {CheckOutDate:yyyy-MM-dd} - Total Price: ${TotalPrice}");
    }
}

public interface IBookingManager
{
    void BookRoom(string customerName, int roomNumber, DateTime checkInDate, DateTime checkOutDate);

    void ViewBookings();
}

public abstract class HotelBase
{
    public List<Room> Rooms { get; set; } = new List<Room>();
    public List<Booking> Bookings { get; set; } = new List<Booking>();
}

public class HotelBookingManager : HotelBase, IBookingManager
{
    private int bookingIdCounter = 1;

    public delegate void BookingNotification(string message);

    public event BookingNotification OnBookingSuccess;

    public HotelBookingManager()
    {
        Rooms.AddRange(new[]
        {
            new Room { RoomNumber = 101, Type = "Single", Price = 100 },
            new Room { RoomNumber = 102, Type = "Double", Price = 150 },
            new Room { RoomNumber = 103, Type = "Suite", Price = 300 }
        });
    }

    public void ViewAvailableRooms()
    {
        Console.WriteLine("\nAvailable Rooms:");
        var availableRooms = Rooms.Where(r => r.IsAvailable).ToList();
        if (!availableRooms.Any())
        {
            Console.WriteLine("No rooms available.");
        }
        else
        {
            availableRooms.ForEach(r => r.ShowRoomDetails());
        }
    }

    public void BookRoom(string customerName, int roomNumber, DateTime checkInDate, DateTime checkOutDate)
    {
        var room = Rooms.FirstOrDefault(r => r.RoomNumber == roomNumber && r.IsAvailable);
        if (room == null)
        {
            Console.WriteLine("Room is not available.");
            return;
        }

        int days = (checkOutDate - checkInDate).Days;
        if (days <= 0)
        {
            Console.WriteLine("Invalid dates. Check-out date must be after check-in date.");
            return;
        }

        decimal totalPrice = room.Price * days;

        var newBooking = new Booking
        {
            BookingId = bookingIdCounter++,
            CustomerName = customerName,
            RoomNumber = roomNumber,
            CheckInDate = checkInDate,
            CheckOutDate = checkOutDate,
            TotalPrice = totalPrice
        };
        Bookings.Add(newBooking);

        room.IsAvailable = false;

        OnBookingSuccess?.Invoke($"Booking successful for {customerName} (Room: {roomNumber}).");

        Console.WriteLine($"Booking confirmed. Total Price: ${totalPrice}");
    }

    public void ViewBookings()
    {
        Console.WriteLine("\nBookings:");
        if (!Bookings.Any())
        {
            Console.WriteLine("No bookings found.");
        }
        else
        {
            Bookings.ForEach(b => b.ShowBookingDetails());
        }
    }
}

public class Program
{
    public static void Main()
    {
        var hotel = new HotelBookingManager();

        hotel.OnBookingSuccess += message => Console.WriteLine($"\nNotification: {message}");

        Console.WriteLine("Welcome to the Hotel Booking System!");
        while (true)
        {
            Console.WriteLine("\n1. View Available Rooms");
            Console.WriteLine("2. Book a Room");
            Console.WriteLine("3. View All Bookings");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    hotel.ViewAvailableRooms();
                    break;

                case "2":
                    Console.Write("Enter your name: ");
                    string customerName = Console.ReadLine();

                    Console.Write("Enter Room Number: ");
                    int roomNumber = int.Parse(Console.ReadLine());

                    Console.Write("Enter Check-in Date (yyyy-mm-dd): ");
                    DateTime checkInDate = DateTime.Parse(Console.ReadLine());

                    Console.Write("Enter Check-out Date (yyyy-mm-dd): ");
                    DateTime checkOutDate = DateTime.Parse(Console.ReadLine());

                    hotel.BookRoom(customerName, roomNumber, checkInDate, checkOutDate);
                    break;

                case "3":
                    hotel.ViewBookings();
                    break;

                case "4":
                    Console.WriteLine("Thank you for using the system!");
                    return;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}