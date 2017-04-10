using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UserAwards.Models
{
	/// <summary>
	/// The class AwardModel.
	/// </summary>
	public class AwardModel
	{
		[HiddenInput(DisplayValue = false)]
		public Guid Id { get; set; }

		[Display(Name = "Title Name")]
		public string Title { get; set; }

		[Display(Name = "Description")]
		public string Description { get; set; }

		[Display(Name = "Image")]
		public byte[] ImageData { get; set; }

		[HiddenInput(DisplayValue = false)]
		public string ImageMimeType { get; set; }
	}
}