using NUnit.Framework;
using X10D.Reactive;

namespace X10D.Tests.Reactive;

[TestFixture]
internal class ProgressTests
{
    [Test]
    public void OnProgressChanged_ShouldCallCompletionDelegate_GivenCompletionValue()
    {
        var subscriberWasCalled = false;
        var completionWasCalled = false;

        var progress = new Progress<float>();
        progress.OnProgressChanged(1.0f).Subscribe(_ => subscriberWasCalled = true, () => completionWasCalled = true);

        ((IProgress<float>)progress).Report(0.5f);
        ((IProgress<float>)progress).Report(1.0f);

        Thread.Sleep(1000);
        Assert.That(subscriberWasCalled);
        Assert.That(completionWasCalled);
    }

    [Test]
    public void OnProgressChanged_ShouldCallSubscribers_OnProgressChanged()
    {
        var subscriberWasCalled = false;

        var progress = new Progress<float>();
        progress.OnProgressChanged().Subscribe(_ => subscriberWasCalled = true);

        ((IProgress<float>)progress).Report(0.5f);

        Thread.Sleep(1000);
        Assert.That(subscriberWasCalled);
    }

    [Test]
    public void OnProgressChanged_ShouldCallSubscribers_OnProgressChanged_GivenCompletionValue()
    {
        var subscriberWasCalled = false;

        var progress = new Progress<float>();
        progress.OnProgressChanged(1.0f).Subscribe(_ => subscriberWasCalled = true);

        ((IProgress<float>)progress).Report(0.5f);

        Thread.Sleep(1000);
        Assert.That(subscriberWasCalled);
    }

    [Test]
    public void OnProgressChanged_ShouldThrowArgumentNullException_GivenNullProgress()
    {
        Progress<float> progress = null!;
        Assert.Throws<ArgumentNullException>(() => progress.OnProgressChanged());
    }

    [Test]
    public void OnProgressChanged_ShouldThrowArgumentNullException_GivenNullProgressAndCompletionValue()
    {
        Progress<float> progress = null!;
        Assert.Throws<ArgumentNullException>(() => progress.OnProgressChanged(1.0f));
    }
}
