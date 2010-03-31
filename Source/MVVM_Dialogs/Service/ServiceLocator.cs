using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace MVVM_Dialogs.Service
{
	/// <summary>
	/// A very simple service locator.
	/// </summary>
	static class ServiceLocator
	{
		private static Dictionary<Type, object> services = new Dictionary<Type, object>();


		/// <summary>
		/// Adds a service.
		/// </summary>
		public static void Add<T>(T service)
		{
			Contract.Requires(!services.ContainsKey(typeof(T)));

			services.Add(typeof(T), service);
		}


		/// <summary>
		/// Resolves a service.
		/// </summary>
		public static T Resolve<T>()
		{
			Contract.Requires(services.ContainsKey(typeof(T)));

			return (T)services[typeof(T)];
		}
	}
}
