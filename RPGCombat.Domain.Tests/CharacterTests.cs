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
        Assert.True(sut.Alive);
    }

    [Fact]
    public void can_deal_damage()
    {
        var attacker = Character.Create();
        var taker = Character.Create();
        var damage = 100m;
        attacker.Attack(damage, taker);

        Assert.Equal(StartingHealth - damage, taker.Health);
        Assert.True(taker.Alive);
    }

    [Fact]
    public void character_dies_when_HEALTH_is_ZERO()
    {
        var attacker = Character.Create();
        var taker = Character.Create();
        attacker.Attack(StartingHealth, taker);

        Assert.Equal(0, taker.Health);
        Assert.False(taker.Alive);
    }

    [Fact]
    public void character_can_Heal_character()
    {
        var healer = Character.Create();
        var wounded = Character.Create();
        var heal = 100m;
        healer.Attack(heal, wounded);

        healer.Heal(heal, wounded);

        Assert.Equal(StartingHealth, wounded.Health);
        Assert.True(wounded.Alive);
    }


    [Fact]
    public void character_can_NOT_heal_DEAD()
    {
        var healer = Character.Create();
        var wounded = Character.Create();
        var heal = 100m;
        healer.Attack(StartingHealth, wounded);

        healer.Heal(heal, wounded);

        Assert.Equal(0, wounded.Health);
        Assert.False(wounded.Alive);
    }

    [Fact]
    public void character_can_NOT_heal_above_maxHealth()
    {
        var healer = Character.Create();
        var wounded = Character.Create();
        var heal = 200m;
        healer.Attack(100, wounded);

        healer.Heal(heal, wounded);

        Assert.Equal(StartingHealth, wounded.Health);
        Assert.True(wounded.Alive);
    }
}