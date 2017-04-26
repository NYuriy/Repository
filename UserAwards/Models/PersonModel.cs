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
		[Required(ErrorMessage = "Имя должно быть установлено")]
		[StringLength(50, ErrorMessage = "Длина строки должна быть не более 50 символов")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Birthdate должно быть установлено")]
		[Display(Name = "Birth Date")]
		public DateTime Birthdate { get; set; }


		[Display(Name = "Age")]
		[Range(0, 150, ErrorMessage = "Недопустимый dозраст пользователя")]
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