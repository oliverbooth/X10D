using System.Reflection;
using NUnit.Framework;
using X10D.Reflection;

namespace X10D.Tests.Reflection;

[TestFixture]
public class MemberInfoTests
{
    [Test]
    public void HasCustomAttribute_ShouldBeTrue_GivenCLSCompliantAttributeOnUnsignedTypes()
    {
        Assert.That(typeof(sbyte).HasCustomAttribute(typeof(CLSCompliantAttribute))); // okay, sbyte is signed. I know.
        Assert.That(typeof(ushort).HasCustomAttribute(typeof(CLSCompliantAttribute)));
        Assert.That(typeof(uint).HasCustomAttribute(typeof(CLSCompliantAttribute)));
        Assert.That(typeof(ulong).HasCustomAttribute(typeof(CLSCompliantAttribute)));
    }

    [Test]
    public void HasCustomAttribute_ShouldBeTrue_GivenCLSCompliantAttributeOnUnsignedTypes_Generic()
    {
        Assert.That(typeof(sbyte).HasCustomAttribute<CLSCompliantAttribute>()); // seriously don't @ me
        Assert.That(typeof(ushort).HasCustomAttribute<CLSCompliantAttribute>());
        Assert.That(typeof(uint).HasCustomAttribute<CLSCompliantAttribute>());
        Assert.That(typeof(ulong).HasCustomAttribute<CLSCompliantAttribute>());
    }

    [Test]
    public void HasCustomAttribute_ShouldThrow_GivenNull()
    {
        Type type = null!;
        Assert.Throws<ArgumentNullException>(() => _ = type.HasCustomAttribute<CLSCompliantAttribute>());
        Assert.Throws<ArgumentNullException>(() => _ = type.HasCustomAttribute(typeof(CLSCompliantAttribute)));
        Assert.Throws<ArgumentNullException>(() => _ = typeof(object).HasCustomAttribute(null!));
    }

    [Test]
    public void HasCustomAttribute_ShouldThrow_GivenNonAttribute()
    {
        Assert.Throws<ArgumentException>(() => _ = typeof(object).HasCustomAttribute(typeof(object)));
    }

    [Test]
    public void SelectFromCustomAttribute_ShouldBeFalse_GivenCLSCompliantAttributeOnUnsignedTypes()
    {
        Func<CLSCompliantAttribute, bool> predicate = attribute => attribute.IsCompliant;
        Assert.Multiple(() =>
        {
            Assert.That(typeof(sbyte).SelectFromCustomAttribute(predicate), Is.False);
            Assert.That(typeof(ushort).SelectFromCustomAttribute(predicate), Is.False);
            Assert.That(typeof(uint).SelectFromCustomAttribute(predicate), Is.False);
            Assert.That(typeof(ulong).SelectFromCustomAttribute(predicate), Is.False);
        });
    }

    [Test]
    public void SelectFromCustomAttribute_ShouldBeTrue_GivenCLSCompliantAttributeOnSignedTypes()
    {
        Func<CLSCompliantAttribute, bool> predicate = attribute => attribute.IsCompliant;
        Assert.Multiple(() =>
        {
            Assert.That(typeof(byte).SelectFromCustomAttribute(predicate));
            Assert.That(typeof(short).SelectFromCustomAttribute(predicate));
            Assert.That(typeof(int).SelectFromCustomAttribute(predicate));
            Assert.That(typeof(long).SelectFromCustomAttribute(predicate));
        });
    }

    [Test]
    public void SelectFromCustomAttribute_ShouldThrow_GivenNull()
    {
        Type? type = null;

        Assert.Throws<ArgumentNullException>(() =>
        {
            _ = type!.SelectFromCustomAttribute((CLSCompliantAttribute attribute) => attribute.IsCompliant);
        });

        Assert.Throws<ArgumentNullException>(() =>
        {
            _ = type!.SelectFromCustomAttribute((CLSCompliantAttribute attribute) => attribute.IsCompliant, true);
        });

        const BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic |
                                          BindingFlags.Instance | BindingFlags.Static;
        var memberInfo = typeof(int).GetMembers(bindingFlags)[0];
        Func<CLSCompliantAttribute, bool>? selector = null;

        Assert.Throws<ArgumentNullException>(() => typeof(int).SelectFromCustomAttribute(selector!));
        Assert.Throws<ArgumentNullException>(() => typeof(int).SelectFromCustomAttribute(selector!, default));
        Assert.Throws<ArgumentNullException>(() => memberInfo.SelectFromCustomAttribute(selector!));
        Assert.Throws<ArgumentNullException>(() => memberInfo.SelectFromCustomAttribute(selector!, default));
    }
}
