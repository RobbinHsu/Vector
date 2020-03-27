using System;
using NUnit.Framework;
using Presenter;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;

namespace Presenter.Tests
{
    [TestFixture]
    public class PresenterTests
    {
        [Test]
        public void ctor_WhenViewIsLoaded_CallsLogger()
        {
            var stubView = Substitute.For<IView>();
            var mockLogger = Substitute.For<ILogger>();

            var p = new Presenter(stubView, mockLogger);

            stubView.ErrorOccured += Raise.Event<Action<string>>("fake error");
            mockLogger.Received()
                .LogError(Arg.Is<string>(s => s.Contains("fake error")));
            //.Render(Arg.Is<string>(s=>s));
        }

        [Test]
        public void ctor_WhenViewIsLoaded_CallsViewRender()
        {
            var mockView = Substitute.For<IView>();
            var p = new Presenter(mockView);
            mockView.Loaded += Raise.Event<Action>();
            mockView.Received()
                .Render(Arg.Is<string>(s => s.Contains("Hello World")));
            //.Render(Arg.Is<string>(s => s));
        }
    }
}