namespace RPGCombat.Domain.Tests
{
    public class GameTests
    {
        private const decimal StartingHealth = 1000m;
        
        [Fact]
        public void can_deal_damage()
        {
            var attacker = Character.Create();
            var damage = 100m;
            var target = Character.Create();
            Game.Attack(attacker, damage, target);


            Assert.Equal(StartingHealth - damage, target.Health);
            Assert.True(attacker.Alive);
        }

        [Fact]
        public void can_NOT_deal_damage_to_self()
        {
            var attacker = Character.Create();
            var damage = 100m;


            Game.Attack(attacker, damage, attacker);

            Assert.Equal(StartingHealth, attacker.Health);
            Assert.True(attacker.Alive);
        }

        [Fact]
        public void can_apply_damage_bonus()
        {
            var attacker = Character.Create();
            attacker.Level = 10;
            var target = Character.Create();
            var damage = 100m;

            Game.Attack(attacker, damage, target);

            Assert.Equal(StartingHealth - damage * 1.5m, target.Health);
            Assert.True(target.Alive);
        }

        [Fact]
        public void can_apply_damage_reduction()
        {
            var attacker = Character.Create();
            var target = Character.Create();
            target.Level = 10;
            var damage = 100m;

            Game.Attack(attacker, damage, target);

            Assert.Equal(StartingHealth - damage * 0.5m, target.Health);
            Assert.True(target.Alive);
        }
    }
}