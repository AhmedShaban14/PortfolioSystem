using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Views.ViewModels;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public HomeController( IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            OwnerPortFolioViewModel vm = new OwnerPortFolioViewModel
            {
                Owner=unitOfWork.Owners.GetOwner(),
                PortfolioItems = unitOfWork.PortfolioItems.GetAll()
            };
            return View(vm);
        }
    }
}
