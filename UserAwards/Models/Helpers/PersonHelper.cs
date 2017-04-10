using System;
using System.Collections.Generic;
using System.Linq;
using UserAwards.Models.Entity;

namespace UserAwards.Models.Helpers
{
	/// <summary>
	/// The class Person helper.
	/// </summary>
	public static class PersonHelper
	{
		private static List<PersonModel> _personModelList;

		/// <summary>
		/// The collection peron
		/// </summary>
		public static List<PersonModel> PersonModelList
		{
			get { return _personModelList ?? (_personModelList = GetPersonModelList()); }
			set
			{
				if (!Equals(_personModelList, value))
				{
					_personModelList = value;
				}
			}
		}

		/// <summary>
		/// Gets personmodel entity.
		/// </summary>
		/// <param name="id">The id personModel.</param>
		/// <returns>Return personmodel.</returns>
		public static PersonModel GetPersonModelEntity(Guid id)
		{
			var res = PersonModelList.FirstOrDefault(_ => _.Id == id);
			return res;
		}

		/// <summary>
		/// Gets personModel collection.
		/// </summary>
		/// <returns>Return collection PersonModel.</returns>
		private static List<PersonModel> GetPersonModelList()
		{
			var personModelList = GetPersonList().Select(_ =>
				new PersonModel
				{
					Id = _.Id,
					Name = _.Name,
					Birthdate = _.Birthdate
				}).ToList();
			return personModelList;
		}

		/// <summary>
		/// The created new personModel entity.
		/// </summary>
		/// <param name="personModel">The personModel.</param>
		public static void CreateEntity(PersonModel personModel)
		{
			PersonModelList.Add(personModel);
		}


		/// <summary>
		/// The created new personModel entity.
		/// </summary>
		/// <param name="newPersonModel">The personModel.</param>
		public static void UpdateEntity(PersonModel newPersonModel)
		{
			var personModel = GetPersonModelEntity(newPersonModel.Id);
			
			if (personModel == null) return;

			personModel.Name = newPersonModel.Name;
			personModel.Birthdate = newPersonModel.Birthdate;
			personModel.ImageData = newPersonModel.ImageData;
			personModel.ImageMimeType = newPersonModel.ImageMimeType;

		}

		/// <summary>
		/// Deleted personModel entity.
		/// </summary>
		/// <param name="id">The id personModel.</param>
		public static void DeleteEntity(Guid id)
		{
			PersonModelList.Remove(GetPersonModelEntity(id));
		}

		/// <summary>
		/// Gets person collection.
		/// </summary>
		/// <returns></returns>
		private static List<Person> GetPersonList()
		{
			var personList = new List<Person>
			{
				new Person {Birthdate = DateTime.Parse("01/03/2000"), 
								Id = Guid.Parse("7816ec31-2185-4e0f-a32c-64d970eff4d5"), 
								Name = "Petrov P.P."},
				new Person {Birthdate = DateTime.Parse("06/08/2004"), 
								Id = Guid.Parse("7816ec31-2185-4e0f-a32c-64d970eff002"), 
								Name = "Ivanov I.T."},
				new Person {Birthdate = DateTime.Parse("10/01/1991"), 
								Id = Guid.Parse("7816ec31-2185-4e0f-a32c-64d970eff4d7"), 
								Name = "Sidorov K.R."},
			};
			return personList;
		}
	}
}