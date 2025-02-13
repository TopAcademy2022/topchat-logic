using TopChat.API.Interfaces;

namespace TopChat.Infrastruction.Services
{
    public class DefaultDependencyInjection : IDependencyInjection
    {
        public void AddScope<I, R>() where I : class where R : class
        {

        }
    }
}
