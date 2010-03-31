using System.Diagnostics.Contracts;
using MVVM_Dialogs.Model;

namespace MVVM_Dialogs.ViewModel
{
	/// <summary>
	/// Acts as ViewModel for PersonDialog.
	/// </summary>
	public class PersonDialogViewModel : ViewModelBase
	{
		private readonly Person person;


		/// <summary>
		/// Initializes a new instance of the <see cref="PersonDialogViewModel"/> class.
		/// </summary>
		/// <param name="person">The person.</param>
		public PersonDialogViewModel(Person person)
		{
			Contract.Requires(person != null);

			this.person = person;
		}


		/// <summary>
		/// Gets the name of the person.
		/// </summary>
		public string Name
		{
			get { return person.Name; }
		}


		/// <summary>
		/// Gets the gender of the person.
		/// 
		/// In production code it wouldn't be allowed to return an enum to UI, but this isn't
		/// production code ;-)
		/// </summary>
		public Gender Gender
		{
			get { return person.Gender; }
		}
	}
}
