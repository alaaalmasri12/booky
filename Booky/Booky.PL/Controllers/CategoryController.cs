using Booky.BL.Interfaces;
using Booky.BL.Repositories;
using Booky.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Booky.PL.Controllers
{
    public class CategoryController : Controller
    {
        //inject interface in a constructor
        //private readonly ICategoryRepository categoryRepository;

        //public CategoryController(ICategoryRepository categoryRepository)
        //{
        //    this.categoryRepository = categoryRepository;
        //}
        private readonly Iunitofwork _iunitofwork;

        public CategoryController(Iunitofwork iunitofwork)
        {
            this._iunitofwork = iunitofwork;
        }
        public IActionResult Index()
        {
            var Categories = _iunitofwork.CategoryRepository.GetAll();
            if (Categories is null)
                return BadRequest();

            return View(Categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
          return View();
        }

        [HttpPost]
        public IActionResult Create(Category model)
        {
            if(ModelState.IsValid)
            {
                _iunitofwork.CategoryRepository.Add(model);
                _iunitofwork.savechanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0 || id == null)
            {
                return BadRequest();
            }
            Category category = _iunitofwork.CategoryRepository.GetById(id);
            if (category is null)
            {
                return NotFound();

            }

            return View(category);
        }

        [HttpPost, ActionName("Delete")] // ActionName => because i called my action DeletePost and when the link inside index 
                                         // will check about Delete will found it 
        public IActionResult DeletePost(int id)
        {
            Category category = _iunitofwork.CategoryRepository.GetById(id);
            if (category is null)
            {
                return NotFound();
            }

            _iunitofwork.CategoryRepository.Delete(category);
            _iunitofwork.savechanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0 || id == null)
            {
                return BadRequest();
            }

            Category category = _iunitofwork.CategoryRepository.GetById(id);
            if (category is null)
            {
                return NotFound();
            }

            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _iunitofwork.CategoryRepository.Update(category);
                _iunitofwork.savechanges();
                TempData["success"] = "Category updated successfully";// this is a temp data for flash message => name pull request mean will not 
                                                                      // show just if updated success 
                return RedirectToAction("Index");

            }
            return View(category);
        }
    }
}
