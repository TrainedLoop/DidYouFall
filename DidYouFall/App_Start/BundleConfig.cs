﻿using System;
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
            //LAYOUT
            bundles.Add(new ScriptBundle("~/bundles/Js/Layout").Include(
                        "~/JavaScripts/Layout/jquery-ui-1.10.3.min.js",
                        "~/JavaScripts/Layout/bootstrap.min.js",
                        "~/JavaScripts/Layout/app.js"
                        ));

            bundles.Add(new StyleBundle("~/bundles/Css/Layout").Include(
            "~/Css/Layout/bootstrap.min.css",
            "~/Fonts/font-awesome.min.css",
            "~/Css/Layout/ionicons.min.css",            
            "~/Css/Layout/AdminLTE.css"

            ));

            //SERVER REGISTER
            bundles.Add(new ScriptBundle("~/bundles/Js/Plugins/IpMask").Include(
            "~/JavaScripts/Plugins/jquery-1.11.1.min.js",
            "~/JavaScripts/Plugins/Mask/IpMaskInt.js",
            "~/JavaScripts/Plugins/Mask/mask-plugin.js"
            ));
        }
    }
}