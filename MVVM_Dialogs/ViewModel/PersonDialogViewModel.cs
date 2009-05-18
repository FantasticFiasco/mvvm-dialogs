using MVVM_Dialogs.Model;

namespace MVVM_Dialogs.ViewModel
{
	/// <summary>
	/// Acts as viewmodel for PersonDialog.
	/// </summary>
	public class PersonDialogViewModel : ViewModelBase
	{
		private Person person;


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


		public PersonDialogViewModel(Person person)
		{
			this.person = person;
		}
	}
}
