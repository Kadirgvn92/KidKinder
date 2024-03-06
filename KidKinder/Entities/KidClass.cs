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
    public string ImageUrl { get; set; }
    public DateTime CreatedDate { get; set; }
    public List<Booking> Bookings { get; set; }
    public List<Kid> Kids { get; set; }
    public List<Teacher> Teachers { get; set; }
}
