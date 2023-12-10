﻿using Microsoft.AspNetCore.Identity;

namespace User.API.Entities
{
    public class User: IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
