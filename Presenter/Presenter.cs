using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter
{
    public class Presenter
    {
        private ILogger _log;
        private IView _view;

        public Presenter(IView view)
        {
            _view = view;
            _view.Loaded += OnLoaded;
        }

        public Presenter(IView view, ILogger mockLogger)
        {
            _view = view;
            _log = mockLogger;
            _view.Loaded += OnLoaded;
            _view.ErrorOccured += OnError;
        }

        private void OnError(string text)
        {
            _log.LogError(text);
        }

        private void OnLoaded()
        {
            _view.Render("Hello World");
        }
    }

    public class TestView : IView
    {
        private string _text;

        public event Action<string> ErrorOccured;

        public event Action Loaded;

        public void Render(string text)
        {
            _text = text;
            Loaded?.Invoke();
        }
    }
}