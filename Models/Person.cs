using GYM.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GYM.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This Status is required")]
        public StatusRegister Status { get; set; }
        public ICollection<Email> Emails { get; set; }
        public ICollection<Address> Address { get; set; }
        public ICollection<Client> Clients { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Provider> Providers { get; set; }
        public ICollection<Telephone> Telephones { get; set; }
        public Person()
        {
        }
        public Person(string name, StatusRegister status)
        {
            Name = name;
            Status = status;
        }
    }
}
