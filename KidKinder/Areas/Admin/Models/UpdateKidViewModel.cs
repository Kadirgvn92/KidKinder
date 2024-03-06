using KidKinder.Entities;

namespace KidKinder.Areas.Admin.Models;

public class UpdateKidViewModel
{
    public int KidID { get; set; }
    public string Name { get; set; }
    public short Age { get; set; }
    public DateTime RegisterDate { get; set; }
    public int ParentID { get; set; }
    public int KidClassID { get; set; }
}
