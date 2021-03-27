using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    private int attack = 5;
    private int durability = 6;
    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void SetUp()
    {
        axe = new Axe(attack, durability);
        dummy = new Dummy(5, 6);
    }
    [Test]
    public void When_Attacked_LoseDurability()
    {
        axe.Attack(dummy);
        Assert.AreEqual(durability-1,axe.DurabilityPoints);
    }
    [Test]
    public void When_AxeAttackAndDurabilityProvided_ShouldbeSetCorrectly()
    {
        Assert.AreEqual(axe.AttackPoints, attack);
        Assert.AreEqual(axe.DurabilityPoints, durability);

    }
    [Test]
    public void When_AttackedWithDurabilityPointsZero_ShouldThrowException()
    {
        dummy = new Dummy(5000, 5000);
        //axe is broken
        InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
        {
            for (int i = 0; i < 7; i++)
            {
                axe.Attack(dummy);
            }
        });
        Assert.That(ex.Message, Is.EqualTo("Axe is broken."));
        //dummy dead
        Assert.That(() =>
        {
            for (int i = 0; i < 7; i++)
            {
                axe.Attack(dummy);
            }
        }, Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
    }
}
//[Test]
    //public void AxeLosesDurabilityAfterAttack()
    //{
    //    Axe axe = new Axe(10, 10);
    //    Dummy dummy = new Dummy(10, 10);

    //    axe.Attack(dummy);

    //    Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe durability doesn't change after attack.");
    //}
    //[Test]
    //public void BrokenAxeCantAttack()
    //{
    //    Axe axe = new Axe(1, 1);
    //    Dummy dummy = new Dummy(10, 10);

    //    axe.Attack(dummy);

    //    Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
    //}