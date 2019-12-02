using GYM.Models.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace GYM.Models
{
    public class Provider
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This PersonalIdentity is required")]
        [MaxLength(30, ErrorMessage = "This PersonalIdentity maxlength is 30")]
        public string PersonalIdentity { get; set; }
        [Required(ErrorMessage = "This NumberRegister is required")]
        [MaxLength(30, ErrorMessage = "This NumberRegister maxlength is 30")]
        public string NumberRegister { get; set; }
        public string TypeProduct { get; set; }
        public DateTime LastVisit { get; set; }
        public DateTime FirstVisit { get; set; }
        [Required(ErrorMessage = "This StatusRegister is required")]
        public StatusRegister StatusRegister { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public Provider()
        {
        }

        public Provider(string personalIdentity, string numberRegister, string typeProduct, DateTime lastVisit, DateTime firstVisit, StatusRegister statusRegister, Person person)
        {
            PersonalIdentity = personalIdentity;
            NumberRegister = numberRegister;
            TypeProduct = typeProduct;
            LastVisit = lastVisit;
            FirstVisit = firstVisit;
            StatusRegister = statusRegister;
            Person = person;
        }
    }
}
