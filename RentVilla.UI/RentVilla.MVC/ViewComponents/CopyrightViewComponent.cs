﻿using Microsoft.AspNetCore.Mvc;

namespace RentVilla.MVC.ViewComponents
{
    public class CopyrightViewComponent: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
