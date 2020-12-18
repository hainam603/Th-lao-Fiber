using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Audience
    {
        public string Secret { get; set; }
        public string Iss { get; set; }
        public string Aud { get; set; }

        public Audience()
        {
            Secret = "Y2F0Y2hlciUyMHdvbmclMjBsb3ZlJTIwLm5ldA==";
            Iss = "http://www.c-sharpcorner.com/members/catcher-wong";
            Aud = "Le Nam";
        }
    }
}
