namespace RPGCombat.Domain
{
    public class Character
    {
        private const decimal MaxHealth = 1000m;
        public decimal Health;
        public int Level;
        public bool Alive;


        private Character(decimal health, int level, bool alive)
        {
            Health = health;
            Level = level;
            Alive = alive;
        }


        public static Character Create()
        {
            return new Character(1000m, 1, true);
        }

        public void Attack(decimal damage, Character character)
        {
            character.ReceiveDamage(damage);
        }

        private void ReceiveDamage(decimal damage)
        {
            if (damage >= Health)
            {
                Health = 0m;
                Alive = false;
                return;
            }

            Health -= damage;
        }

        public void Heal(decimal heal, Character character)
        {
            if (character.Alive)
            {
                character.ReceiveHeal(heal);
            }
        }

        private void ReceiveHeal(decimal heal)
        {
            Health += heal;
            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }
        }
    }
}