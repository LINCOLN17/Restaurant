using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Core.Interfaces.UoW;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using Restaurant.BLL.Entities;
using Restaurant.DAL.EF;
using AutoMapper;
using Restaurant.ViewModels;

namespace Restaurant.Web.Controllers
{
    public class ReservationsController : BaseController
    {
        private readonly UserManager<User> _userManager;
        

        public ReservationsController(UserManager<User> userManager, IUnitOfWork uow, ILoggerFactory loggerFactory) : base(uow, loggerFactory)
        {
            _userManager = userManager;
        }

        // GET: Reservations
        public ActionResult Index()
        {

            var uId = _userManager.GetUserId(User);

            //string uid = User.Identity.GetUserId();
            if (User.IsInRole("User"))
            {
                var reservationEntities = Uow.Repository<Reservation>().GetRange(r => r.UserId == uId);
                var reservationVm = Mapper.Map<IEnumerable<ReservationVm>>(reservationEntities);
                return View(reservationVm);
            }



            return RedirectToAction("Index", "Home");
        }

        // GET: Reservations/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reservations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reservations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Reservations/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Reservations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Reservations/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reservations/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}