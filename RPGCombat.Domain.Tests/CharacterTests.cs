using RPGCombat.Domain.Actions;
using RPGCombat.Domain.Characters;

namespace RPGCombat.Domain.Tests;

public class CharacterTests
{
    private const decimal StartingHealth = 1000m;
    private const int StartingLevel = 1;

    [Fact]
    public void can_create_character_with_default_value()
    {
        var sut = Character.Create();

        Assert.Equal(StartingHealth, sut.Health);
        Assert.Equal(StartingLevel, sut.Level);
        Assert.True(sut.Alive());
    }


    [Fact]
    public void character_dies_when_HEALTH_is_ZERO()
    {
        var attacker = Character.Create();
        var target = Character.Create();
        var rules = new ActionRules(new List<Faction> { new() });
        var attack = new Attack(attacker, StartingHealth, rules);

        attack.On(target);
        Assert.Equal(0, target.Health);
        Assert.False(target.Alive());
    }

    [Fact]
    public void character_can_Heal_self()
    {
        var healer = Character.Create();
        var wounded = Character.Create();
        const decimal healValue = 100m;
        var rules = new ActionRules(new List<Faction> { new() });
        var attack = new Attack(healer, healValue, rules);

        attack.On(wounded);

        wounded.ReceiveHeal(healValue);

        Assert.Equal(StartingHealth, wounded.Health);
        Assert.True(wounded.Alive());
    }


    [Fact]
    public void character_can_NOT_heal_DEAD()
    {
        var healer = Character.Create();
        var wounded = Character.Create();
        const decimal heal = 100m;
        var rules = new ActionRules(new List<Faction> { new() });
        var attack = new Attack(healer, StartingHealth, rules);

        attack.On(wounded);
        wounded.ReceiveHeal(heal);

        Assert.Equal(0, wounded.Health);
        Assert.False(wounded.Alive());
    }

    [Fact]
    public void character_can_NOT_heal_above_maxHealth()
    {
        var healer = Character.Create();
        var wounded = Character.Create();
        const decimal heal = 200m;
        var rules = new ActionRules(new List<Faction> { new() });
        var attack = new Attack(healer, 100m, rules);
        attack.On(wounded);

        wounded.ReceiveHeal(heal);

        Assert.Equal(StartingHealth, wounded.Health);
        Assert.True(wounded.Alive());
    }
}