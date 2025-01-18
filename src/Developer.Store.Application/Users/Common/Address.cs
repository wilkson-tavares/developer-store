using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Users.Common
{
    public class Address
    {
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public int Number { get; set; }
        public string Zipcode { get; set; } = string.Empty;
        public Geolocation Geolocation { get; set; } = new Geolocation();
    }
}
