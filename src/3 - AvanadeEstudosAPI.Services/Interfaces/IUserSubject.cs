namespace AvanadeEstudosAPI.Services.Interfaces
{
    public interface IUserSubject
    {
        void Attach(IUserObserver observer);
        void Notify();
    }
}
