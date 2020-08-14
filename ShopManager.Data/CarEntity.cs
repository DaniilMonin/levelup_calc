using System;

namespace ShopManager.Data
{
    public sealed class CarEntity : Entity
    {
        public string Mark { get; set; }
        public string Engine { get; set; }

        public int Year { get; set; }

        public int Age => DateTime.Now.Year - Year;
    }
}