namespace KidKinder.Entities;

public class Parent
{
    public int ParentID { get; set; }
    public string Name { get; set; }
    public string Mail { get; set; }
    public string Phone { get; set; }
    public string? SecondPhone { get; set; }
    public string? TotalDebt { get; set; }
    public string? DebtDescription { get; set; }
    public string Address { get; set; }
    public List<Kid> Kids { get; set; }
}
