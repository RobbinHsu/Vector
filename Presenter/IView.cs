using System;
using NSubstitute.Core.Events;

namespace Presenter
{
    public interface IView
    {
        event Action Loaded;
        event Action<string> ErrorOccured;
        void Render(string text);
    }
}