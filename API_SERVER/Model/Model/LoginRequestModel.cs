using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Model
{
    public class LoginRequestModel
    {
        [Required]
        public string ma_ND { get; set; }
        [Required]
        public string Matkhau { get; set; }
    }
}
