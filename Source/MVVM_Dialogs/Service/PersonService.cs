using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using MVVM_Dialogs.Model;

namespace MVVM_Dialogs.Service
{
	class PersonService : IPersonService
	{
		/// <summary>
		/// Load all persons from file on disk.
		/// </summary>
		public List<Person> Load(string fileName)
		{
			try
			{
				using (StreamReader reader = new StreamReader(fileName))
				{
					XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));
					return (List<Person>)serializer.Deserialize(reader);
				}
			}
			catch (Exception)
			{
				// I wouldn't catch System.Exception in production code
				return new List<Person>();
			}
		}
	}
}
