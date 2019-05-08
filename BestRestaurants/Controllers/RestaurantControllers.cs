using Microsoft.AspNetCore.Mvc;
using BestRestaurant.Models;
using System.Collections.Generic;
using System;

namespace BestRestaurant.Controllers
{
  public class RestaurantController : Controller
  {

    [HttpGet("/restaurant")]
    public ActionResult Index()
    {
      // Animal newAnimal = new Animal();
      List<Restaurant> allRest = Restaurant.GetAll();
      return View(allRest);
    }

    // [HttpGet("/animals/new")]
    // public ActionResult New()
    // {
    //   return View();
    // }
    //
    // [HttpPost("/animals")]
    // public ActionResult Create(string type, string name, string sex, string breed, DateTime dateOfAdmit)
    // {
    //   Animal myAnimal = new Animal(type, name, sex, breed, dateOfAdmit);
    //   myAnimal.Save();
    //   return RedirectToAction("Index");
    // }
    // [HttpGet("/animals/SortByType")]
    // public ActionResult SortByType()
    // {
    //   // Animal newAnimal = new Animal();
    //   List<Animal> allSortedAnimals = Animal.SortByType();
    //   return View(allSortedAnimals);
    // }
  }
}
