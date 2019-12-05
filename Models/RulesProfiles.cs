namespace GYM.Models
{
    public class RulesProfiles
    {
        public int Id { get; set; }
        public int  PersonId{ get; set; }
        public Person Person { get; set; }
        public int RuleId { get; set; }
        public Rule Rule { get; set; }
        public int ProfileRuleId { get; set; }
        public ProfileRule ProfileRule { get; set; }
        public RulesProfiles()
        {
        }
        public RulesProfiles(Person person, Rule rule, ProfileRule profileRule)
        {
            Person = person;
            Rule = rule;
            ProfileRule = profileRule;
        }
    }
}
