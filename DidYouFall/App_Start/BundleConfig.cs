using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace DidYouFall.App_Start
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/Js/Layout").Include(
                        "~/JavaScripts/Layout/jquery-1.10.2.js",
                        "~/JavaScripts/Layout/bootstrap.min.js",
                        "~/JavaScripts/Layout/sb-admin.js"
                        ));

            bundles.Add(new StyleBundle("~/bundles/Css/Layout").Include(
            "~/Css/Layout/bootstrap.min.css"
            ));
        }
    }
}