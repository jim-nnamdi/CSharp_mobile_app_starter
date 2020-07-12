using System;
namespace koleFramework.Models
{
    public class Company
    {
        //set the data-model for the application
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        // override the string for the list view

        public override string ToString()
        {
            return this.Name + "(" + this.Address + ")";
        }
    }
}
