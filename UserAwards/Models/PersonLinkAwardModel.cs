
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace UserAwards.Models
{
	/// <summary>
	/// The class PersonLinkAwardModel.
	/// </summary>
	public class PersonLinkAwardModel
	{
		/// <summary>
		/// The constructor.
		/// </summary>
		public PersonLinkAwardModel()
		{
			AwardModelData = new AwardModel();
			PersonModelData = new PersonModel();
		}

		/// <summary>
		/// The AwardModel.
		/// </summary>
		public AwardModel AwardModelData { get; set; }

		/// <summary>
		/// The PersonModel.
		/// </summary>
		public PersonModel PersonModelData { get; set; }

		/// <summary>
		/// The Person id.
		/// </summary>
		public Guid PersonId { get; set; }

		/// <summary>
		/// The Award id.
		/// </summary>
		public Guid AwardId { get; set; }
	}
}