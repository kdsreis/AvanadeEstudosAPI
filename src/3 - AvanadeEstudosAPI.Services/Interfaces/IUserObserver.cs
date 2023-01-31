namespace AvanadeEstudosAPI.Services.Interfaces
{
    public interface IUserObserver
    {
        void Send(IUserSubject subject);
    }
}
