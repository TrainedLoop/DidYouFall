﻿using DidYouFall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DidYouFall.Controllers
{
    public class RepositoryController : Controller
    {
        //
        // GET: /Repository/
        public ActionResult Index()
        {
            var script = new DataBase().GenerateUpdateSchema();
            ViewBag.ScriptUpdate = script.Replace("\n", "<br />");
            return View();
        }
	}
}