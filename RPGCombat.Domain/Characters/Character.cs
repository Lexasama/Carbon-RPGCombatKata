namespace RPGCombat.Domain.Characters
{
    public class Character
    {
        private const decimal MaxHealth = 1000m;
        public decimal Health { get; private set; }
        public int Level;
        private bool _alive;
        public Guid Id;
        public int X => Position.X;
        public int Y => Position.Y;
        public int Range { get; protected init; }
        private readonly Factions _factions;

        public Position Position { get; set; }

        protected Character()
        {
            Health = MaxHealth;
            Level = 1;
            _alive = true;
            Id = Guid.NewGuid();
            Position = new Position(0, 0);
            _factions = new();
        }

        public bool Alive()
        {
            return Health > 0;
        }

        public static Character Create()
        {
            return new Character();
        }

        public void ReceiveDamage(decimal damage)
        {
            Health -= damage;

            if (Health <= 0)
            {
                Health = 0m;
                _alive = false;
            }
        }

        public void Join(string faction)
        {
            _factions.Join(faction);
        }

        public void Leave(string faction)
        {
            _factions.Leave(faction);
        }

        public void ReceiveHeal(decimal heal)
        {
            if (!_alive)
            {
                return;
            }

            Health += heal;
            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }
        }

        public HashSet<string> Factions()
        {
            return _factions.GetFactions();
        }
    }
}