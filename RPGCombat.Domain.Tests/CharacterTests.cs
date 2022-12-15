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
        var game = new Game();
        Game.Attack(attacker, StartingHealth, target);

        Assert.Equal(0, target.Health);
        Assert.False(target.Alive());
    }

    [Fact]
    public void character_can_Heal_self()
    {
        var healer = Character.Create();
        var wounded = Character.Create();
        var heal = 100m;
        Game.Attack(healer, heal, wounded);

        wounded.ReceiveHeal(heal);

        Assert.Equal(StartingHealth, wounded.Health);
        Assert.True(wounded.Alive());
    }


    [Fact]
    public void character_can_NOT_heal_DEAD()
    {
        var healer = Character.Create();
        var wounded = Character.Create();
        var heal = 100m;
        Game.Attack(healer, StartingHealth, wounded);

        wounded.ReceiveHeal(heal);

        Assert.Equal(0, wounded.Health);
        Assert.False(wounded.Alive());
    }

    [Fact]
    public void character_can_NOT_heal_above_maxHealth()
    {
        var healer = Character.Create();
        var wounded = Character.Create();
        var heal = 200m;
        Game.Attack(healer, heal, wounded);

        wounded.ReceiveHeal(heal);

        Assert.Equal(StartingHealth, wounded.Health);
        Assert.True(wounded.Alive());
    }
}