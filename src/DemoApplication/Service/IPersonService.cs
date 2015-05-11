using System.Collections.Generic;
using DemoApplication.Model;

namespace DemoApplication.Service
{
    public interface IPersonService
    {
        /// <summary>
        /// Load persons from file on disk.
        /// </summary>
        IEnumerable<Person> Load(string fileName);
    }
}