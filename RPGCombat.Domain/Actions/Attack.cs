using RPGCombat.Domain.Characters;
using RPGCombat.Domain.Things;

namespace RPGCombat.Domain.Actions
{
    public class Attack
    {
        private readonly Character _attacker;
        private readonly decimal _damage;
        private readonly ActionRules _rules;

        public Attack(Character attacker, decimal damage, ActionRules rules)
        {
            _attacker = attacker;
            _damage = damage;
            _rules = rules;
        }

        public void On(Thing target)
        {
            if (_rules.InRange(_attacker.Position, target.Position, _attacker.Range))
            {
                target.ReceiveDamage(_damage);
            }
        }

        public void On(Character target)
        {
            if (_attacker.Id != target.Id && _rules.InRange(_attacker.Position, target.Position, _attacker.Range) &&
                !_rules.AreAllies(_attacker, target))
            {
                target.ReceiveDamage(CalculateDamage(_attacker, _damage, target));
            }
        }


        private static decimal CalculateDamage(Character attacker, decimal damage, Character target)
        {
            if (target.Level - attacker.Level >= 5)
            {
                return damage / 2;
            }

            if (attacker.Level - target.Level >= 5)
            {
                return damage * 1.5m;
            }

            return damage;
        }
    }
}