using System.Diagnostics;
using NUnit.Framework;

namespace X10D.Tests;

[SetUpFixture]
internal sealed class SetupTrace
{
    [OneTimeSetUp]
    public void StartTest()
    {
        Trace.Listeners.Add(new ConsoleTraceListener());
    }

    [OneTimeTearDown]
    public void EndTest()
    {
        Trace.Flush();
    }
}
