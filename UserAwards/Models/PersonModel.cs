using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UserAwards.Models
{
	/// <summary>
	/// The class PersonModel
	/// </summary>
	public class PersonModel
	{
		[HiddenInput(DisplayValue = false)]
		public Guid Id { get; set; }
		
		[Display(Name = "Person Name")]
		public string Name { get; set; }

		[Display(Name = "Birth Date")]
		public DateTime Birthdate { get; set; }

		[Display(Name = "Age")]
		public int Age
		{
			get
			{
				return DateTime.Now.Year - Birthdate.Year;
			}
		}

		[Display(Name = "Image")]
		public byte[] ImageData { get; set; }

		[HiddenInput(DisplayValue = false)]
		public string ImageMimeType { get; set; }
	}
}