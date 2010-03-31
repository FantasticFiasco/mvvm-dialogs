using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using MVVM_Dialogs.Model;
using MVVM_Dialogs.Properties;
using MVVM_Dialogs.Service;
using MVVM_Dialogs.Service.FrameworkDialogs.OpenFile;
using MVVM_Dialogs.View;


namespace MVVM_Dialogs.ViewModel
{
	/// <summary>
	/// Acts as ViewModel for MainWindow.
	/// </summary>
	public class MainWindowViewModel : ViewModelBase
	{
		private readonly IDialogService dialogService;
		private readonly IPersonService personService;
		private readonly ObservableCollection<PersonViewModel> persons;


		/// <summary>
		/// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
		/// </summary>
		public MainWindowViewModel()
			: this(ServiceLocator.Resolve<IDialogService>(), ServiceLocator.Resolve<IPersonService>())
		{
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
		/// </summary>
		/// <param name="dialogService">The dialog service.</param>
		/// <param name="personService">The person service.</param>
		public MainWindowViewModel(IDialogService dialogService, IPersonService personService)
		{
			Contract.Requires(dialogService != null);
			Contract.Requires(personService != null);

			this.dialogService = dialogService;
			this.personService = personService;
			persons = new ObservableCollection<PersonViewModel>();
			
			LoadPersonsCommand = new RelayCommand(LoadPersons, CanLoadPersons);
			ShowInformationCommand = new RelayCommand(ShowInformation, CanShowInformation);
			DeleteCommand = new RelayCommand(Delete, CanDelete);
		}


		/// <summary>
		/// Gets the persons.
		/// </summary>
		public ReadOnlyObservableCollection<PersonViewModel> Persons
		{
			get { return new ReadOnlyObservableCollection<PersonViewModel>(persons); }
		}


		/// <summary>
		/// Gets the selected persons.
		/// </summary>
		public IEnumerable<PersonViewModel> SelectedPersons
		{
			get { return persons.Where(person => person.IsSelected); }
		}


		/// <summary>
		/// Gets the command loading persons from disk.
		/// </summary>
		public ICommand LoadPersonsCommand { get; private set; }


		/// <summary>
		/// Gets the command showing information about a person.
		/// </summary>
		public ICommand ShowInformationCommand { get; private set; }


		/// <summary>
		/// Gets the command deleting a selected person.
		/// </summary>
		public ICommand DeleteCommand { get; private set; }
		

		#region Command methods

		/// <summary>
		/// Returns whether load persons command can execute.
		/// </summary>
		private bool CanLoadPersons(object o)
		{
			return !Persons.Any();
		}


		/// <summary>
		/// Executes load persons.
		/// </summary>
		private void LoadPersons(object o)
		{
			// Create ViewModel to OpenFileDialog
			OpenFileDialogViewModel viewModel = new OpenFileDialogViewModel
			{
				FileName = "LoadMe.xml",
				Filter = Resources.MainWindowViewModel_LoadPersonsFilter,
				InitialDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
				Title = Resources.MainWindowViewModel_LoadPersonsTitle
			};

			// Open the dialog
			DialogResult result = dialogService.ShowOpenFileDialog(this, viewModel);
			if (result == DialogResult.OK)
			{
				// Load the persons, usually one investigates whether the file was loaded successfully,
				// but this is only a sample
				foreach (Person person in personService.Load(viewModel.FileName))
				{
					persons.Add(new PersonViewModel(person));
				}
			}
		}


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
			MessageBoxResult result = dialogService.ShowMessageBox(
				this,
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
