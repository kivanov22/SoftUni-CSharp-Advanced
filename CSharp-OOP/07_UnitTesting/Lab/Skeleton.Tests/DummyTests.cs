using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private Dummy dummy;
    private Dummy deadDummy;
    private int health = 5;
    private int experience = 10;

    [SetUp]
    public void SetUp()
    {
        dummy = new Dummy(health, experience);
        deadDummy = new Dummy(-5, experience);
    }
    [Test]
    public void When_Attacked_ShouldDecreaseHealth()
    {

        int attackPoints = 3;
        dummy.TakeAttack(attackPoints);
        Assert.That(dummy.Health, Is.EqualTo(health - attackPoints), "Dummy doesn't lose health when attacked");

    }
    [Test]
    public void When_AttackedDeadDummy_ThrowsException()
    {
        Assert.That(() =>
        {
            deadDummy.TakeAttack(3);
        }, Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
    }
    [Test]
    public void When_Dead_DummyCanGiveXp()
    {
        Assert.That(deadDummy.GiveExperience(), Is.EqualTo(experience));
    }
    [Test]
    public void When_AliveGiveExperience_ShouldThrowException()
    {
        Assert.That(() => { dummy.GiveExperience(); }, Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
    }
}

