using NUnit.Framework;
using Skeleton.Tests.Contracts;
using Skeleton.Tests.Fake;

[TestFixture]
public class HeroTests
{
    [Test]
    public void When_TargetDies_HeroShouldReceiveExperience()
    {
        //IWeapon fakeWeapon = new FakeWeapon();
        //ITarget fakeTarget = new FakeTarget();
        FakeTarget target = new FakeTarget();
        FakeWeapon weapon = new FakeWeapon();

        Hero hero = new Hero("Konan", weapon);

        hero.Attack(target);

        Assert.That(hero.Experience, Is.EqualTo(20));

    }
}