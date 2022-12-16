using RPGCombat.Domain.Characters;

namespace RPGCombat.Domain.Actions
{
    public class Heal
    {
        private readonly Character _healer;
        private readonly decimal _heal;
        private readonly ActionRules _rules;


        public Heal(Character healer, decimal heal, ActionRules rules)
        {
            _healer = healer;
            _heal = heal;
            _rules = rules;
        }


        public void On(Character wounded)
        {
            if (_rules.AreAllies(_healer, wounded) & wounded.Alive())
            {
                wounded.ReceiveHeal(_heal);
            }
        }
    }
}