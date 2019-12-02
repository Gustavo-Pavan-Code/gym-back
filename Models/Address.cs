using System;
using System.ComponentModel.DataAnnotations;

namespace GYM.Models
{
    public class Address
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This Addresses is required")]
        [MaxLength(150, ErrorMessage = "This Addresses maxlength is 150")]
        public string Addresses { get; set; }
        [Required(ErrorMessage = "This District is required")]
        [MaxLength(150, ErrorMessage = "This District maxlength is 150")]
        public string District { get; set; }
        [Required(ErrorMessage = "This Number is required")]
        [MaxLength(10, ErrorMessage = "This Number maxlength is 10")]
        [MinLength(3, ErrorMessage = "This Number minlength is 1")]
        public string Number { get; set; }
        public string Complement { get; set; }
        [Required(ErrorMessage = "This State is required")]
        [MaxLength(50, ErrorMessage = "This State maxlength is 50")]
        [MinLength(3, ErrorMessage = "This State minlength is 2")]
        public string State { get; set; }
        public string YearLocal { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public Address()
        {
        }

        public Address(string addresses, string district, string number, string complement, string state, string yearLocal, Person person)
        {
            Addresses = addresses;
            District = district;
            Number = number;
            Complement = complement;
            State = state;
            YearLocal = yearLocal;
            Person = person;
        }
    }
}
