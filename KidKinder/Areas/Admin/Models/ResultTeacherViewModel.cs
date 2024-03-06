using KidKinder.Entities;

namespace KidKinder.Areas.Admin.Models;

public class ResultTeacherViewModel
{
    public int TeacherID { get; set; }
    public string Name { get; set; }
    public string Branch { get; set; }
    public string FacebookUrl { get; set; }
    public string InstagramUrl { get; set; }
    public string LinkedinUrl { get; set; }
}
