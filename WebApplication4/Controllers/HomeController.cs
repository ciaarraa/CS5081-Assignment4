using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        PersistentModel model = PersistentModel.Instance;

        public IActionResult Index()
        {
            return View(model);
        }

        public IActionResult PersonForm(int? id)
        {
            PersonModel selected = null;

            if (id != null)
            {
                selected = model.findPerson((int)id);
            }

            if (selected == null)
            {
                selected = new PersonModel();
            }

            return View(selected);
        }

        [HttpPost]
        public IActionResult PersonSave(PersonModel person)
        {
            model.updatePerson(person);
            return RedirectToAction("Index");
        }

        public IActionResult PersonRemove(int id)
        {
            model.removePerson(id);
            return RedirectToAction("Index");
        }

        public IActionResult JobList()
        {
            return View(model);
        }

        public IActionResult Dummy(int? id)
        {
            PersonModel selected = null;

            if (id != null)
            {
                selected = model.findPerson((int)id);
            }

            if (selected == null)
            {
                selected = new PersonModel();
            }

            return View(selected);
        }


        public IActionResult JobForm(int? id)
        {
            JobModel selected = null;

            if (id != null)
            {
                selected = model.findJob((int)id);
            }

            if (selected == null)
            {
                selected = new JobModel();
            }

            return View(selected);
        }

        public IActionResult DependantList(int? id)
        {
            DependantModel selected = null;

            if (id != null)
            {
                selected = model.findDependantModel((int)id);
            }

            if (selected == null)
            {
                selected = new DependantModel();
            }

            return View(selected);
        }

        public IActionResult DependantRemove(int id)
        {

            DependantModel selected = model.findEnclosingList(id);
            selected.removeDependant(id);
            return RedirectToAction("Index");

        }

        
        public IActionResult AddDependant(int id, string name)
        {
            model.addDependant(id, name);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult JobSave(JobModel job)
        {
            model.updateJob(job);
            return RedirectToAction("Index");
        }

        public IActionResult JobRemove(int id)
        {
            model.removeJob(id);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}
