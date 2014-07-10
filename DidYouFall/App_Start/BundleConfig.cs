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
            //CSS
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

                 bundles.Add(new StyleBundle("~/Css/Plugins/DataTable").Include(
                     "~/Css/Plugins/DataTable/dataTables.bootstrap.css"
                     ));

            //JS

                //Ram DataTable
                 bundles.Add(new ScriptBundle("~/Js/Plugins/DataTable").Include(
                     "~/JavaScripts/Plugins/DataTable/jquery.dataTables.js",
                     "~/JavaScripts/Plugins/DataTable/dataTables.bootstrap.js",
                     "~/JavaScripts/Plugins/DataTable/InitDataTable.js"
                     ));

                //Ram GRAPH
                bundles.Add(new ScriptBundle("~/Js/Plugins/Sparkline").Include(
                    "~/JavaScripts/Plugins/Sparkline/jquery.sparkline.min.js",
                    "~/JavaScripts/Plugins/Sparkline/InitRamPie.js"
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