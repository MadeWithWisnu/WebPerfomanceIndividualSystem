﻿using Microsoft.AspNetCore.Mvc;

namespace WebPerfomanceIndividualSystem.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
