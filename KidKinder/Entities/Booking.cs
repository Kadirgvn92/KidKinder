namespace KidKinder.Entities;

public class Booking
{
    public int BookingID { get; set; }
    public string? Name { get; set; }
    public string? Mail { get; set; }
    public string? Phone { get; set; }
    public bool IsCompleted { get; set; }
    public int ClassID {  get; set; }
    public KidClass? Class { get; set; }
}
