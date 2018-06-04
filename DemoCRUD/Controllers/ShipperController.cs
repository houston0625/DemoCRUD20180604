using DemoCRUD.Models;
using System;
using System.Web.Mvc;
using static DemoCRUD.CommonUtility.CommonUtility;

namespace DemoCRUD.Controllers
{
    public class ShipperController : Controller
    {


        public ActionResult ShipperMain(ShipperCondition condition)
        {
            ShipperAction action = new ShipperAction();
            //ShipperCondition condition = new ShipperCondition();
            ShipperViewModel viewModel = action.SearchGridView(condition);
            return View(viewModel);
        }

        /// <summary>
        /// Search 
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        //[HttpPost]
        //public ActionResult ShipperMain(ShipperCondition condition)
        //{
        //    return View();
        //}

        [HttpPost]
        public ActionResult AddShipper(AddViewModel addItem)
        {
            ResultObject _result = new ResultObject();

            ShipperAction action = new ShipperAction();

            _result = action.AddShipper(addItem);

            return Json(_result);
        }

        [HttpPost]
        public ActionResult EditShipper(EditViewModel item)
        {
            ResultObject _result = new ResultObject();

            ShipperAction action = new ShipperAction();

            _result = action.EditShipper(item);

            return Json(_result);
        }

        [HttpPost]
        public ActionResult DeleteShipper(String delShipperID)
        {
            ResultObject _result = new ResultObject();

            ShipperAction action = new ShipperAction();

            _result = action.DeleteShipper(delShipperID);

            return Json(_result);
        }


    }
}