using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Reflection;

namespace X10D.Tests.Reflection;

[TestClass]
public class MemberInfoTests
{
    [TestMethod]
    public void HasCustomAttribute_ShouldBeTrue_GivenCLSCompliantAttributeOnUnsignedTypes()
    {
        Assert.IsTrue(typeof(sbyte).HasCustomAttribute(typeof(CLSCompliantAttribute))); // okay, sbyte is signed. I know.
        Assert.IsTrue(typeof(ushort).HasCustomAttribute(typeof(CLSCompliantAttribute)));
        Assert.IsTrue(typeof(uint).HasCustomAttribute(typeof(CLSCompliantAttribute)));
        Assert.IsTrue(typeof(ulong).HasCustomAttribute(typeof(CLSCompliantAttribute)));
    }

    [TestMethod]
    public void HasCustomAttribute_ShouldBeTrue_GivenCLSCompliantAttributeOnUnsignedTypes_Generic()
    {
        Assert.IsTrue(typeof(sbyte).HasCustomAttribute<CLSCompliantAttribute>()); // okay, sbyte is signed. I know.
        Assert.IsTrue(typeof(ushort).HasCustomAttribute<CLSCompliantAttribute>());
        Assert.IsTrue(typeof(uint).HasCustomAttribute<CLSCompliantAttribute>());
        Assert.IsTrue(typeof(ulong).HasCustomAttribute<CLSCompliantAttribute>());
    }

    [TestMethod]
    public void HasCustomAttribute_ShouldThrow_GivenNull()
    {
        Type? type = null;
        Assert.ThrowsException<ArgumentNullException>(() => type!.HasCustomAttribute<CLSCompliantAttribute>());
        Assert.ThrowsException<ArgumentNullException>(() => type!.HasCustomAttribute(typeof(CLSCompliantAttribute)));

        Assert.ThrowsException<ArgumentNullException>(() => typeof(object).HasCustomAttribute(null!));
    }

    [TestMethod]
    public void HasCustomAttribute_ShouldThrow_GivenNonAttribute()
    {
        Assert.ThrowsException<ArgumentException>(() => typeof(object).HasCustomAttribute(typeof(object)));
    }

    [TestMethod]
    public void SelectFromCustomAttribute_ShouldBeFalse_GivenCLSCompliantAttributeOnUnsignedTypes()
    {
        Assert.IsFalse(typeof(sbyte).SelectFromCustomAttribute((CLSCompliantAttribute attribute) => attribute.IsCompliant));
        Assert.IsFalse(typeof(ushort).SelectFromCustomAttribute((CLSCompliantAttribute attribute) => attribute.IsCompliant));
        Assert.IsFalse(typeof(uint).SelectFromCustomAttribute((CLSCompliantAttribute attribute) => attribute.IsCompliant));
        Assert.IsFalse(typeof(ulong).SelectFromCustomAttribute((CLSCompliantAttribute attribute) => attribute.IsCompliant));
    }

    [TestMethod]
    public void SelectFromCustomAttribute_ShouldBeTrue_GivenCLSCompliantAttributeOnSignedTypes()
    {
        Assert.IsTrue(typeof(byte).SelectFromCustomAttribute((CLSCompliantAttribute attribute) => attribute.IsCompliant, true));
        Assert.IsTrue(typeof(short).SelectFromCustomAttribute((CLSCompliantAttribute attribute) => attribute.IsCompliant, true));
        Assert.IsTrue(typeof(int).SelectFromCustomAttribute((CLSCompliantAttribute attribute) => attribute.IsCompliant, true));
        Assert.IsTrue(typeof(long).SelectFromCustomAttribute((CLSCompliantAttribute attribute) => attribute.IsCompliant, true));
    }

    [TestMethod]
    public void SelectFromCustomAttribute_ShouldThrow_GivenNull()
    {
        Type? type = null;

        Assert.ThrowsException<ArgumentNullException>(() =>
            (type!.SelectFromCustomAttribute((CLSCompliantAttribute attribute) => attribute.IsCompliant)));

        Assert.ThrowsException<ArgumentNullException>(() =>
            (type!.SelectFromCustomAttribute((CLSCompliantAttribute attribute) => attribute.IsCompliant, true)));

        Assert.ThrowsException<ArgumentNullException>(() =>
        {
            Func<CLSCompliantAttribute, bool>? selector = null;
            typeof(int).SelectFromCustomAttribute(selector!);
        });
    }
}
