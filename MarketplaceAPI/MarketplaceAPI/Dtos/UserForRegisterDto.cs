﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketplaceAPI.Dtos
{
    public class UserForRegisterDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
    }
}
