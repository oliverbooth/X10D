using System.Text.Json.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Text;

namespace X10D.Tests.Text;

[TestClass]
public class StringTests
{
    private struct SampleStructure
    {
        [JsonPropertyName("values")]
        public int[] Values { get; set; }
    }

    [TestMethod]
    public void FromJsonShouldDeserializeCorrectly()
    {
        const string json = "{\"values\": [1, 2, 3]}";
        var target = json.FromJson<SampleStructure>();
        Assert.IsInstanceOfType(target, typeof(SampleStructure));
        Assert.IsNotNull(target);
        Assert.IsNotNull(target.Values);
        Assert.AreEqual(3, target.Values.Length);
        Assert.AreEqual(1, target.Values[0]);
        Assert.AreEqual(2, target.Values[1]);
        Assert.AreEqual(3, target.Values[2]);
    }
}
