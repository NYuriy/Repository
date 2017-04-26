using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using UserAwards.Models;
using UserAwards.Models.Helpers;

namespace UserAwards.Controllers
{
	public class PersonController : Controller
	{
		
		public ActionResult Index()
		{
			return View(PersonHelper.PersonModelList);
		}

		public ActionResult Details(Guid id)
		{

			return View(PersonHelper.GetPersonModelEntity(id));
		}


		public ActionResult Create()
		{
			return View();
		}

		public FileStreamResult GetListPerson()
		{
			StringBuilder sb = new StringBuilder();
			foreach (var personItem in PersonHelper.PersonModelList)
			{
				var awardsIds =
					PersonLinkAwardHelper.GetPersonLinkAwardList()
						.Where(_ => _.PersonModelData.Id == personItem.Id)
						.Select(_ => _.AwardModelData.Id)
						.ToList();
				if (awardsIds.Any())
				{
					foreach (var itemawardsId in awardsIds)
					{
						sb.Append(string.Format("{0} {1} \r\n", personItem.Name, AwardHelper.GetAwardById(itemawardsId).Title));
					}
				}
				else
				{
					sb.Append(string.Format("{0} Наград нет \r\n", personItem.Name));
				}
			}

			var fs = new MemoryStream(Encoding.UTF8.GetBytes(sb.ToString()));
			return File(fs, "text/csv");
		}

		[HttpPost]
		public ActionResult Create(PersonModel personModel, HttpPostedFileBase image = null)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			try
			{
				if (image != null)
				{
					personModel.ImageMimeType = image.ContentType;
					personModel.ImageData = new byte[image.ContentLength];
					image.InputStream.Read(personModel.ImageData, 0, image.ContentLength);
				}

				PersonHelper.CreateEntity(personModel);
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		public ActionResult Edit(Guid id)
		{
			return View(PersonHelper.GetPersonModelEntity(id));
		}

		[HttpPost]
		public ActionResult Edit(PersonModel personModel, HttpPostedFileBase image = null)
		{
			try
			{
				if (image != null)
				{
					personModel.ImageMimeType = image.ContentType;
					personModel.ImageData = new byte[image.ContentLength];
					image.InputStream.Read(personModel.ImageData, 0, image.ContentLength);
				}

				PersonHelper.UpdateEntity(personModel);
				return RedirectToAction("Index");
			}
			catch
			{
				return View(PersonHelper.GetPersonModelEntity(personModel.Id));
			}
		}

		public FileContentResult GetImage(Guid id)
		{
			var entity = PersonHelper.GetPersonModelEntity(id);
			if (entity != null && entity.ImageData != null && entity.ImageMimeType != null)
			{
				return File(entity.ImageData, entity.ImageMimeType);
			}
			return null;
		}

		public ActionResult Delete(Guid id)
		{
			return View(PersonHelper.GetPersonModelEntity(id));
		}

		[HttpPost]
		public ActionResult Delete(PersonModel personModel)
		{
			try
			{
				PersonHelper.DeleteEntity(personModel.Id);
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
	}
}
