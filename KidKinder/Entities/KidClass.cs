namespace KidKinder.Entities;

public class KidClass
{
    public int KidClassID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string AgeOfKids { get; set; }
    public byte TotalSeats { get; set; }
    public string ClassTime { get; set; }
    public decimal TutionFee { get; set; }
    public List<Booking> Bookings { get; set; }
}
