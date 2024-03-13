using Microsoft.Extensions.FileProviders;

namespace KidKinder.Areas.Admin.Models;

public class CreateImageViewModel
{
    public string ImageUrl { get; set; }
    public string ImageName { get; set; }
    public IFormFile Image { get; set; }
    public bool Status { get; set; }    
}
