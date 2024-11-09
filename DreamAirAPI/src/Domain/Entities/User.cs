﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public abstract class User
    {
        public int Id {  get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string Role { get; set; } = "client";

        public string Name { get; set; }

        public string LastName { get; set; } = " ";
    }
}
