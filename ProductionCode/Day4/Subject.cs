using System.Collections.Generic;

namespace ProductionCode.Day4
{
    public interface IObserver
    {
        void Update(string message);
    }

    public abstract class Subject
    {
        private List<IObserver> _observers = new List<IObserver>();
        protected string _message;

        public void Attach(IObserver cop)
        {
            _observers.Add(cop);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(_message);
            }
        }
    }
}
