using GYM.Models;
using GYM.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYM.Data
{
    public class Seeding
    {
        private GYMContext _gym;

        public Seeding(GYMContext gym)
        {
            _gym = gym;
        }

        public void Seed()
        {
            if (
                _gym.AddressContext.Any() ||
                _gym.BranchContext.Any() ||
                _gym.ClientContext.Any() ||
                _gym.CompanyContext.Any() ||
                _gym.EmailContext.Any() ||
                _gym.EmployeeContext.Any() ||
                _gym.PersonContext.Any() ||
                _gym.ProviderContext.Any() ||
                _gym.TelephoneContext.Any()
               )
            {
                return; //Seeding created
            }

            Person p1 = new Person("Gustavo Pavan", StatusRegister.Enable);
            Person p2 = new Person("Marcela Pavan", StatusRegister.Enable);
            Person p3 = new Person("Murilo Furlan", StatusRegister.Enable);
            Person p4 = new Person("Marcelo SSilva", StatusRegister.Enable);

            Client cl1 = new Client("000000", "00000", "Fisic", "Men", Convert.ToDateTime("16/09/1992"), StatusAccount.Liberat, p1);
            Client cl2 = new Client("000000", "00000", "Fisic", "Men", Convert.ToDateTime("16/09/1992"), StatusAccount.Liberat, p2);

            Company cp1 = new Company("AIO", "aio@aio", "Piracicaba", "Novo Horizonte", "SP", "0909", "0909", "09090", DateTime.Now);
            Company cp2 = new Company("Smart", "Smart@Smart", "Piracicaba", "Novo Horizonte", "SP", "0909", "0909", "09090", DateTime.Now);

            Employee em1 = new Employee("00000", "00000", "Truck", "Men", DateTime.Now, "000", "000", "123", "900", "8", "Maria", "0", null, "Father", "000", "000", "asdf", "admin", "admin", null, DateTime.Now, DateTime.Now, Status.Offline, StatusAccount.Liberat, cp1, p1);

            Provider pr1 = new Provider("0909", "09090", "Wather", DateTime.Now, DateTime.Now, StatusRegister.Enable, p3);
            Provider pr2 = new Provider("0909", "09090", "Tools", DateTime.Now, DateTime.Now, StatusRegister.Disable, p4);

            Email email1 = new Email("aion@aion", p1);
            Email email2 = new Email("123@123", p1);
            Email email3 = new Email("543@533", p1);
            Address ad = new Address("teste", "nv", "123", null, "SP", "14", p2);
            Address ad1 = new Address("gos", "nv", "123", null, "SP", "14", p2);
            Telephone t1 = new Telephone("Mobile", "VIVO", "123123123", "SP", p1);
            Telephone t2 = new Telephone("Mobile", "VIVO", "123123123", "SP", p2);

            Branch branch1 = new Branch("Smart", "Smart@Smart", "Piracicaba", "Center", "SP", "090909", "09090990", "76767", DateTime.Now, StatusRegister.Enable, cp2);
            Branch branch2 = new Branch("Smart", "Smart@Smart", "Rio Claro", "Center", "SP", "090909", "09090990", "76767", DateTime.Now, StatusRegister.Enable, cp2);
            Branch branch3 = new Branch("Smart", "Smart@Smart", "São Pedro", "Center", "SP", "090909", "09090990", "76767", DateTime.Now, StatusRegister.Enable, cp2);

            _gym.PersonContext.AddRange(p1, p2, p3, p4);
            _gym.ClientContext.AddRange(cl1, cl2);
            _gym.CompanyContext.AddRange(cp1, cp2);
            _gym.EmployeeContext.AddRange(em1);
            _gym.ProviderContext.AddRange(pr1, pr2);
            _gym.EmailContext.AddRange(email1, email2, email3);
            _gym.AddressContext.AddRange(ad, ad1);
            _gym.TelephoneContext.AddRange(t1, t2);
            _gym.BranchContext.AddRange(branch1, branch2, branch3);

            _gym.SaveChanges();
        }
    }
}
