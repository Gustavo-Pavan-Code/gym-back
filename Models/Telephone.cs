using System.ComponentModel.DataAnnotations;

namespace GYM.Models
{
    public class Telephone
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This TypeTelephone is required")]
        public string TypeTelephone { get; set; }
        public string Carrier { get; set; }
        [Required(ErrorMessage = "This AddressEmail is required")]
        [MaxLength(180, ErrorMessage = "This AddressEmail maxlength is 180")]
        public string Number { get; set; }
        public string State { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public Telephone()
        {
        }

        public Telephone(string typeTelephone, string carrier, string number, string state, Person person)
        {
            TypeTelephone = typeTelephone;
            Carrier = carrier;
            Number = number;
            State = state;
            Person = person;
        }
    }
}
