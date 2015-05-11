using System;
using DemoApplication.Model;
using DemoApplication.View;
using GalaSoft.MvvmLight;

namespace DemoApplication.ViewModel
{
    /// <summary>
    /// Acts as view model for <see cref="PersonDialog"/>.
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
        /// Gets the gender of the person.
        /// </summary>
        public Gender Gender
        {
            get { return person.Gender; }
        }
    }
}