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


        // wybierz dzien, godzine, czas trwania, ilosc osob
        // pobierz wszystkie stoliki
        // pobierz rezerwacje anulowane
        // sprawdz czy sa wolne stoliki w wybranym przedziale czasowym
        // jeżeli conajmniej jeden stolik, wyswietl w tabeli mozliwe terminy rezerwacji
        // wybierz termin i dodaj rezerwacje



        // this function collects all actual reservations in given date, time, number of people
        // then finds free hours
        // send avaible terms into reservations controller
        // adds reservation after click on chossen term
        //[HttpPost]
        //public ActionResult AvaibleTerms(DateTime date, DateTime time, int duration, int numberOfPeople)
        //{


        //    DateTime dateTime = date;
        //    dateTime += time.TimeOfDay;

        //    var cancelledReservations = Uow.Repository<Reservation>().GetRange(
        //        r => r.Status != StatusReservation.Cancelled 
        //            && r.Start.Date == dateTime);

        //    var avaibleTimes = new List<TimeSpan>();
        //    for(int i=10; i< 22; i++)
        //    {
        //        for(int j=0; j<4; j++)
        //        {
        //            avaibleTimes.Add(new TimeSpan(i, j*15, 0));
        //        }
        //    }

        //    ViewBag.Termins = avaibleTimes;

        //    //var avaibleReservationsVM = Mapper.Map<IEnumerable<ReservationVm>>(avaibleReservations);
        //    return View(/*avaibleReservationsVM*/);
        //}


        [HttpGet]
        public IEnumerable<TimeSpan> GetFreeTerms(DateTime date, DateTime time, int duration, int people)
        {


            DateTime startTime = date;
            startTime += time.TimeOfDay;
            DateTime endTime = date.AddMinutes(duration);

            // find all tables with correct capacity
            var allTables = Uow.Repository<SmallTable>().GetRange(s => s.NumberOfChairs >= people);
            var tablesVm = Mapper.Map<IEnumerable<SmallTable>>(allTables);

            // find reserved tables
            var reserved = Uow.Repository<Reservation>().GetRange(
                r => r.Status == StatusReservation.Reserved
                    && r.Start.Date == startTime.Date);
                    //.SelectMany(r => r.SmallTables.Select(s => s.SmallTable).Distinct());
                                         
            var reservedVM = Mapper.Map<IEnumerable<Reservation>>(reserved);


            // filter out reserved, leave avaible


            var avaibleTimes = new List<TimeSpan>();
            //avaibleTimes.Clear(); // need to clear List, because by AJAX we are adding next terms
            var startTimeSpan = new TimeSpan(time.Hour, time.Minute, time.Second);
            var maxTimeSpan = new TimeSpan(22, 0, 0);
            var durationTimeSpan = new TimeSpan(0, duration, 0);

            if (duration != 0)
            {
                //int openHours = 22;
                //if (duration % 60 == 0) openHours -= 1 + duration/60;
                //int maxHour = 21;
                //int maxMinute = 45;
                for (var i = startTimeSpan; i < maxTimeSpan; i += durationTimeSpan)
                {
                    //if(duration%60>0)
                    //for (int j = 0; j <= 60; j+=duration%60)
                    //{
                        avaibleTimes.Add(new TimeSpan(i.Hours,i.Minutes,0));
                    //}
                    //else
                    //{
                    //    avaibleTimes.Add(new TimeSpan(i, 0, 0));
                    //}
                }


            }

            

            //ViewData.Clear();
            //ViewBag.Termins = avaibleTimes;

            //var avaibleReservationsVM = Mapper.Map<IEnumerable<ReservationVm>>(avaibleReservations);
            return avaibleTimes;
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
                var reservation = new Reservation();
                reservation.DateCreated = DateTime.Now;
                reservation.Duration = Convert.ToDateTime(collection["Duration"]);
                reservation.NumberOfPeople = Convert.ToInt32(collection["NumberOfPeople"]);
                //reservation.SmallTables = new SmallTableReservation(1,1,1,1);
                reservation.Start = Convert.ToDateTime(collection["Start"]);
                reservation.Status = StatusReservation.Reserved;
                reservation.UserId = _userManager.GetUserId(User);
                // TODO: Add insert logic here
                Uow.Repository<Reservation>().Add(reservation);
                Uow.Save();
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