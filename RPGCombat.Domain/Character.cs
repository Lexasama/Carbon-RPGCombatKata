namespace RPGCombat.Domain
{
    public class Character
    {
        private const decimal MaxHealth = 1000m;
        public decimal Health;
        public int Level;
        public bool Alive;
        public Guid Id;


        private Character(decimal health, int level, bool alive)
        {
            Health = health;
            Level = level;
            Alive = alive;
            Id = Guid.NewGuid();
        }


        public static Character Create()
        {
            return new Character(1000m, 1, true);
        }

        public void ReceiveDamage(decimal damage)
        {
            if (damage >= Health)
            {
                Health = 0m;
                Alive = false;
                return;
            }

            Health -= damage;
        }

        public void Heal(decimal heal)
        {
            if (!Alive)
            {
                return;
            }

            Health += heal;
            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }
        }
    }
}