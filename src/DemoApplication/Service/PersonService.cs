using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Xml.Serialization;
using DemoApplication.Model;

namespace DemoApplication.Service
{
    [Export(typeof(IPersonService))]
    public class PersonService : IPersonService
    {
        /// <summary>
        /// Load persons from file on disk.
        /// </summary>
        public IEnumerable<Person> Load(string fileName)
        {
            try
            {
                using (var reader = new StreamReader(fileName))
                {
                    var serializer = new XmlSerializer(typeof(List<Person>));
                    return (List<Person>)serializer.Deserialize(reader);
                }
            }
            catch (Exception)
            {
                // This is a demo application, lets forget about proper exception handling
                return new List<Person>();
            }
        }
    }
}