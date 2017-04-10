using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserAwards.Models.Entity
{
	/// <summary>
	/// The class Award.
	/// </summary>
	public class Award
	{
		/// <summary>
		/// The award id.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// The award name.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// The award Description.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// The Image Data.
		/// </summary>
		public byte[] ImageData { get; set; }

		/// <summary>
		/// The Image Mime Type.
		/// </summary>
		public string ImageMimeType { get; set; }
	}
}