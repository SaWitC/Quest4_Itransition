using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quest4.Data;
using Quest4.Models;


namespace Quest4.Controllers
{
    public class StatusModelController : Controller
    {
        private readonly Ouest4DBContetx _context;

        public StatusModelController(Ouest4DBContetx contetx)
        {
            _context = contetx;
        }
        // GET: StatusModelController
        public ActionResult Index()
        {
            return View(_context.Statuses);
        }

        // GET: StatusModelController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StatusModelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StatusModel status)
        {
            try
            {
                _context.Statuses.Add(status);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(status);
            }
        }

        // GET: StatusModelController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StatusModelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StatusModelController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StatusModelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
