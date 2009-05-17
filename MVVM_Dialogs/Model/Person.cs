
namespace MVVM_Dialogs.Model
{
	/// <summary>
	/// Describing a person.
	/// </summary>
	class Person
	{
		/// <summary>
		/// Gets the name of the person.
		/// </summary>
		public string Name { get; private set; }


		/// <summary>
		/// Gets the gender of the person.
		/// </summary>
		public Gender Gender { get; private set; }


		public Person(string name, Gender gender)
		{
			Name = name;
			Gender = gender;
		}
	}
}
