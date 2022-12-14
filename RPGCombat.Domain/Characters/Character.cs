namespace RPGCombat.Domain.Characters
{
    public class Character : IDamagable, IHealable, IEnrollable, IMovable
    {
        private const decimal MaxHealth = 1000m;
        public decimal Health { get; private set; }
        public int Level;
        public bool Alive;
        public Guid Id;
        public Position Position { get; set; }
        public int X => Position.X;
        public int Y => Position.Y;
        public virtual int Range { get; set; }
        private HashSet<string> _factions;

        public Character()
        {
            Health = MaxHealth;
            Level = 1;
            Alive = true;
            Id = Guid.NewGuid();
            Position = new(0, 0);
            _factions = new();
        }

        public HashSet<string> Factions()
        {
            return _factions;
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

        public void Join(string faction)
        {
            _factions.Add(faction);
        }

        public void Leave(string faction)
        {
            _factions.Remove(faction);
        }

        public void ReceiveHeal(decimal heal)
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