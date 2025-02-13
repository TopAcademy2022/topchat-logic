namespace TopChat.API.Interfaces
{
	public interface IDependencyInjection
	{
		public void AddScope<I, R>() where I : class where R : class;
	}
}
