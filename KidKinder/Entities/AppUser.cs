﻿using Microsoft.AspNetCore.Identity;

namespace KidKinder.Entities;

public class AppUser : IdentityUser<int>
{
    public string Name { get; set; }
    public string Surname { get; set; }
}
