﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace test6.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the test6User class
    public class test6User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
