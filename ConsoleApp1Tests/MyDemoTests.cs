using NUnit.Framework;
using ConsoleApp1.Program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Program;
using NSubstitute;

namespace ConsoleApp1.Program.Tests
{
    [TestFixture]
    public class MyDemoTests
    {
        [Test]
        public void MyDemoTest()
        {
            //arrange
            //NSubstitute會產生一個ICalculator 假的實體出來
            var calculator = Substitute.For<ICalculator>();

            var myDemo = new MyDemo(calculator);

            //act
            myDemo.Action1(true);

            //assert
            calculator.Received(1).Clear(7);
            calculator.DidNotReceive().Clear(1);
            calculator.Received(1).Clear(Arg.Any<int>());
            calculator.ReceivedWithAnyArgs(1).Clear(default(int));
        }

        [Test]
        public void Test_RaisingEvents_RaiseEvent()
        {
            var engine = Substitute.For<IEngine>();

            var wasCalled = false;
            engine.Idling += (sender, args) => wasCalled = true;

            // 告訴替代實例引發異常，並攜帶指定的sender和事件參數
            engine.Idling += Raise.EventWith(new object(), new EventArgs());

            Assert.IsTrue(wasCalled);
        }

        [Test]
        public void Test_RaisingEvents_RaiseEventButNoMindSenderAndArgs()
        {
            var engine = Substitute.For<IEngine>();

            var wasCalled = false;
            engine.Idling += (sender, args) => wasCalled = true;

            //engine.Idling += Raise.Event();
            Assert.IsTrue(wasCalled);
        }
    }
}