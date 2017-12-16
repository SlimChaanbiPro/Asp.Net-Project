using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelAdvice.Data.Models;
using TravelAdvice.Domaine.Entity;
using TravelAdvice.Service;
using TravelAdvice.Web.Models;
using Rotativa;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace TravelAdvice.Web.Controllers
{
    public class ReservationController : Controller
    {

        private traveladviceContext db = new traveladviceContext();
        VoleService voleservice = null;
        ReservationService reservationService = null;
        user currentUser = null;



        public ReservationController()
        {
            currentUser = new user();
            currentUser.id = 2;
            voleservice = new VoleService();
            reservationService = new ReservationService();


        }
        // GET: Reservation
        public ActionResult Indexreservation(string sortOrder, string currentFilter, string searchString, int? page)
        {
           
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "type_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {

                page = 1;
            }
            else { searchString = currentFilter; }

            ViewBag.CurrentFilter = searchString;


            IEnumerable<reservationvole> reservationvoles = reservationService.GetAllReservationByUser(currentUser.id);
            reservationvoles = reservationvoles.OrderBy(s => s.date_reservation);
            

            if (!String.IsNullOrEmpty(searchString))
            {
   
            }



            int pageSize = 4;
            int pageNumber = (page ?? 1);
            ViewBag.nbrereservation = reservationService.NbreReservation(currentUser.id);
            return View(reservationvoles.ToPagedList(pageNumber, pageSize));

        }

        // GET: Reservation/Details/5
        public ActionResult Details(int id)
        {

            int x;

            reservationvole u = reservationService.GetReservationById(id);
            if (u.vole_id.HasValue)
            {
                x = u.vole_id.Value;
                u.vole = voleservice.GetVoleById(x);
            }

            ReservationVolModels lum = new ReservationVolModels

            {
                id = u.id,
                date_reservation = u.date_reservation,
                vole = u.vole




            };


            if (lum == null)
                return HttpNotFound();

            return View(lum);
        }

        // GET: Reservation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reservation/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reservation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Reservation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reservation/Delete/5
        public ActionResult Delete(int id)
        {


            reservationService.DeleteReservation(id);
            var hs = reservationService.GetAllReservationByUser(currentUser.id);
            return RedirectToAction("Indexreservation", hs);
        }

        // POST: House/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                
                // TODO: Add delete logic here

                return RedirectToAction("Indexreservation");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Search()
        {
            IEnumerable<vole> vols = voleservice.GetAllVolsFromNow();
            return View(vols);

        }


        public ActionResult ReserverVole(int id)
        {
            reservationvole res = new reservationvole();
            res.vole_id = id;
            res.users_id = currentUser.id;
            res.date_reservation = DateTime.Now;
            reservationService.AddReservation(res);
            reservationService.SaveChange();

            
            IEnumerable<vole> vols = voleservice.GetAllVolsFromNow();
            return RedirectToAction("Search", vols);
        }

        // POST: House/Delete/5
        [HttpPost]
        public ActionResult ReserverVole(int id, FormCollection collection)
        {
            try
            {
               
                // TODO: Add delete logic here

                return RedirectToAction("Search");
            }
            catch
            {
                return View();
            }






        }

        ///////////////////////////////////////////////pdf//////////////////////////////

        public ActionResult ExportPDF()
        {



            return new ActionAsPdf("Indexreservation")
            {
                FileName=Server.MapPath("~/Content/reservationvole.pdf")

            };
            
           
        }

        public ActionResult Export1()
        {



            return new ActionAsPdf("Details")
            {
                FileName = Server.MapPath("~/Content/reservationvole.pdf")

            };


        }
        ///////////////////////////////////


    }
}
