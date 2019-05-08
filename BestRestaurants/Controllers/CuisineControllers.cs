// using Microsoft.AspNetCore.Mvc;
// using AnimalShelter.Models;
// using System.Collections.Generic;
// using System;
//
// namespace AnimalShelter.Controllers
// {
//   public class AnimalsController : Controller
//   {
//
//     [HttpGet("/animals")]
//     public ActionResult Index()
//     {
//       // Animal newAnimal = new Animal();
//       List<Animal> allAnimals = Animal.GetAll();
//       return View(allAnimals);
//     }
//
//     [HttpGet("/animals/new")]
//     public ActionResult New()
//     {
//       return View();
//     }
//
//     [HttpPost("/animals")]
//     public ActionResult Create(string type, string name, string sex, string breed, DateTime dateOfAdmit)
//     {
//       Animal myAnimal = new Animal(type, name, sex, breed, dateOfAdmit);
//       myAnimal.Save();
//       return RedirectToAction("Index");
//     }
//     [HttpGet("/animals/SortByType")]
//     public ActionResult SortByType()
//     {
//       // Animal newAnimal = new Animal();
//       List<Animal> allSortedAnimals = Animal.SortByType();
//       return View(allSortedAnimals);
//     }
//   }
// }
