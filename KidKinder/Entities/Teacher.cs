namespace KidKinder.Entities;

public class Teacher
{
    public int TeacherID { get; set; }
    public string Name { get; set; }
    public string Branch { get; set; }
    public string ImageUrl { get; set; }
    public string FacebookUrl { get; set; }
    public string InstagramUrl { get; set; }
    public string LinkedinUrl { get; set; }
    public int KidClassID { get; set; }
    public KidClass Class { get; set; }
}
