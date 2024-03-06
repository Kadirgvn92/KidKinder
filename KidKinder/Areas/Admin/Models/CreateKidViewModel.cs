using KidKinder.Entities;

namespace KidKinder.Areas.Admin.Models;

public class CreateKidViewModel
{
    public string Name { get; set; }
    public short Age { get; set; }
    public DateTime RegisterDate { get; set; }
    public int ParentID { get; set; }
    public int KidClassID { get; set; }
}
