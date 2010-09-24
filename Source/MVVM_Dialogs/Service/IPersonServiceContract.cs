using System.Collections.Generic;
using System.Diagnostics.Contracts;
using MVVM_Dialogs.Model;

namespace MVVM_Dialogs.Service
{
	[ContractClassFor(typeof(IPersonService))]
	abstract class IPersonServiceContract : IPersonService
	{
		/// <summary>
		/// Load persons from file on disk.
		/// </summary>
		public List<Person> Load(string fileName)
		{
			Contract.Requires(!string.IsNullOrWhiteSpace(fileName));
			Contract.Ensures(Contract.Result<List<Person>>() != null);

			return default(List<Person>);
		}
	}
}
