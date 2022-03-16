using CRUD1.DataLayer;
using CRUD1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD1.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;

        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
      
        public IActionResult Index()
        {
            var item = _dbContext.cars.ToList();
            return View(item);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Cars car)
        {
            _dbContext.cars.Add(car);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(Guid Id)
        {
            Cars cars = _dbContext.cars.FirstOrDefault(p => p.Id == Id);
            return View(cars);
        }
        [HttpPost]
        public IActionResult Edit(Cars updateCars)
        {
            _dbContext.cars.Update(updateCars);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var item = _dbContext.cars.FirstOrDefault(p => p.Id == id);
            _dbContext.cars.Remove(item);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
       
    }
}
