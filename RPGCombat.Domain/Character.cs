namespace RPGCombat.Domain
{
    public class Character : IMovable 
    {
        private const decimal MaxHealth = 1000m;
        public decimal Health;
        public int Level;
        public bool Alive;
        public Guid Id;
        public Position Position { get; set; }
        public int X => Position.X;
        public int Y => Position.Y;
        public virtual int Range { get; set; }
        
        public List<string> Factions { get; }

        public Character()
        {
            Health = MaxHealth;
            Level = 1;
            Alive = true;
            Id = Guid.NewGuid();
            Position = new(0, 0);
            Factions = new();
        }

        public static Character Create()
        {
            return new Character();
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