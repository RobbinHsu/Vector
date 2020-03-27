using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        class MyAsyncClass
        {
            public EventHandler OnCompletion;

            public void DoRun()
            {
                Console.WriteLine($"執行 DoRun 前的執行緒ID={Thread.CurrentThread.ManagedThreadId}");
                ThreadPool.QueueUserWorkItem(x =>
                {
                    Console.WriteLine($"進入到非同步執行緒內的執行緒ID={Thread.CurrentThread.ManagedThreadId}");
                    Console.WriteLine("模擬需要3秒鐘的非同步工作");
                    Thread.Sleep(3000);

                    Console.WriteLine($"準備要呼叫 callback，現在的執行緒ID={Thread.CurrentThread.ManagedThreadId}");
                    OnCompletion?.Invoke(this, EventArgs.Empty);
                });
            }

            public void DoRun1()
            {
                Console.WriteLine($"進入到同步執行緒內的執行緒ID={Thread.CurrentThread.ManagedThreadId}");
                Console.WriteLine("模擬需要3秒鐘的非同步工作");
                Thread.Sleep(3000);

                Console.WriteLine($"準備要呼叫 callback，現在的執行緒ID={Thread.CurrentThread.ManagedThreadId}");
            }
        }

        private static void Main(string[] args)
        {
            var dateTime = DateTime.UtcNow;
            Console.WriteLine($"Main方法內的執行緒ID={Thread.CurrentThread.ManagedThreadId}");
            MyAsyncClass myAsyncObject = new MyAsyncClass();
            myAsyncObject.OnCompletion += (s, e) =>
            {
                Console.WriteLine($"在 Main 方法內的委派 callback ，現在的執行緒ID={Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(1000);
                Console.WriteLine("callback 執行結束了");
            };
            Console.WriteLine($"Main方法內的開始呼叫 DoRun 方法的執行緒ID={Thread.CurrentThread.ManagedThreadId}");
            //myAsyncObject.DoRun();
            myAsyncObject.DoRun1();

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }
    }

    public interface ICalculator
    {
        void Clear(int level);
    }

    public class MyDemo
    {
        private readonly ICalculator _calculator;

        public MyDemo(ICalculator calculator)
        {
            this._calculator = calculator;
        }

        public void Action1(bool clearFlag)
        {
            if (clearFlag == true)
            {
                this._calculator.Clear(7);
            }
        }
    }

    public interface IEngine
    {
        event EventHandler Idling;
        event EventHandler<LowFuelWarningEventArgs> LowFuelWarning;
        event Action<int> RevvedAt;
    }

    public class LowFuelWarningEventArgs : EventArgs
    {
        public int PercentLeft { get; private set; }
        public LowFuelWarningEventArgs(int percentLeft)
        {
            PercentLeft = percentLeft;
        }
    }

    public interface IOrderProcessor
    {
        void ProcessOrder(int orderId, Action<bool> orderProcessed);
    }

    public class OrderPlacedCommand
    {
        IOrderProcessor orderProcessor;
        IEvents events;
        public OrderPlacedCommand(IOrderProcessor orderProcessor, IEvents events)
        {
            this.orderProcessor = orderProcessor;
            this.events = events;
        }
        public void Execute(ICart cart)
        {
            orderProcessor.ProcessOrder(
                cart.OrderId,
                wasOk => { if (wasOk) events.RaiseOrderProcessed(cart.OrderId); }
            );
        }
    }
}