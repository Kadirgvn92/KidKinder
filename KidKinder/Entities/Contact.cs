namespace KidKinder.Entities;

public class Contact
{
    public int ContactID { get; set; }
    public string Name { get; set; }
    public string Mail { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
    public bool IsRead { get; set; }
}
