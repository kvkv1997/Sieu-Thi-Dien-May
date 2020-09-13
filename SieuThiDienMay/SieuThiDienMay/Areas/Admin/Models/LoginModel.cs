﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SieuThiDienMay.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mời bạn nhập User name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mời bạn nhập Password")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}