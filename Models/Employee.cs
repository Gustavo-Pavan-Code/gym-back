using GYM.Models.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace GYM.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This PersonalIdentity is required")]
        [MaxLength(30, ErrorMessage = "This PersonalIdentity maxlength is 30")]
        public string PersonalIdentity { get; set; }
        [Required(ErrorMessage = "This Name is required")]
        [MaxLength(30, ErrorMessage = "This Name maxlength is 30")]
        public string NumberRegister { get; set; }
        public string Office { get; set; }
        [Required(ErrorMessage = "This Gender is required")]
        public string Gender { get; set; }
        public DateTime BirthDay { get; set; }
        public string Pis { get; set; }
        public string NumberWallet { get; set; }
        public string DateRegister { get; set; }
        public string Salary { get; set; }
        public string HoursPerDay { get; set; }
        public string NameMother { get; set; }
        public string Bonus { get; set; }
        public string TypeBonus { get; set; }
        public string NameFather { get; set; }
        public string Reservist { get; set; }
        public string TitleVoter { get; set; }
        public string Photo { get; set; }
        [Required(ErrorMessage = "This Name is required")]
        [MaxLength(30, ErrorMessage = "This Name maxlength is 30")]
        public string UserLogin { get; set; }
        [Required(ErrorMessage = "This Password is required")]
        [MaxLength(255, ErrorMessage = "This Password maxlength is 30")]
        public string Password { get; set; }
        public string Token { get; set; }
        public Nullable<DateTime> Expiration { get; set; }
        public DateTime LastLogin { get; set; }
        public Status Status { get; set; }
        public StatusAccount StatusAccount { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public Employee()
        {
        }

        public Employee(string personalIdentity, string numberRegister, string office, string gender, DateTime birthDay, string pis, string numberWallet, string dateRegister, string salary, string hoursPerDay, string nameMother, string bonus, string typeBonus, string nameFather, string reservist, string titleVoter, string photo, string userLogin, string password, string token, DateTime? expiration, DateTime? lastLogin, Status status, StatusAccount statusAccount, Company company, Person person)
        {
            PersonalIdentity = personalIdentity;
            NumberRegister = numberRegister;
            Office = office;
            Gender = gender;
            BirthDay = birthDay;
            Pis = pis;
            NumberWallet = numberWallet;
            DateRegister = dateRegister;
            Salary = salary;
            HoursPerDay = hoursPerDay;
            NameMother = nameMother;
            Bonus = bonus;
            TypeBonus = typeBonus;
            NameFather = nameFather;
            Reservist = reservist;
            TitleVoter = titleVoter;
            Photo = photo;
            UserLogin = userLogin;
            Password = password;
            Token = token;
            Expiration = expiration.Value;
            LastLogin = lastLogin.Value;
            Status = status;
            StatusAccount = statusAccount;
            Company = company;
            Person = person;
        }
        //Generate char randon
        private char GenerateRandonChar()
        {
            Random random = new Random();
            int opt = random.Next(3);
            if (opt == 0)
            {
                //Number
                return (char)(random.Next(10) + 48);
            }
            else if (opt == 1)
            {
                //Letter Upper
                return (char)(random.Next(26) + 65);
            }
            else
            {
                //Letter Lower
                return (char)(random.Next(26) + 97);
            }
        }
        //Generate token with 80 char
        public string GenerateToken()
        {
            string str = null;
            for (int i = 0; i < 80; i++)
            {
                str += GenerateRandonChar();
            }
            return str;
        }
        //Encrypt password
        public string EncryptHash(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte [] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes("AIO" + password + "SECURITY"));
                StringBuilder str = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    str.Append(bytes[i].ToString("x2"));
                }
                return str.ToString();
            }
        }
        //Expirtation token for not access system
        public DateTime ExpirationToken()
        {
            return DateTime.Now.AddHours(24); 
        }
       
    }
}
