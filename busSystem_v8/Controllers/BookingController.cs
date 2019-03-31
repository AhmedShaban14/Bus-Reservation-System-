using busSystem_v8.View_Models;
using busSystem_v8.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace busSystem_v8.Controllers
{
    public class BookingController : Controller
    {
        BusSystemDB db = new BusSystemDB();
        User info;
        /*
        [HttpGet]
        public ActionResult AddTrip()
        {


            return View();
        }

        [HttpPost]
        public ActionResult AddTrip(UserBooking ur)
        {
            ur.books.trips.StartDate = ur.books.trips.StartDate;
            DateTime sd = ur.books.trips.StartDate.Value;
            sd = sd.AddDays(1);
            DateTime ed = sd;
            ur.books.trips.EndDate = ed;

            //  ViewBag.date1 = sd.ToString();

            ViewBag.date = ed.ToString();


            ur.books.trips.Lines_Id = 1;
            ur.books.trips.Dayes_Id = 1;

            db.trip.Add(ur.books.trips);
            db.SaveChanges();

            return View(ur);
        }
        */
        //Add New Booking :

        #region
        public ActionResult New()
        {
            info = Session["userData"] as User;
            if (info != null)
            {
                if (info.user_types_id == 2)
                {
                    var buses = db.buses.ToList();
                    var payTypes = db.payment_Type.ToList();
                    var linesDb = db.lines.ToList();
                    var tripsDb = db.trip.ToList();
                    UserBooking ub = new UserBooking
                    {
                        payment_Types = payTypes,
                        lines = linesDb,
                        buses = buses,
                        trips = tripsDb
                    };
                    return View(ub);
                }
                else
                {
                    return RedirectToAction("page_error_400", "Dashboard");
                }
            }
            else
            {
                return RedirectToAction("page_error_400", "Dashboard");
            }
        }
        [HttpPost]
        public ActionResult New(UserBooking ub)
        {
            info = Session["userData"] as User;
            if (info != null)
            {
                if (info.user_types_id == 2)
                {
                    #region
                    if (ModelState.IsValid)
                    {
                        //Calculate Number Of Available Sets : 
                        var busId = db.buses.SingleOrDefault(x => x.BusID == ub.books.Bus_Id);
                        var busAvaSets = busId.AvailableSeats;
                        var choseenChairs = ub.books.chosenChairs;
                        if (busAvaSets < choseenChairs)
                        { return Json(new { result = 0 }); }
                        //Update Available sets : 
                        busAvaSets = busAvaSets - choseenChairs;
                        busId.AvailableSeats = busAvaSets;
                        //Trip Id:
                        var TId = db.trip.Find(ub.books.Trip_ID);
                        //User Id :
                        var U_Name = db.users.Where(x => x.Name == ub.user.Name).SingleOrDefault();

                        //   var U_Name = db.users.SingleOrDefault(x => x.UserID == ub.books.User_id);
                        if (U_Name == null)
                        { return Json(new { result = 0 }); }
                        var NumOfChairs = choseenChairs;
                        var TripCost = TId.tripCost;
                        var BusCost = busId.Price;
                        var TotalCost = NumOfChairs * TripCost + BusCost;
                        var u_Wallet = U_Name.wallet;
                        if (TotalCost > u_Wallet)
                        { return Json(new { result = 0 }); }
                        u_Wallet -= TotalCost;
                        U_Name.wallet = u_Wallet;
                        ub.books.User_id = U_Name.UserID;
                        ub.books.Bus_Id = busId.BusID;
                        ub.books.TotalCost = TotalCost;
                        //  if (ub.books.Trip_ID != ub.books.Line_Id)
                        // { return Json(new { result = 0 }); }
                        db.booking.Add(ub.books);
                        db.SaveChanges();
                        return Json(new { result = 1 });
                    }
                    else
                    { return Json(new { result = 0 }); }
                    #endregion
                }
                else
                {
                    return RedirectToAction("page_error_400", "Dashboard");
                }
            }

            else
            {
                return RedirectToAction("page_error_400", "Dashboard");
            }
        }

        //With Out View Just To Select From DB
        [HttpGet]
        public ActionResult getTo(int id)
        {
            info = Session["userData"] as User;
            if (info != null)
            {
                if (info.user_types_id == 2)
                {
                    var LineId = db.lines.SingleOrDefault(x => x.Id == id);
                    var LineFrom = LineId.From;
                    var c = db.lines.Where(x => x.From == LineFrom).ToList();
                    return Json(c, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return RedirectToAction("page_error_400", "Dashboard");
                }
            }
            else
            {
                return RedirectToAction("page_error_400", "Dashboard");
            }
        }
        [HttpGet]
        public ActionResult Trips(int id)
        {
            info = Session["userData"] as User;
            if (info != null)
            {
                if (info.user_types_id == 2)
                {
                    var LineId = db.lines.SingleOrDefault(x => x.Id == id);
                    var LId = LineId.Id;
                    // var trip = db.trip.SingleOrDefault(x => x.Id == x.Lines_Id);
                    var tr = db.trip.Where(x => x.Lines_Id == LId).ToList();
                    //  var tr = db.trip.SingleOrDefault(x => x.Lines_Id == LId);
                    //var trStart = tr.StartDate;
                    //  var trIds= db.trip.Where(x => x.StartDate ==trStart).ToList();
                    //  var tr = db.trip.Where(x => x.Lines_Id == LId).ToList();
                    // var t = db.trip.Where(x=>x.StartDate == LId)
                    return Json(tr, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return RedirectToAction("page_error_400", "Dashboard");
                }
            }
            else
            {
                return RedirectToAction("page_error_400", "Dashboard");
            }
        }
        [HttpGet]
        public ActionResult Buses(int id)
        {
            info = Session["userData"] as User;
            if (info != null)
            {
                if (info.user_types_id == 2)
                {
                    var TripId = db.trip.SingleOrDefault(x => x.Id == id);
                    var TId = TripId.Id;
                    var bs = db.buses.Where(x => x.trip_id == TId).ToList();
                    return Json(bs, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return RedirectToAction("page_error_400", "Dashboard");
                }
            }
            else
            {
                return RedirectToAction("page_error_400", "Dashboard");
            }
        }
        //Edit Booking :
        [HttpGet]
        public ActionResult EditBook(int? id)
        {
            info = Session["userData"] as User;
            if (info != null)
            {
                if (info.user_types_id == 2)
                {
                    var bookingDb = db.booking.SingleOrDefault(x => x.BokkingID == id);
                    var payTypesDb = db.payment_Type.ToList();
                    var linesDb = db.lines.ToList();
                    var busesDb = db.buses.ToList();
                    var TripStart = db.trip.ToList();
                    UserBooking ub = new UserBooking
                    {
                        payment_Types = payTypesDb,
                        lines = linesDb,
                        books = bookingDb,
                        buses = busesDb,
                        trips = TripStart
                    };
                    return View(ub);
                }
                else
                {
                    return RedirectToAction("page_error_400", "Dashboard");
                }
            }
            else
            {
                return RedirectToAction("page_error_400", "Dashboard");
            }
        }
        [HttpPost]
        public ActionResult EditBook(UserBooking ub)
        {
            info = Session["userData"] as User;
            if (info != null)
            {
                if (info.user_types_id == 2)
                {
                    if (ModelState.IsValid)
                    {
                        var bookingDb = db.booking.SingleOrDefault(x => x.BokkingID == ub.books.BokkingID);
                        //Calculate Number Of Available Sets : 
                        var busId = db.buses.SingleOrDefault(x => x.BusID == ub.books.Bus_Id);
                        var busAvaSets = busId.AvailableSeats;
                        var choseenChairs = ub.books.chosenChairs;
                        if (busAvaSets < choseenChairs)
                        {
                            return Json(new { result = 0 });
                        }
                        //Trip Id:
                        var TId = db.trip.Find(ub.books.Trip_ID);
                        //User Id :
                        var U_Name = db.users.Where(x => x.Name == ub.books.users.Name).SingleOrDefault();
                        if (U_Name == null)
                            return Json(new { result = 0 });
                        //var BusId = db.buses.Find(ub.books.Bus_Id);
                        var NumOfChairs = ub.books.chosenChairs;
                        var TripCost = TId.tripCost;
                        var BusCost = busId.Price;
                        //  var TotalCost = NumOfChairs * TripCost + BusCost;
                        var OldCost = bookingDb.TotalCost;
                        var TotalCost = OldCost;
                        var NewChair = NumOfChairs;
                        var NewChairs = Convert.ToDecimal(NewChair);
                        var NewChairsCost = 0.00;
                        var NewChairCost = Convert.ToDecimal(NewChairsCost);
                        var u_Wallet = U_Name.wallet;

                        if (bookingDb.chosenChairs != ub.books.chosenChairs)
                        {
                            if (ub.books.chosenChairs > bookingDb.chosenChairs)
                            {
                                //New chairs =Number chairs (ub.books.chairs)-Chairs in Db :
                                NewChairs -= bookingDb.chosenChairs;
                                NewChairCost = NewChairs * (TripCost + BusCost);
                                TotalCost += NewChairCost;
                                u_Wallet -= NewChairCost;
                            }
                            if (ub.books.chosenChairs < bookingDb.chosenChairs)
                            {
                                NewChairs = bookingDb.chosenChairs - NewChairs;
                                NewChairCost = NewChairs * (TripCost + BusCost);
                                TotalCost -= NewChairCost;
                                u_Wallet += NewChairCost;
                            }
                        }
                        if (TotalCost > u_Wallet)
                        {
                            return Json(new { result = 0 });
                        }
                        U_Name.wallet = u_Wallet;
                        bookingDb.chosenChairs = ub.books.chosenChairs;
                        bookingDb.TotalCost = TotalCost;
                        bookingDb.User_id = U_Name.UserID;
                        bookingDb.Line_Id = ub.books.Line_Id;
                        bookingDb.Payment_Type_Id = ub.books.Payment_Type_Id;
                        bookingDb.Bus_Id = ub.books.Bus_Id;
                        //if (ub.books.Trip_ID != ub.books.Line_Id)
                        //{
                        //    return Json(new { result = 0 });
                        //}
                        db.SaveChanges();
                        return Json(new { result = 1 });
                    }
                    else
                    {
                        return Json(new { result = 0 });
                    }
                }
                else
                {
                    return RedirectToAction("page_error_400", "Dashboard");
                }
            }
            else
            {
                return RedirectToAction("page_error_400", "Dashboard");
            }

        }
        //Delete Booking : 
        [HttpGet]
        public ActionResult DeleteBook(int id)
        {
            info = Session["userData"] as User;
            if (info != null)
            {
                if (info.user_types_id == 2)
                {
                    var bookingDb = db.booking.SingleOrDefault(x => x.BokkingID == id);
                    db.booking.Remove(bookingDb);
                    db.SaveChanges();
                    //return RedirectToAction("BookThird");
                    return Json(new { result = 1 }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return RedirectToAction("page_error_400", "Dashboard");
                }
            }
            else
            {
                return RedirectToAction("page_error_400", "Dashboard");
            }
        }
        //Display All Booking Details : 
        public ActionResult BookThird()
        {
            info = Session["userData"] as User;
            if (info != null)
            {
                if (info.user_types_id == 2)
                {
                    //   Booking b = new Booking();
                    //            var bookingDb = db.booking.SingleOrDefault(x=>x.BokkingID==id);
                    var bookingDb = db.booking.ToList();
                    return View(bookingDb);
                }
                else
                {
                    return RedirectToAction("page_error_400", "Dashboard");
                }
            }
            else
            {
                return RedirectToAction("page_error_400", "Dashboard");
            }
        }

        //Display Booking Details For Specific User :
        [HttpGet]
        public ActionResult BookDetailsNew(int id)
        {
            info = Session["userData"] as User;
            if (info != null)
            {
                if (info.user_types_id == 2)
                {
                    var bookingDb = db.booking.SingleOrDefault(x => x.BokkingID == id);
                    return View(bookingDb);
                }
                else
                {
                    return RedirectToAction("page_error_400", "Dashboard");
                }
            }
            else
            {
                return RedirectToAction("page_error_400", "Dashboard");
            }
        }

        //Another Way To Display Booking Details For Specific User:    
        [HttpGet]
        public ActionResult BookDetailsNewTry(int? id)
        {
            User info;

            info = Session["userData"] as User;
            if (info != null)
            {
                if (info.user_types_id == 2)
                {
                    var bookingDb = db.booking.SingleOrDefault(x => x.BokkingID == id);
                    UserBooking ub = new UserBooking();
                    Booking b = new Booking();
                    var busDetail = db.buses.Where(m => m.BusID == bookingDb.Bus_Id).SingleOrDefault();
                    b.chosenChairs = bookingDb.chosenChairs;
                    b.Buses.DriverName = bookingDb.Buses.DriverName;
                    return View(b);
                }
                else
                {
                    return RedirectToAction("page_error_400", "Dashboard");
                }
            }
            else
            {
                return RedirectToAction("page_error_400", "Dashboard");
            }
        }
        //Customer Add,Edit,Delete,Display :
        // GET: Booking
        public ActionResult BookingIndex()
        {
            info = Session["userData"] as User;
            if (info != null)
            {
                if (info.user_types_id == 2)
                {
                    var customers = db.users.ToList();
                    return View(customers);
                }
                else
                {
                    return RedirectToAction("page_error_400", "Dashboard");
                }
            }
            else
            {
                return RedirectToAction("page_error_400", "Dashboard");
            }
        }
        public ActionResult Details(int id)
        {
            info = Session["userData"] as User;
            if (info != null)
            {
                if (info.user_types_id == 2)
                {
                    var cust = db.users.SingleOrDefault(x => x.UserID == id);
                    return View(cust);
                }
                else
                {
                    return RedirectToAction("page_error_400", "Dashboard");
                }
            }
            else
            {
                return RedirectToAction("page_error_400", "Dashboard");
            }
        }
        [HttpGet]
        public ActionResult EditCust(int id)
        {
            info = Session["userData"] as User;
            if (info != null)
            {
                if (info.user_types_id == 2)
                {
                    var cust = db.users.SingleOrDefault(x => x.UserID == id);
                    return View(cust);
                }
                else
                {
                    return RedirectToAction("page_error_400", "Dashboard");
                }
            }
            else
            {
                return RedirectToAction("page_error_400", "Dashboard");
            }
        }
        [HttpPost]
        public ActionResult EditCust(User us)
        {
            info = Session["userData"] as User;
            if (info != null)
            {
                if (info.user_types_id == 2)
                {
                    var cust = db.users.SingleOrDefault(x => x.UserID == us.UserID);
                    cust.Name = us.Name;
                    cust.Password = us.Password;
                    cust.Email = us.Email;
                    db.SaveChanges();
                    return RedirectToAction("BookingIndex");
                }
                else
                {
                    return RedirectToAction("page_error_400", "Dashboard");
                }
            }
            else
            {
                return RedirectToAction("page_error_400", "Dashboard");
            }
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            info = Session["userData"] as User;
            if (info != null)
            {
                if (info.user_types_id == 2)
                {
                    var cust = db.users.SingleOrDefault(x => x.UserID == id);
                    db.users.Remove(cust);
                    db.SaveChanges();
                    return RedirectToAction("BookingIndex");
                }
                else
                {
                    return RedirectToAction("page_error_400", "Dashboard");
                }
            }

            else
            {
                return RedirectToAction("page_error_400", "Dashboard");
            }
        }
        #endregion


    }
}