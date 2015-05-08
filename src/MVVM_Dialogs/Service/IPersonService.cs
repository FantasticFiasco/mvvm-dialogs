using System.Collections.Generic;
using System.Diagnostics.Contracts;
using MVVM_Dialogs.Model;

namespace MVVM_Dialogs.Service
{
	[ContractClass(typeof(IPersonServiceContract))]
	public interface IPersonService
	{
		/// <summary>
		/// Load persons from file on disk.
		/// </summary>
		List<Person> Load(string fileName);
	}
}
