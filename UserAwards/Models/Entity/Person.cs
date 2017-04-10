using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserAwards.Models.Entity
{
	/// <summary>
	/// The class Person.
	/// </summary>
	public class Person
	{
		/// <summary>
		/// The Person id.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// The Person name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// The Person birth date.
		/// </summary>
		public DateTime Birthdate { get; set; }

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