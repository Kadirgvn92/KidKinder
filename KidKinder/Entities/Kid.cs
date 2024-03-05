namespace KidKinder.Entities;

public class Kid
{
    public int KidID { get; set; }
    public string Name { get; set; }
    public short Age { get; set; }
    public int ParentID { get; set; }
    public Parent Parents { get; set; }
    public int KidClassID { get; set; }
    public KidClass Class { get; set; }
}
