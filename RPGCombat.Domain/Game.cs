namespace RPGCombat.Domain
{
    public class Game
    {
        public static void Attack(Character attacker, decimal damage, Character target)
        {
            if (attacker.Id != target.Id && InRange(attacker, target))
            {
                target.ReceiveDamage(CalculateDamage(attacker, damage, target));
            }
        }

        private static bool InRange(Character attacker, Character target)
        {
            return Math.Sqrt(Math.Pow(attacker.X - target.X, 2) + Math.Pow(attacker.Y - target.Y, 2)) <=
                   attacker.Range;
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