using AvanadeEstudosAPI.Services.Interfaces;

namespace AvanadeEstudosAPI.Services.Notifications
{
    internal class UserNotifications : IUserSubject
    {
        private List<IUserObserver> observers;
        private string _Action;
        public string Action 
        { 
            get { return _Action; }
            set { _Action = value; Notify(); }
        }

        public UserNotifications()
        {
            this.observers = new List<IUserObserver>();
        }
        public void Attach(IUserObserver observer)
        {
            observers.Add(observer);
        }

        public void Notify()
        {
            observers.ForEach(o =>
            {
                o.Send(this);
            });
        }
    }
}
