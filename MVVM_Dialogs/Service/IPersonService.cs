using System.Collections.Generic;
using MVVM_Dialogs.Model;

namespace MVVM_Dialogs.Service
{
	public interface IPersonService
	{
		/// <summary>
		/// Load all persons from file on disk.
		/// </summary>
		List<Person> Load(string fileName);
	}
}
