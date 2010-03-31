using System.Diagnostics.Contracts;
using MVVM_Dialogs.Model;

namespace MVVM_Dialogs.ViewModel
{
	/// <summary>
	/// Acts as ViewModel of a Person in MainWindow list.
	/// </summary>
	public class PersonViewModel : ViewModelBase
	{
		private bool isSelected;


		/// <summary>
		/// Initializes a new instance of the <see cref="PersonViewModel"/> class.
		/// </summary>
		/// <param name="person">The person.</param>
		public PersonViewModel(Person person)
		{
			Contract.Requires(person != null);

			Person = person;
		}


		/// <summary>
		/// Gets the name of the person.
		/// </summary>
		public string Name
		{
			get { return Person.Name; }
		}


		/// <summary>
		/// Gets or sets whether person is selected.
		/// </summary>
		public bool IsSelected
		{
			get { return isSelected; }
			set
			{
				if (isSelected != value)
				{
					isSelected = value;
					OnPropertyChanged("IsSelected");
				}
			}
		}


		/// <summary>
		/// Gets the person model. This property is not intended for binding!
		/// 
		/// If there exists better ways to expose the model from the ViewModel, please tell me
		/// because I don't like this solution at all.
		/// </summary>
		internal Person Person { get; private set; }
	}
}
