namespace KidKinder.Areas.Admin.Models;

public class CreateTestimonialViewModel
{
    public string Name { get; set; }
    public string WhosParent { get; set; }
    public string Comment { get; set; }
    public string ImageUrl { get; set; }
    public IFormFile Image { get; set; }
}
