namespace KidKinder.Areas.Admin.Models;

public class UpdateTeacherViewModel
{
    public int TeacherID { get; set; }
    public string Name { get; set; }
    public string Branch { get; set; }
    public string ImageUrl { get; set; }
    public string FacebookUrl { get; set; }
    public string InstagramUrl { get; set; }
    public string LinkedinUrl { get; set; }
    public int KidClassID { get; set; }
    public IFormFile Image { get; set; }
}
