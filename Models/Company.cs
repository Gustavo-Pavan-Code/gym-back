using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GYM.Models
{
    public class Company
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This Name is required")]
        [MaxLength(255, ErrorMessage = "This Name maxlength is 255")]
        [MinLength(3, ErrorMessage = "This Name minlength is 3")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This Email is required")]
        [MaxLength(120, ErrorMessage = "This Email maxlength is 120")]
        public string Email { get; set; }
        [Required(ErrorMessage = "This City is required")]
        [MaxLength(150, ErrorMessage = "This City maxlength is 150")]
        public string City { get; set; }
        [Required(ErrorMessage = "This District is required")]
        [MaxLength(150, ErrorMessage = "This District maxlength is 150")]
        public string District { get; set; }
        [Required(ErrorMessage = "This State is required")]
        [MaxLength(150, ErrorMessage = "This State maxlength is 150")]
        public string State { get; set; }
        [Required(ErrorMessage = "This PersonalIdentity is required")]
        [MaxLength(30, ErrorMessage = "This PersonalIdentity maxlength is 30")]
        public string PersonalIdentity { get; set; }
        [Required(ErrorMessage = "This NumberRegister is required")]
        [MaxLength(30, ErrorMessage = "This NumberRegister maxlength is 30")]
        public string NumberRegister { get; set; }
        [Required(ErrorMessage = "This Telephone is required")]
        [MaxLength(15, ErrorMessage = "This Telephone maxlength is 15")]
        public string Telephone { get; set; }
        public DateTime Fundation { get; set; }
        public ICollection<Branch> Branches { get; set; }
        public Company()
        {
        }

        public Company(string name, string email, string city, string district, string state, string personalIdentity, string numberRegister, string telephone, DateTime fundation)
        {
            Name = name;
            Email = email;
            City = city;
            District = district;
            State = state;
            PersonalIdentity = personalIdentity;
            NumberRegister = numberRegister;
            Telephone = telephone;
            Fundation = fundation;
        }
    }
}
