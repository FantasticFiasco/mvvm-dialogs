using System;
using DemoApplication.Model;
using DemoApplication.View;
using GalaSoft.MvvmLight;

namespace DemoApplication.ViewModel
{
    /// <summary>
    /// Acts as view model of a <see cref="Person"/> in <see cref="MainWindow"/> list.
    /// </summary>
    public class PersonViewModel : ViewModelBase
    {
        private readonly Person person;

        private bool isSelected;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonViewModel"/> class.
        /// </summary>
        /// <param name="person">The person.</param>
        public PersonViewModel(Person person)
        {
            if (person == null)
                throw new ArgumentNullException("person");

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
        /// Gets or sets whether person is selected.
        /// </summary>
        public bool IsSelected
        {
            get { return isSelected; }
            set { Set(() => IsSelected, ref isSelected, value); }
        }

        /// <summary>
        /// Gets the person model.
        /// </summary>
        /// <remarks>
        /// This property is not intended for bindings.
        /// </remarks>
        internal Person Person
        {
            get { return person; }
        }
    }
}