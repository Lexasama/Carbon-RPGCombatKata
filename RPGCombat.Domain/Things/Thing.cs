﻿namespace RPGCombat.Domain.Things
{
    public abstract class Thing
    {
        public decimal Health { get; protected set; }
        public bool Alive;
        public Position Position { get; set; }

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
    }
}