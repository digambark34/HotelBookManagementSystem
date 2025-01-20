using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Room
{
    public int Roomnumber { get; set; }
    public string Type { get; set; }
    public Decimal Price { get; set; }
    public bool Isavailable { get; set; }

    public void ShowRoomDetails()
    {
        Console.WriteLine($"Roomnumber : {Roomnumber} - Type : {Type} -  Price : {Price} - Isavailable : {Isavailable} ");
    }
}