using System;
using System.Linq;
using System.Web.Mvc;
using UserAwards.Models;
using UserAwards.Models.Helpers;

namespace UserAwards.Controllers
{
	public class PersonLinkAwardController : Controller
	{
		
		public ActionResult Index()
		{
			return View(PersonLinkAwardHelper.GetPersonLinkAwardList());
		}


		[HttpPost]
		public ActionResult AttachedAward(PersonLinkAwardModel model)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			PersonLinkAwardHelper.AddAwardToPerson(model);
			return RedirectToAction("Index");
		}

		public ActionResult ModalAction(Guid id)
		{
			return PartialView("ModalContent", AwardHelper.GetAwardById(id));
		}

		[HttpPost]
		public ActionResult Lyubomir()
		{
			return RedirectToAction("Index");
		}
		
		public ActionResult NewAttachAward()
		{
			ViewBag.PersonModelListItem = PersonLinkAwardHelper.PersonModelListItem();
			ViewBag.AwardModelListItem = PersonLinkAwardHelper.AwardModelListItem();
			return View(PersonLinkAwardHelper.NewAttachAward());
		}

		public ActionResult Delete(Guid personId, Guid awardId)
		{

			PersonLinkAwardHelper.DeeteAttachedAward(personId, awardId);
			return RedirectToAction("Index");
		}

		public ActionResult CheckAwardDuplicate(PersonLinkAwardModel personLinkAwardModel)
		{
			var currentList = PersonLinkAwardHelper.GetPersonLinkAwardList();

			if (currentList.Any(_ => _.AwardModelData.Id == personLinkAwardModel.AwardId && _.PersonModelData.Id == personLinkAwardModel.PersonId))
			{
				return Json(false, JsonRequestBehavior.AllowGet);
			}
			return Json(true, JsonRequestBehavior.AllowGet);
		}
	}
}
