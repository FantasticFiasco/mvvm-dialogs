using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using MVVM_Dialogs.Properties;
using MVVM_Dialogs.Service;
using MVVM_Dialogs.View;

namespace MVVM_Dialogs.ViewModel
{
	/// <summary>
	/// Acts as ViewModel for MainWindow.
	/// </summary>
	public class MainWindowViewModel : ViewModelBase
	{
		private IDialogService dialogService;

		private ObservableCollection<PersonViewModel> persons;
		private ICommand showInformationCommand;
		private ICommand deleteCommand;


		/// <summary>
		/// Gets the persons.
		/// </summary>
		public ReadOnlyObservableCollection<PersonViewModel> Persons
		{
			get { return new ReadOnlyObservableCollection<PersonViewModel>(persons); }
		}


		/// <summary>
		/// Gets the command showing information about a person.
		/// </summary>
		public ICommand ShowInformationCommand
		{
			get
			{
				if (showInformationCommand == null)
				{
					showInformationCommand = new RelayCommand(ShowInformation, CanShowInformation);
				}
				return showInformationCommand;
			}
		}


		/// <summary>
		/// Gets the command deleting a selected person.
		/// </summary>
		public ICommand DeleteCommand
		{
			get
			{
				if (deleteCommand == null)
				{
					deleteCommand = new RelayCommand(Delete, CanDelete);
				}
				return deleteCommand;
			}
		}


		/// <summary>
		/// Gets the selected persons.
		/// </summary>
		public IEnumerable<PersonViewModel> SelectedPersons
		{
			get
			{
				return
					from person in persons
					where person.IsSelected
					select person;
			}
		}


		public MainWindowViewModel(IDialogService dialogService, IPersonService personService)
		{
			this.dialogService = dialogService;

			persons = new ObservableCollection<PersonViewModel>(
				from person in personService.Get()
				select new PersonViewModel(person));
		}


		#region Command methods

		/// <summary>
		/// Returns whether show person information command can execute.
		/// </summary>
		private bool CanShowInformation(object o)
		{
			return SelectedPersons.Count() == 1;
		}


		/// <summary>
		/// Executes show person information.
		/// </summary>
		private void ShowInformation(object o)
		{
			// Get the selected person ViewModel
			PersonViewModel selectedPerson = persons.Single(p => p.IsSelected);

			// Create the PersonDialog ViewModel
			PersonDialogViewModel personDialogViewModel = new PersonDialogViewModel(selectedPerson.Person);

			// Show the dialog
			dialogService.ShowDialog<PersonDialog>(this, personDialogViewModel);
		}


		/// <summary>
		/// Returns whether delete person command can execute.
		/// </summary>
		private bool CanDelete(object o)
		{
			return SelectedPersons.Count() == 1;
		}


		/// <summary>
		/// Executes delete person.
		/// </summary>
		private void Delete(object o)
		{
			// Get the selected person ViewModel
			PersonViewModel selectedPerson = persons.Single(p => p.IsSelected);

			// Display confirmation messagebox
			MessageBoxResult result = dialogService.ShowMessageBox(this,
				string.Format(Resources.MainWindowViewModel_Delete, selectedPerson.Name),
				Resources.MainWindowViewModel_DeleteCaption,
				MessageBoxButton.YesNo,
				MessageBoxImage.Warning);

			// If user confirms, delete user
			if (result == MessageBoxResult.Yes)
			{
				persons.Remove(selectedPerson);
			}
		}

		#endregion
	}
}
