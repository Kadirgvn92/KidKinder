namespace KidKinder.Models;

public class UpdateTestimonialViewModel
{
    public int TestimonialID { get; set; }
    public string Name { get; set; }
    public string WhosParent { get; set; }
    public string Comment { get; set; }
    public string ImageUrl { get; set; }
    public IFormFile Image { get; set; }
}
