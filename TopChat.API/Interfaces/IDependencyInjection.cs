using System;

namespace TopChat.API.Interfaces
{
	public interface IDependencyInjection
	{
		public void AddScope(Type classInterface, Type realization);
	}
}
