using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Room
{
    public int RoomNumber { get; set; }
    public string Type { get; set; }
    public Decimal Price { get; set; }
    public bool IsAvailable { get; set; }

    public void ShowRoomDetails()
    {
        Console.WriteLine($"Roomnumber : {RoomNumber} - Type : {Type} -  Price : {Price} - Isavailable : {IsAvailable} ");
    }
}

public class Booking
{
    public int BookingId { get; set; }
    public string CustomerName { get; set; }
    public int RoomNumber { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public Decimal TotalPrice { get; set; }

    public void ShowBookingDetails()
    {
        Console.WriteLine($"BookingID : {BookingId} - CustomerName : {CustomerName} - RoomNumber : {RoomNumber} CheckIndate : {CheckInDate} - CheckOutDate : {CheckOutDate} - TotalPrice : {TotalPrice} ");
    }
}

public interface IBookingManager
{
    void BookRoom(String CustomerName, int RoomNumber, DateTime CheckINDate, DateTime CheckOutDate);

    void ViewBookings();
}

public abstract class HotelBase
{
    public List<Room> Rooms { get; set; }
    public List<Booking> Bookings { get; set; }
}

public class HotelBookingManager : HotelBase, IBookingManager
{
    private int BookingIdCounter = 1;

    public delegate void BookingNotification(string Message);

    public event BookingNotification onBookingsucess;

    public HotelBookingManager()
    {
    }
}