using System;
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
			PersonLinkAwardHelper.AddAwardToPerson(model);
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
	}
}
