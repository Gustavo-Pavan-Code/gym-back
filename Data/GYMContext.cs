using GYM.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYM.Data
{
    public class GYMContext : DbContext
    {
        public GYMContext(DbContextOptions<GYMContext> options) : base(options)
        {
        }

        protected GYMContext()
        {
        }
        public DbSet<Address> AddressContext{ get; set; }
        public DbSet<Client> ClientContext{ get; set; }
        public DbSet<Email> EmailContext{ get; set; }
        public DbSet<Employee> EmployeeContext{ get; set; }
        public DbSet<Person> PersonContext{ get; set; }
        public DbSet<Provider> ProviderContext{ get; set; }
        public DbSet<Telephone> TelephoneContext{ get; set; }
        public DbSet<Company> CompanyContext { get; set; }
        public DbSet<Branch> BranchContext { get; set; }
        public DbSet<Rule> RuleContext { get; set; }
        public DbSet<RulesProfiles> RulesProfilesContext{ get; set; }
        public DbSet<ProfileRule> ProfileRuleContext { get; set; }
    }
}
