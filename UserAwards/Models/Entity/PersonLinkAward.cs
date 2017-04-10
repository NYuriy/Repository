using System;

namespace UserAwards.Models.Entity
{
	/// <summary>
	/// The class PersonLinkAward.
	/// </summary>
	public class PersonLinkAward
	{
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