using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Web.Views.ViewModels;

namespace Web.Controllers
{
    public class PortfolioItemsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IWebHostEnvironment hostingEnvironment;

        public PortfolioItemsController(IUnitOfWork unitOfWork,IWebHostEnvironment hostingEnvironment)
        {
            this.unitOfWork = unitOfWork;
            this.hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            var portfolioItemsDb = unitOfWork.PortfolioItems.GetAll();

            return View(portfolioItemsDb);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(PortfolioItemViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);

            }
            string uploads = Path.Combine(hostingEnvironment.WebRootPath, @"img\portfolio");
            string fullPath = Path.Combine(uploads, vm.File.FileName);
            var sr = new FileStream(fullPath, FileMode.Create);
            vm.File.CopyTo(sr);

            PortfolioItem portfolioItem = new PortfolioItem
            {
                Id = vm.Id,
                Description = vm.Description,
                ProjectName = vm.ProjectName,
                ImageUrl = vm.File.FileName
            };
            unitOfWork.PortfolioItems.Create(portfolioItem);
            unitOfWork.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            if (id == null)
                return NotFound();
            var portfolio = unitOfWork.PortfolioItems.GetById(id);
         
            if (portfolio == null)
                return NotFound();
            PortfolioItemViewModel vm = new PortfolioItemViewModel
            {
                Id = portfolio.Id,
                ImageUrl = portfolio.ImageUrl,
                ProjectName = portfolio.ProjectName,
                Description = portfolio.Description,
                LinkUrl = portfolio.LinkUrl
            };
            return View(vm);
        }
        [HttpPost]
        public IActionResult Edit(PortfolioItemViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            string fileName = vm.ImageUrl;
            if(vm.File != null)
            {
                string uploads = Path.Combine(hostingEnvironment.WebRootPath, @"img\portfolio");
                fileName = vm.File.FileName;
                string fullPath = Path.Combine(uploads,fileName);
                var sr = new FileStream(fullPath, FileMode.Create);
                vm.File.CopyTo(sr);
            }

            PortfolioItem portfolioItem = new PortfolioItem
            {
                Id = vm.Id,
                Description = vm.Description,
                ProjectName = vm.ProjectName,
                ImageUrl = fileName
            };
            unitOfWork.PortfolioItems.Update(portfolioItem);
            unitOfWork.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Details(Guid id)
        {
            if (id == null)
                return NotFound();
            var portfolioItem = unitOfWork.PortfolioItems.GetById(id);
            return View(portfolioItem);
        }
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            if (id == null)
                return NotFound();
            var portfolioItem = unitOfWork.PortfolioItems.GetById(id);
            return View(portfolioItem);
        }
        [HttpPost]
        public IActionResult ConfirmDelete(Guid id)
        {
            if (id == null)
                return NotFound();
            var portfolioItem = unitOfWork.PortfolioItems.GetById(id);
            unitOfWork.PortfolioItems.Delete(id);
            unitOfWork.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


    
    }
}
