using System;
using System.Diagnostics;
using System.Web;
using System.Web.Mvc;
using UserAwards.Models;
using UserAwards.Models.Helpers;

namespace UserAwards.Controllers
{
	public class AwardController : Controller
	{
		public ActionResult Index()
		{
			return View(AwardHelper.AwardModelList);
		}

		public ActionResult Details(Guid id)
		{
			return View(AwardHelper.GetAwardModelEntity(id));
		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(AwardModel model, HttpPostedFileBase image = null)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			try
			{
				if (image != null)
				{
					model.ImageMimeType = image.ContentType;
					model.ImageData = new byte[image.ContentLength];
					image.InputStream.Read(model.ImageData, 0, image.ContentLength);
				}

				AwardHelper.CreateEntity(model);
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		public FileContentResult GetImage(Guid id)
		{
			var entity = AwardHelper.GetAwardModelEntity(id);
			return entity != null ? File(entity.ImageData, entity.ImageMimeType) : null;
		}

		public ActionResult Edit(Guid id)
		{
			return View(AwardHelper.GetAwardModelEntity(id));
		}

		[HttpPost]
		public ActionResult Edit(AwardModel model, HttpPostedFileBase image = null)
		{
			try
			{
				if (image != null)
				{
					model.ImageMimeType = image.ContentType;
					model.ImageData = new byte[image.ContentLength];
					image.InputStream.Read(model.ImageData, 0, image.ContentLength);
				}

				AwardHelper.UpdateEntity(model);
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		public ActionResult Delete(Guid id)
		{
			return View(AwardHelper.GetAwardModelEntity(id));
		}

		[HttpPost]
		public ActionResult Delete(AwardModel model)
		{
			try
			{
				AwardHelper.DeleteEntity(model.Id);
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
	}
}
