using System;
using System.Collections.Generic;

namespace MVVM_Dialogs.Service
{
	static class ServiceLocator
	{
		private static Dictionary<Type, object> services = new Dictionary<Type, object>();


		/// <summary>
		/// Adds a service to the service locator.
		/// </summary>
		public static void Add<T>(object service)
		{
			services.Add(typeof(T), service);
		}


		/// <summary>
		/// Resolves a service from the service locator.
		/// </summary>
		public static T Resolve<T>()
		{
			return (T)services[typeof(T)];
		}
	}
}
