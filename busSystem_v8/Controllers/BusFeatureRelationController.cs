using busSystem_v8.Models;
using busSystem_v8.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace busSystem_v8.Controllers
{
    public class BusFeatureRelationController : Controller
    {
        BusSystemDB DB = new BusSystemDB();
        // GET: BusFeature
        User info;
            /*********************** show all buses ****************************/
        public ActionResult AllBuses()
        {
            info = Session["userData"] as User;
            if (info != null)
            {
                if (info.user_types_id == 1)
                {
                    var busfeatures = DB.busFeautersRelations.ToList();
                    return View(busfeatures);
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

        /********************  add bus & features & ralation with busFeaturesRelation class   ****************/

        [HttpGet]
        public ActionResult AddBusWithFeature()
        {
            info = Session["userData"] as User;
            if (info != null)
            {
                if (info.user_types_id == 1)
                {
                    return View();
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
        public ActionResult AddBusWithFeature(BusFeautersRelation bfvm)
        {
            info = Session["userData"] as User;
            if (info != null)
            {
                if (info.user_types_id == 1)
                {
                    if (ModelState.IsValid)
                    {
                        BusFeautersRelation relation = new BusFeautersRelation();

                        relation.Bus_Id = bfvm.Buses.BusID;
                        relation.BusFeatures_Id = bfvm.BusFeatures.ID;


                        DB.buses.Add(bfvm.Buses);
                        DB.busFeatures.Add(bfvm.BusFeatures);
                        DB.busFeautersRelations.Add(relation);
                        DB.SaveChanges();


                        return Json(new { result = 1 });

                    }
                    return Json(new { result = 0 });
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
            #region
            /*
            if (!ModelState.IsValid)
            {
                return View("AddBusWithFeature", bfvm);
            }
            BusFeautersRelation relation = new BusFeautersRelation();

            relation.Bus_Id = bfvm.Buses.BusID;
            relation.BusFeatures_Id = bfvm.BusFeatures.ID;


            DB.buses.Add(bfvm.Buses);
            DB.busFeatures.Add(bfvm.BusFeatures);
            DB.busFeautersRelations.Add(relation);
            DB.SaveChanges();


            return RedirectToAction("AllBuses");*/
            #endregion
        }

        /****************************        Edit bus with feature   *******************************************/
        [HttpGet]
        public ActionResult EditBusWithFeature(int id)
        {
            info = Session["userData"] as User;
            if (info != null)
            {
                if (info.user_types_id == 1)
                {
                    var bus = DB.busFeautersRelations.Single(c => c.Bus_Id == id);
                    return View(bus);
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
        public ActionResult EditBusWithFeature(BusFeautersRelation bfvm)
        {
            info = Session["userData"] as User;
            if (info != null)
            {
                if (info.user_types_id == 1)
                {
                    if (!ModelState.IsValid)
                    {
                        return View("EditBusWithFeature", bfvm);
                    }
                    var BusEdit = DB.busFeautersRelations.Single(c => c.Buses.BusID == bfvm.Buses.BusID);

                    BusEdit.Buses.BusID = bfvm.Buses.BusID;
                    BusEdit.Buses.AvailableSeats = bfvm.Buses.AvailableSeats;
                    BusEdit.Buses.Color = bfvm.Buses.Color;
                    BusEdit.Buses.CompanyName = bfvm.Buses.CompanyName;
                    BusEdit.Buses.DriverName = bfvm.Buses.DriverName;
                    BusEdit.Buses.NumOfBags = bfvm.Buses.NumOfBags;
                    BusEdit.Buses.NumOfSeats = bfvm.Buses.NumOfSeats;
                    BusEdit.Buses.BusNumber = bfvm.Buses.AvailableSeats;
                    BusEdit.Buses.Price = bfvm.Buses.Price;
                    BusEdit.Buses.trip_id = bfvm.Buses.trip_id;

                    var feature = DB.busFeautersRelations.Single(c => c.BusFeatures.ID == bfvm.BusFeatures.ID);
                    feature.BusFeatures.AirConditioner = bfvm.BusFeatures.AirConditioner;
                    feature.BusFeatures.Drinks = bfvm.BusFeatures.Drinks;
                    feature.BusFeatures.Food = bfvm.BusFeatures.Food;
                    feature.BusFeatures.TV = bfvm.BusFeatures.TV;
                    feature.BusFeatures.Wc = bfvm.BusFeatures.Wc;
                    feature.BusFeatures.wifi = bfvm.BusFeatures.wifi;
                    #region
                    /*
                    var relation = DB.busFeautersRelations.Single(c => c.Bus_Id == bfvm.BusFeatures.ID);
                    relation.Bus_Id = bfvm.Bus_Id;
                    relation.BusFeatures_Id = bfvm.BusFeatures_Id;
                        */
                    //DB.buses.Add(BusEdit.Buses);
                    // DB.busFeatures.Add(feature);
                    //  DB.busFeautersRelations.Add(relation);
                    #endregion
                    DB.SaveChanges();
                    return RedirectToAction("AllBuses");
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

        /************************************ show spacific bus *********************/
        [HttpGet]
        public ActionResult showBusWithFeature(int id)
        {
            info = Session["userData"] as User;
            if (info != null)
            {
                if (info.user_types_id == 1)
                {
                    var bus = DB.busFeautersRelations.Single(c => c.Bus_Id == id);
                    return View(bus);
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

        /***********************************       delete bus with feature           *****************************/
        [HttpGet]
        public ActionResult DeleteBusWithFeature(int busId , int featureID)
        {
            info = Session["userData"] as User;
            if (info != null)
            {
                if (info.user_types_id == 1)
                {
                    var bus = DB.buses.Single(c => c.BusID == busId);
                    var feature = DB.busFeatures.Single(c => c.ID == featureID);
                    var relation = DB.busFeautersRelations.Single(c => c.Bus_Id == busId);
                    DB.buses.Remove(bus);
                    DB.busFeatures.Remove(feature);
                    DB.busFeautersRelations.Remove(relation);
                    DB.SaveChanges();
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
            // return RedirectToAction("AllBuses");
        }

        #region
        /*
        // add bus & features & ralation with buses & busFeatures classes    in  <busFeaturesViewModel> model view

        [HttpPost]
        public ActionResult AddBusWithFeature(busFeaturesViewModel bfvm)
        {

            if (!ModelState.IsValid)
            {
                return View("AddBusWithFeature", bfvm);
            }
            BusFeautersRelation relation = new BusFeautersRelation();
            relation.Bus_Id = bfvm.bus_feature_relation.Buses.BusID;
            relation.BusFeatures_Id = bfvm.bus_feature_relation.BusFeatures.ID;


            DB.buses.Add(bfvm.bus_feature_relation.Buses);
            DB.busFeatures.Add(bfvm.bus_feature_relation.BusFeatures);
            DB.busFeautersRelations.Add(relation);
            DB.SaveChanges();

            
            return View("AddBusWithFeature");
        }
        
        */



        // add bus & features & ralation with buses & busFeatures classes
        /*      
        [HttpPost]
        public ActionResult AddBusWithFeature(busFeaturesViewModel bfvm)
        {

            if (!ModelState.IsValid)
            {
                return View("AddBusWithFeature", bfvm);
            }
            BusFeautersRelation relation = new BusFeautersRelation();
            relation.Bus_Id = bfvm.bus.BusID;
            relation.BusFeatures_Id = bfvm.bus_feature.ID;


            DB.buses.Add(bfvm.bus);
            DB.busFeatures.Add(bfvm.bus_feature);
            DB.busFeautersRelations.Add(relation);
            DB.SaveChanges();

            
            return View("AddBusWithFeature");
        }
        */
        #endregion
    }
}