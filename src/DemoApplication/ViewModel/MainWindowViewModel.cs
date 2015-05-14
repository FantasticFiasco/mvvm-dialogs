using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using DemoApplication.Model;
using DemoApplication.Properties;
using DemoApplication.Service;
using DemoApplication.View;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs.OpenFile;

namespace DemoApplication.ViewModel
{
    /// <summary>
    /// Acts as view model for <see cref="MainWindow"/>.
    /// </summary>
    [Export]
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IDialogService dialogService;
        private readonly IPersonService personService;
        private readonly ObservableCollection<PersonViewModel> persons;
        private readonly ICommand loadPersonsCommand;
        private readonly ICommand showInformationCommand;
        private readonly ICommand deleteCommand;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        /// <param name="dialogService">The dialog service.</param>
        /// <param name="personService">The person service.</param>
        [ImportingConstructor]
        public MainWindowViewModel(
            IDialogService dialogService,
            IPersonService personService)
        {
            if (dialogService == null)
                throw new ArgumentNullException("dialogService");
            if (personService == null)
                throw new ArgumentNullException("personService");

            this.dialogService = dialogService;
            this.personService = personService;
            
            persons = new ObservableCollection<PersonViewModel>();
            loadPersonsCommand = new RelayCommand(LoadPersons, CanLoadPersons);
            showInformationCommand = new RelayCommand(ShowInformation, CanShowInformation);
            deleteCommand = new RelayCommand(Delete, CanDelete);
        }
        
        /// <summary>
        /// Gets the persons.
        /// </summary>
        public ObservableCollection<PersonViewModel> Persons
        {
            get { return persons; }
        }

        /// <summary>
        /// Gets the selected persons.
        /// </summary>
        public IEnumerable<PersonViewModel> SelectedPersons
        {
            get { return persons.Where(person => person.IsSelected); }
        }

        /// <summary>
        /// Gets the selected person.
        /// </summary>
        public PersonViewModel SelectedPerson
        {
            get { return persons.Single(person => person.IsSelected); }
        }

        /// <summary>
        /// Gets the command loading persons from disk.
        /// </summary>
        public ICommand LoadPersonsCommand
        {
            get { return loadPersonsCommand; }
        }
        
        /// <summary>
        /// Gets the command showing information about a person.
        /// </summary>
        public ICommand ShowInformationCommand
        {
            get { return showInformationCommand; }
        }
        
        /// <summary>
        /// Gets the command deleting a selected person.
        /// </summary>
        public ICommand DeleteCommand
        {
            get { return deleteCommand; }
        }
        
        /// <summary>
        /// Returns value indicating whether <see cref="LoadPersonsCommand"/> can execute.
        /// </summary>
        private bool CanLoadPersons()
        {
            return !Persons.Any();
        }

        /// <summary>
        /// Callback when <see cref="LoadPersonsCommand"/> is executed.
        /// </summary>
        private void LoadPersons()
        {
            var openFileDialogViewModel = new OpenFileDialogViewModel
            {
                FileName = "LoadMe.xml",
                Filter = Resources.MainWindowViewModel_LoadPersonsFilter,
                InitialDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                Title = Resources.MainWindowViewModel_LoadPersonsTitle
            };
            
            // Open the dialog
            DialogResult result = dialogService.ShowOpenFileDialog(this, openFileDialogViewModel);
            if (result == DialogResult.OK)
            {
                // Load the persons, usually one investigates whether the file was loaded successfully,
                // but this is only a demo application
                foreach (Person person in personService.Load(openFileDialogViewModel.FileName))
                {
                    persons.Add(new PersonViewModel(person));
                }
            }
        }

        /// <summary>
        /// Returns value indicating whether <see cref="ShowInformationCommand"/> can execute.
        /// </summary>
        private bool CanShowInformation()
        {
            return SelectedPersons.Count() == 1;
        }

        /// <summary>
        /// Callback when <see cref="ShowInformationCommand"/> is executed.
        /// </summary>
        private void ShowInformation()
        {
            var personDialogViewModel = new PersonDialogViewModel(SelectedPerson.Person);

            // Show the dialog
            dialogService.ShowDialog(this, personDialogViewModel);
        }

        /// <summary>
        /// Returns value indicating whether <see cref="DeleteCommand"/> can execute.
        /// </summary>
        private bool CanDelete()
        {
            return SelectedPersons.Count() == 1;
        }

        /// <summary>
        /// Callback when <see cref="DeleteCommand"/> is executed.
        /// </summary>
        private void Delete()
        {
            // Display confirmation message box
            MessageBoxResult result = dialogService.ShowMessageBox(
                this,
                string.Format(Resources.MainWindowViewModel_Delete, SelectedPerson.Name),
                Resources.MainWindowViewModel_DeleteCaption,
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            // If user confirms, delete user
            if (result == MessageBoxResult.Yes)
            {
                persons.Remove(SelectedPerson);
            }
        }
    }
}