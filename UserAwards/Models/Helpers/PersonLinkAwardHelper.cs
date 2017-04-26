using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UserAwards.Models.Entity;

namespace UserAwards.Models.Helpers
{
	public static class PersonLinkAwardHelper
	{
		private static List<PersonLinkAward> _personLinkAwardList;

		/// <summary>
		/// The collection peron
		/// </summary>
		private static List<PersonLinkAward> PersonLinkAwardList
		{
			get { return _personLinkAwardList ?? (_personLinkAwardList = GetPersonList()); }
		}

		/// <summary>
		/// Gets award listItem.
		/// </summary>
		public static PersonLinkAwardModel NewAttachAward()
		{
			var personLinkAwardModel = new PersonLinkAwardModel();
			return personLinkAwardModel;
		}

		/// <summary>
		/// Gets award listItem.
		/// </summary>
		public static List<SelectListItem> AwardModelListItem()
		{
			return AwardHelper.AwardModelList.Select(_ => new SelectListItem { Text = _.Title, Value = _.Id.ToString() }).ToList();
		}

		/// <summary>
		/// Gets person listItem.
		/// </summary>
		public static List<SelectListItem> PersonModelListItem()
		{
			return PersonHelper.PersonModelList.Select(_ => new SelectListItem {Text = _.Name, Value = _.Id.ToString()}).ToList();
		}

		/// <summary>
		/// Gets person link award list.
		/// </summary>
		/// <returns></returns>
		public static List<PersonLinkAwardModel> GetPersonLinkAwardList()
		{
			return PersonLinkAwardList.Select(item => new PersonLinkAwardModel
			{
				PersonModelData = PersonHelper.GetPersonModelEntity(item.PersonId), AwardModelData = AwardHelper.GetAwardModelEntity(item.AwardId)
			}).ToList();
		}


		/// <summary>
		/// Gets PersonLinkAward collection.
		/// </summary>
		/// <returns></returns>
		private static List<PersonLinkAward> GetPersonList()
		{
			var personLinkAwardList = new List<PersonLinkAward>
			{
				new PersonLinkAward {PersonId = Guid.Parse("7816ec31-2185-4e0f-a32c-64d970eff4d5"), 
								AwardId = Guid.Parse("7816ec31-2185-4e0f-a32c-64d970eff001"), },
				new PersonLinkAward {PersonId = Guid.Parse("7816ec31-2185-4e0f-a32c-64d970eff4d5"), 
								AwardId = Guid.Parse("7816ec31-2185-4e0f-a32c-64d970eff002"), },
				new PersonLinkAward {PersonId = Guid.Parse("7816ec31-2185-4e0f-a32c-64d970eff4d7"), 
								AwardId = Guid.Parse("7816ec31-2185-4e0f-a32c-64d970eff003"), },
			};
			return personLinkAwardList;
		}

		public static void AddAwardToPerson(PersonLinkAwardModel model)
		{
			var personLinkAward = new PersonLinkAward
			{
				PersonId = model.PersonId,
				AwardId = model.AwardId
			};

			PersonLinkAwardList.Add(personLinkAward);
		}

		public static void DeeteAttachedAward(Guid personId, Guid awardId)
		{
			var deleteItem = PersonLinkAwardList.FirstOrDefault(_ => _.PersonId == personId && _.AwardId == awardId);
			if (deleteItem != null)
			{
				PersonLinkAwardList.Remove(deleteItem);
			}
		}
	}
}