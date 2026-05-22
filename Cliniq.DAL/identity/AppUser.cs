using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cliniq.DAL.identity
{
    public class AppUser :IdentityUser
    {
        public string FullName { get; set; }

    }
}
