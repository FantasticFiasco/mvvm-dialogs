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
		private static Dictionary<Type, ServiceInfo> services = new Dictionary<Type, ServiceInfo>();


		/// <summary>
		/// Registers a service.
		/// </summary>
		public static void Register<TInterface, TImplemention>() where TImplemention : TInterface
		{
			Register<TInterface, TImplemention>(false);
		}


		/// <summary>
		/// Registers a service as a singleton.
		/// </summary>
		public static void RegisterSingleton<TInterface, TImplemention>() where TImplemention : TInterface
		{
			Register<TInterface, TImplemention>(true);
		}


		/// <summary>
		/// Resolves a service.
		/// </summary>
		public static TInterface Resolve<TInterface>()
		{
			Contract.Requires(services.ContainsKey(typeof(TInterface)));

			return (TInterface)services[typeof(TInterface)].ServiceImplementation;
		}


		/// <summary>
		/// Registers a service.
		/// </summary>
		/// <param name="isSingleton">true if service is Singleton; otherwise false.</param>
		private static void Register<TInterface, TImplemention>(bool isSingleton) where TImplemention : TInterface
		{
			Contract.Requires(!services.ContainsKey(typeof(TInterface)));

			services.Add(typeof(TInterface), new ServiceInfo(typeof(TImplemention), isSingleton));
		}


		/// <summary>
		/// Class holding service information.
		/// </summary>
		class ServiceInfo
		{
			private Type serviceImplementationType;
			private object serviceImplementation;
			private bool isSingleton;


			/// <summary>
			/// Initializes a new instance of the <see cref="ServiceInfo"/> class.
			/// </summary>
			/// <param name="serviceImplementationType">Type of the service implementation.</param>
			/// <param name="isSingleton">Whether the service is a Singleton.</param>
			public ServiceInfo(Type serviceImplementationType, bool isSingleton)
			{
				this.serviceImplementationType = serviceImplementationType;
				this.isSingleton = isSingleton;
			}

			
			/// <summary>
			/// Gets the service implementation.
			/// </summary>
			public object ServiceImplementation
			{
				get
				{
					if (isSingleton)
					{
						if (serviceImplementation == null)
						{
							serviceImplementation = Activator.CreateInstance(serviceImplementationType);
						}

						return serviceImplementation;
					}
					else
					{
						return Activator.CreateInstance(serviceImplementationType);
					}
				}
			}
		}
	}
}
