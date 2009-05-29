using System;
using System.Collections.Generic;

namespace MVVM_Dialogs.Service
{
	static class ServiceLocator
	{
		private static Dictionary<Type, object> services = new Dictionary<Type, object>();


		/// <summary>
		/// Adds a service.
		/// </summary>
		public static void Add<T>(T service)
		{
			if (services.ContainsKey(typeof(T)))
				throw new ArgumentException("Service is already added");

			services.Add(typeof(T), service);
		}


		/// <summary>
		/// Resolves a service.
		/// </summary>
		public static T Resolve<T>()
		{
			if (!services.ContainsKey(typeof(T)))
				throw new ArgumentException("Service hasn't been added");

			return (T)services[typeof(T)];
		}
	}
}
