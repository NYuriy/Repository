﻿using System.Web;
using System.Web.Optimization;

namespace UserAwards
{
	public class BundleConfig
	{
		// For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
			"~/Scripts/jquery-1.*"));

			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
						"~/Scripts/modernizr-*"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
						"~/Scripts/bootstrap*"));

			bundles.Add(new StyleBundle("~/Content/css")
					.Include("~/Content/site.css")  /* не перепутайте порядок */
					.Include("~/Content/bootstrap*"));
		}
	}
}