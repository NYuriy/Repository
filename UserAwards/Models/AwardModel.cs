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

		[Required(ErrorMessage = "Title Name должно быть установлено")]
		[StringLength(50, ErrorMessage = "Длина строки должна быть не более 50 символов")]
		[Display(Name = "Title Name")]
		[RegularExpression(@"^[a-zA-Z0-9\s\-]+$", ErrorMessage = "Может включать только латинские символы, цифры, пробелы и дефисы.")]
		public string Title { get; set; }

		[StringLength(250, ErrorMessage = "Описание награды должно быть, не более 250 символов")]
		[Display(Name = "Description")]
		public string Description { get; set; }

		[Required(ErrorMessage = "Изображение награды - обязательное")]
		[Display(Name = "Image")]
		public byte[] ImageData { get; set; }

		[HiddenInput(DisplayValue = false)]
		public string ImageMimeType { get; set; }
	}
}