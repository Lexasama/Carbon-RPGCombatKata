namespace RPGCombat.Domain.Things
{
    public class Tree : Thing
    {
        private const decimal MaxHealth = 2000m;

        public Tree()
        {
            Health = MaxHealth;
            Position = new Position(0, 0);
        }
    }
}