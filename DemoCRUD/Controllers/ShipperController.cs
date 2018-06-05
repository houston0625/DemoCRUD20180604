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
            ShipperViewModel viewModel = action.SearchGridView(condition);
            return View(viewModel);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="addItem"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddShipper(AddViewModel addItem)
        {
            ResultObject _result = new ResultObject();

            ShipperAction action = new ShipperAction();

            _result = action.AddShipper(addItem);

            return Json(_result);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditShipper(EditViewModel item)
        {
            ResultObject _result = new ResultObject();

            ShipperAction action = new ShipperAction();

            _result = action.EditShipper(item);

            return Json(_result);
        }

        /// <summary>
        /// 刪除
        /// </summary>
        /// <param name="delShipperID"></param>
        /// <returns></returns>
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