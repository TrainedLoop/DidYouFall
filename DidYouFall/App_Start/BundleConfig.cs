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
            //LAYOUT
            bundles.Add(new ScriptBundle("~/Js/Layout").Include(
                        "~/JavaScripts/Layout/jquery-1.11.1.min.js",
                        "~/JavaScripts/Layout/bootstrap.min.js",
                        "~/JavaScripts/Layout/app.js"
                        ));

            bundles.Add(new StyleBundle("~/Css/BaseLayout").Include(
            "~/Css/Layout/bootstrap.min.css",
            "~/Fonts/font-awesome.min.css",
            "~/Css/Layout/ionicons.min.css",            
            "~/Css/Layout/AdminLTE.css",
            "~/Css/Layout/Custom.css"

            ));

            //SERVER REGISTER
            bundles.Add(new ScriptBundle("~/Js/Plugins/IpMask").Include(
            "~/JavaScripts/Plugins/Mask/IpMaskInt.js",
            "~/JavaScripts/Plugins/Mask/mask-plugin.js"
            ));

            //SERVER REGISTER
            bundles.Add(new ScriptBundle("~/Js/Plugins/Countdown").Include(
            "~/JavaScripts/Plugins/Countdown/countdown.js",
            "~/JavaScripts/Plugins/Countdown/HostTableInit.js"
            ));
        }
    }
}