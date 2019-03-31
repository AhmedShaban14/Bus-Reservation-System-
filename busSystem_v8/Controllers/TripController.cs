using busSystem_v8.Models;
using busSystem_v8.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace busSystem_v8.Controllers
{
    public class TripController : Controller
    {
        BusSystemDB DB = new BusSystemDB();

        // GET: Trip

        /*****************************  all Trips *****************************/
        [HttpGet]
        public ActionResult AllTrips()
        {
            Trip tr = new Trip();
          
            var trips = DB.trip.ToList();
            return View(trips);
        }
        /********************************** show singl trip*******************/
        [HttpGet]
        public ActionResult showTrip(int id)
        {
            var Trip = DB.trip.Single(c => c.Id == id);

            return View(Trip);
        }


        /**************************    Add Trip ***************************/
        // GET: Line
        [HttpGet]
        public ActionResult AddTrip()
        {
            // var l = DB.lines;
            var Line = DB.lines.ToList();
            var Day = DB.days.ToList();
            var bus = DB.buses.ToList();
            Trip_line_Day_View_Model trip = new Trip_line_Day_View_Model
            {
                lin = Line,
                dy = Day,
                buslist = bus

            };
            // trip.fron_to = trip.trip.StartDate +"-"+ trip.trip.EndDate;

            return View(trip);
        }

        /*###*/
        [HttpPost]
        public ActionResult AddTrip(Trip_line_Day_View_Model trip)
        {

            if (ModelState.IsValid)
            {
                DB.trip.Add(trip.tr);
                DB.SaveChanges();
                int TripInsertedId = trip.tr.Id;

                var busDb = DB.buses.Single(c => c.BusID == trip.bus.BusID);
                busDb.trip_id = trip.tr.Id;
                DB.SaveChanges();

                return Json(new { result = 1});
            }

            var Line = DB.lines.ToList();
            var Day = DB.days.ToList();
            var bus = DB.buses.ToList();

            trip.lin = Line;
            trip.dy = Day;
            trip.buslist = bus;


            return Json(new { result = 0 });
            /*
            if (!ModelState.IsValid)
            {
                var Line = DB.lines.ToList();
                var Day = DB.days.ToList();
                var bus = DB.buses.ToList();

                trip.lin = Line;
                trip.dy = Day;
                trip.buslist = bus;


                return View("AddTrip", trip);
            }
            

            DB.trip.Add(trip.tr);
            DB.SaveChanges();
            int TripInsertedId = trip.tr.Id;

            var busDb = DB.buses.Single(c => c.BusID == trip.bus.BusID);
            busDb.trip_id = trip.tr.Id;
            DB.SaveChanges();

            return RedirectToAction("AllTrips");
            */
        }


        /********************************** edit trip **************************/
        [HttpGet]
        public ActionResult EditTrip(int id)
        {
            var trip = DB.trip.Single(c => c.Id == id);
            var Line = DB.lines.ToList();
            var Day = DB.days.ToList();
            var bus = DB.buses.ToList();

            Trip_line_Day_View_Model trip_view = new Trip_line_Day_View_Model
            {
                tr=trip,
                lin = Line,
                dy = Day,
                buslist = bus
            };

            return View(trip_view);
        }

        /*###*/
        [HttpPost]
        public ActionResult EditTrip(Trip_line_Day_View_Model trip)
        {
            
            if (ModelState.IsValid)
            {
                var tripDB = DB.trip.Single(c => c.Id == trip.tr.Id);
                tripDB.StartDate = trip.tr.StartDate;
                tripDB.EndDate = trip.tr.EndDate;
                tripDB.Dayes_Id = trip.tr.Dayes_Id;
                tripDB.Lines_Id = trip.tr.lines.Id;
                DB.SaveChanges();

                return Json(new { result =  1});
            }
            var Line = DB.lines.ToList();
            var Day = DB.days.ToList();
            var bus = DB.buses.ToList();

            trip.lin = Line;
            trip.dy = Day;
            trip.buslist = bus;

            return Json(new { result = 0 } );
            /*
            var tripDB = DB.trip.Single(c => c.Id == trip.tr.Id);

            if (!ModelState.IsValid)
            {
                var Line = DB.lines.ToList();
                var Day = DB.days.ToList();
                var bus = DB.buses.ToList();

                trip.lin = Line;
                trip.dy = Day;
                trip.buslist = bus;

                return View("EditLine", trip);
            }
            tripDB. StartDate= trip.tr.StartDate;
            tripDB.EndDate = trip.tr.EndDate;
            tripDB.Dayes_Id = trip.tr.Dayes_Id;
            tripDB.Lines_Id = trip.tr.Lines_Id;
            DB.SaveChanges();

            return RedirectToAction("AllTrips");
            */
        }
        /*******************************  delete trip *********************/
        [HttpGet]
        public ActionResult DeleteTrip(int id)
        {
            var trip = DB.trip.SingleOrDefault(c => c.Id == id);
            DB.trip.Remove(trip);
            // DB.Entry(line).State = EntityState.Deleted;
            DB.SaveChanges();
            return Json(new { result = 1 }, JsonRequestBehavior.AllowGet);

            //  return RedirectToAction("AllTrips");
        }
        /***************************************** get to trip **************************/

        public ActionResult GetToTrip( int id)
        {
            var line_from_id = DB.lines.SingleOrDefault(x=>x.Id == id);
            var from = line_from_id.From;
            var All_from = DB.lines.Where(m => m.From == from).ToList();

            return Json(All_from, JsonRequestBehavior.AllowGet);
        }
        
    }
}