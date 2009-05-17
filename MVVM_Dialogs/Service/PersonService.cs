using System.Collections.Generic;
using MVVM_Dialogs.Model;

namespace MVVM_Dialogs.Service
{
	class PersonService : IPersonService
	{
		/// <summary>
		/// Get all persons.
		/// </summary>
		public List<Person> Get()
		{
			return new List<Person>
			{
				new Person("Barbara", Gender.Female),
				new Person("Mike", Gender.Male),
				new Person("Savannah", Gender.Female),
				new Person("Will", Gender.Male)
			};
		}
	}
}
