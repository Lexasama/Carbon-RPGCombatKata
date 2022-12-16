using RPGCombat.Domain.Actions;
using RPGCombat.Domain.Characters;
using RPGCombat.Domain.Things;

namespace RPGCombat.Domain.Tests
{
    public class ActionTests
    {
        private const decimal StartingHealth = 1000m;

        [Fact]
        public void can_deal_damage()
        {
            var attacker = Character.Create();
            const decimal damage = 100m;
            var target = Character.Create();
            var rules = new ActionRules(new List<Faction> { new() });
            var attack = new Attack(attacker, 100m, rules);

            attack.On(target);

            Assert.Equal(StartingHealth - damage, target.Health);
            Assert.True(attacker.Alive());
        }

        [Fact]
        public void can_NOT_deal_damage_to_self()
        {
            var attacker = Character.Create();
            var rules = new ActionRules(new List<Faction> { new() });
            var attack = new Attack(attacker, StartingHealth, rules);

            attack.On(attacker);

            Assert.Equal(StartingHealth, attacker.Health);
            Assert.True(attacker.Alive());
        }

        [Fact]
        public void can_apply_damage_bonus()
        {
            var attacker = Character.Create();
            attacker.Level = 10;
            var target = Character.Create();
            const decimal damage = 100m;

            var rules = new ActionRules(new List<Faction> { new() });
            var attack = new Attack(attacker, damage, rules);

            attack.On(target);

            Assert.Equal(StartingHealth - damage * 1.5m, target.Health);
            Assert.True(target.Alive());
        }

        [Fact]
        public void can_apply_damage_reduction()
        {
            var attacker = Character.Create();
            var target = Character.Create();
            target.Level = 10;
            const decimal damage = 100m;

            var rules = new ActionRules(new List<Faction> { new() });
            var attack = new Attack(attacker, damage, rules);

            attack.On(target);

            Assert.Equal(StartingHealth - damage * 0.5m, target.Health);
            Assert.True(target.Alive());
        }

        [Fact]
        public void MeleeFighter_can_NOT_damage_OUT_OF_RANGE_target()
        {
            var attacker = new MeleeFighter();
            var target = Character.Create();
            target.Position = new Position(10, 10);
            target.Level = 10;
            const decimal damage = 100m;

            var rules = new ActionRules(new List<Faction> { new() });
            var attack = new Attack(attacker, damage, rules);

            attack.On(target);

            Assert.Equal(StartingHealth, target.Health);
            Assert.True(target.Alive());
        }

        [Fact]
        public void RangeFighter_can_NOT_damage_OUT_OF_RANGE_target()
        {
            var attacker = new RangedFighter();
            var target = Character.Create();
            target.Position = new Position(100, 100);
            target.Level = 10;

            var rules = new ActionRules(new List<Faction> { new() });
            var attack = new Attack(attacker, StartingHealth, rules);

            attack.On(target);

            Assert.Equal(StartingHealth, target.Health);
            Assert.True(target.Alive());
        }

        [Fact]
        public void Allies_can_Heal_each_other()
        {
            var allie1 = new MeleeFighter();
            var allie2 = new MeleeFighter();
            var fighter = new MeleeFighter();
            var faction = new Faction();
            faction.Enroll(allie1);
            faction.Enroll(allie2);
            var rules = new ActionRules(new List<Faction> { faction });

            var attack = new Attack(fighter, 100m, rules);
            attack.On(allie2);

            var healingAction = new Heal(allie1, 100m, rules);
            healingAction.On(allie2);


            Assert.Equal(StartingHealth, allie2.Health);
        }

        [Fact]
        public void NON_Allies_can_NOT_Heal_each_other()
        {
            var allie1 = new MeleeFighter();
            var fighter = new MeleeFighter();

            var faction = new Faction();
            faction.Enroll(allie1);
            var rules = new ActionRules(new List<Faction> { faction });
            const decimal damage = 100m;
            var attack = new Attack(fighter, damage, rules);
            attack.On(allie1);
            var healingAction = new Heal(fighter, 100m, rules);

            healingAction.On(allie1);

            Assert.Equal(StartingHealth - damage, allie1.Health);
        }

        [Fact]
        public void can_attack_a_tree()
        {
            var attacker = new RangedFighter();
            const decimal damage = 100000m;
            var tree = new Tree();

            var rules = new ActionRules();
            var attack = new Attack(attacker, damage, rules);
            attack.On(tree);

            Assert.Equal(0, tree.Health);
            Assert.False(tree.Alive);
        }
    }
}