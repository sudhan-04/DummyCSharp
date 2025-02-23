namespace EventsAndDelegates
{
    internal class Notifier
    {
        public delegate void Notify(string message);
        public event Notify? OnAction;

        public void TriggerEvent(string message)
        {
            OnAction?.Invoke(message);
        }
    }
}
