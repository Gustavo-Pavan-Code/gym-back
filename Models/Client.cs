using GYM.Models.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace GYM.Models
{
    public class Client
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This PersonalIdentity is required")]
        [MaxLength(30, ErrorMessage = "This PersonalIdentity maxlength is 30")]
        public string PersonalIdentity { get; set; }
        [Required(ErrorMessage = "This NumberRegister is required")]
        [MaxLength(30, ErrorMessage = "This NumberRegister maxlength is 30")]
        public string NumberRegister { get; set; }
        public string Office { get; set; }
        [Required(ErrorMessage = "This Gender is required")]
        [MaxLength(10, ErrorMessage = "This Gender maxlength is 10")]
        public string Gender { get; set; }
        public DateTime BirthDay { get; set; }

        [Required(ErrorMessage = "This StatusAccount is required")]
        public StatusAccount StatusAccount { get; set; }
        [Required(ErrorMessage = "This Status is required")]
        public Status Status { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public Client()
        {
        }

        public Client(string personalIdentity, string numberRegister, string office, string gender, DateTime birthDay, StatusAccount statusAccount, Person person)
        {
            PersonalIdentity = personalIdentity;
            NumberRegister = numberRegister;
            Office = office;
            Gender = gender;
            BirthDay = birthDay;
            StatusAccount = statusAccount;
            Person = person;
        }
    }
}
