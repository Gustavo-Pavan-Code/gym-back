using System;
using System.ComponentModel.DataAnnotations;

namespace GYM.Models
{
    public class Email
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This AddressEmail is required")]
        [MaxLength(180, ErrorMessage = "This AddressEmail maxlength is 180")]
        public string AddressEmail { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public Email()
        {
        }
        public Email(string addressEmail, Person person)
        {
            AddressEmail = addressEmail;
            Person = person;
        }
    }
}
