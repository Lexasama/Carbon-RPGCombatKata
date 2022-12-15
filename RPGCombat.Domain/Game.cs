using RPGCombat.Domain.Characters;
using RPGCombat.Domain.Things;

namespace RPGCombat.Domain
{
    public class Game
    {
        public static void Attack(Character attacker, decimal damage, Character target)
        {
            if (attacker.Id != target.Id && InRange(attacker.Position, target.Position, attacker.Range) && !AreAllies(attacker, target))
            {
                target.ReceiveDamage(CalculateDamage(attacker, damage, target));
            }
        }

        public static void Attack(Character attacker, decimal damage, Thing target)
        {
            if (InRange(attacker.Position, target.Position, attacker.Range))
            {
                target.ReceiveDamage(damage);
            }
        }

        public static void Heal(Character healer, decimal heal, Character wounded)
        {
            if (AreAllies(healer, wounded) & wounded.Alive())
            {
                wounded.ReceiveHeal(heal);
            }
        }

        public static void Heal(Character healer, decimal heal)
        {
            healer.ReceiveHeal(heal);
        }

        private static bool AreAllies(Character attacker, Character target)
        {
            return attacker.Factions().Intersect(target.Factions()).Any();
        }
        
        private static bool InRange(Position attacker, Position target, int range)
        {
            return Math.Sqrt(Math.Pow(attacker.X - target.X, 2) + Math.Pow(attacker.Y - target.Y, 2)) <=
                   range;
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