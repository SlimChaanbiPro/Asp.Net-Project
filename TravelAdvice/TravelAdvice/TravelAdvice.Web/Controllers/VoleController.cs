using Newtonsoft.Json;
using PagedList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;



using TravelAdvice.Data;
using TravelAdvice.Data.Models;
using TravelAdvice.Domaine;
using TravelAdvice.Domaine.Entity;
using TravelAdvice.Service;
using TravelAdvice.Web.Models;

namespace TravelAdvice.Web.Controllers
{
    public class VoleController :Controller
    {

        private traveladviceContext db = new traveladviceContext();
        VoleService voleservice = null;
        ReservationService reservationService = null;
        user currentUser = null;
        public VoleController()
        {
            currentUser = new user();
            currentUser.id = 2;
            voleservice = new VoleService();
            reservationService = new ReservationService();


        }

        // GET: vole
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "type_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";


            if (searchString != null)
            {

                page = 1;
            }
            else { searchString = currentFilter; }

            ViewBag.CurrentFilter = searchString;


            var voles = from s in db.voles select s;
            voles = voles.OrderBy(s => s.depart);
            voles = voles.OrderBy(s => s.date_depart);

            if (!String.IsNullOrEmpty(searchString))
            {
                voles = voles.Where(s =>
        s.depart.ToUpper().Contains(searchString.ToUpper())
                                       ||
        s.destination.ToUpper().Contains(searchString.ToUpper()));
            }


           
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View(voles.ToPagedList(pageNumber, pageSize));
            //   return RedirectToAction("Index");

        }

        // GET: vole
        public ActionResult Search()
        {
            IEnumerable<vole> vols = voleservice.GetAllVolsFromNow();
            return View(vols);
            
        }

        

        // GET: Home/Reserver/5
        public ActionResult Reserver(int id)
        {

            reservationvole res = new reservationvole();
            res.vole_id = id;
            res.users_id = currentUser.id;
            res.date_reservation = DateTime.Now;
            reservationService.AddReservation(res);
            reservationService.SaveChange();

            IEnumerable<reservationvole> mesReservations = reservationService.GetAllReservationByUser(currentUser.id);
            foreach (var reservat in mesReservations)
            {
                int x;
                if (reservat.vole_id.HasValue)
                {
                    x = reservat.vole_id.Value;
                    reservat.vole = voleservice.GetVoleById(x);
                }
                
            }

            return View(mesReservations);

        }





        // GET: Home/Details/5
        public ActionResult Details(int id)

        {
          
            vole u = voleservice.GetVoleById(id);


            VoleModels lum = new VoleModels

            {
                id = u.id,
                depart = u.depart,
                destination = u.destination,
                prix_unitaire = u.prix_unitaire,
                nb_place = u.nb_place,
                date_depart = u.date_depart,
                date_arrive = u.date_arrive



            };

            ViewBag.nbrreservation = reservationService.nbreRservationByVole(lum.id);
            if (lum == null)
                return HttpNotFound();

            return View(lum);
        }






        // GET: Vole/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vole/Create
        [HttpPost]
        public ActionResult Create(VoleModels u)
        {
            vole h = new vole
            {
                id = u.id,
                date_arrive = u.date_arrive,
                date_depart = u.date_depart,
                depart = u.depart,
                destination = u.destination,
                nb_place = u.nb_place,

                prix_unitaire = u.prix_unitaire




            };

            voleservice.AddVole(h);
            voleservice.SaveChange();
            return RedirectToAction("Create");
        }



        // GET: House/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vole c = voleservice.GetVoleById(id);
            if (c == null)
            {
                return HttpNotFound();
            }

            return View(c);
        }

        // POST: House/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(vole c)
        {
            if (ModelState.IsValid)
            {
               voleservice.Update(c);
                return RedirectToAction("Index");
            }
            return View(c);
        }




        // GET: House/Delete/5
        public ActionResult Delete(int id)
        {


            voleservice.DeleteVole(id);
            var hs = voleservice.GetAllVole();
            return RedirectToAction("Index", hs);
        }

        // POST: House/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        [HttpGet]
        public ActionResult ListHouses()
        {
            List<VoleModels> pvm = new List<VoleModels>();
            IEnumerable<vole> prod = voleservice.GetAllVole();
            ////var off = c.GetOfferByPROUser(firstname);
            //return View(off);
            foreach (var u in prod)
            {

                VoleModels G = new VoleModels
                {
                    id = u.id,
                    depart = u.depart,
                    destination = u.destination,
                    prix_unitaire = u.prix_unitaire,
                    nb_place = u.nb_place,
                    date_depart = u.date_depart,
                    date_arrive = u.date_arrive


                };

                pvm.Add(G);

            }

            return View(pvm);
        }












        // GET: Reservation/AnnulerReservation/5
        public ActionResult AnnulerReservation(int id)
        {
            var hs = reservationService.GetAllReservationByUser(currentUser.id);
        
           



            reservationService.DeleteReservation(id);
           
            return RedirectToAction("Reserver", hs);
        }

        // POST: Resrvation/AnnulerReservation/5
        [HttpPost]
        public ActionResult AnnulerReservation(int id, FormCollection collection)
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



        ////////////////////////////////////////////////////////////// detail du reservation//////////////
        // GET: Home/Details/5
        public ActionResult DetailsReservation(int id)

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
               id=u.id,
                date_reservation = u.date_reservation,
               vole=u.vole
                



            };


            if (lum == null)
                return HttpNotFound();

            return View(lum);
        }



        public ActionResult StatTypeVole(int id )
        {
            //prepare array liste ro c#
            ArrayList Header = new ArrayList { "depart", "Vole" };
            Dictionary<string, int> volestat = reservationService.StatVole(id);
            ArrayList data = new ArrayList { Header };
            foreach (var s in volestat)
            {
                ArrayList d = new ArrayList { s.Key, s.Value };
                data.Add(d);
            }

            //convert it in json
            string datastr = JsonConvert.SerializeObject(data, Formatting.None);
            //sort in viwdata/viewbag
            ViewBag.nbrehouse = reservationService.nbreRservationByVole(id);
            ViewBag.Data = new HtmlString(datastr);
            return View();
        }


    }
}