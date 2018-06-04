using Omu.ValueInjecter;
using System;
using System.Linq;
using static DemoCRUD.CommonUtility.CommonUtility;

namespace DemoCRUD.Models
{
    public class ShipperAction
    {
        private NORTHWNDEntities db = new NORTHWNDEntities();

        public ShipperViewModel SearchGridView(ShipperCondition condition)
        {
            ShipperViewModel viewModel = new ShipperViewModel();

            #region PageSize PageIndex
            //int _pageSize = 10;
            //int _pageIndex = 1;

            //if (condition != null)
            //{
            //    if (!String.IsNullOrEmpty(condition.PageSize))
            //    {
            //        int.TryParse(condition.PageSize, out _pageSize);
            //        _pageSize = _pageSize < 10 ? 10 : _pageSize;
            //    }

            //    //現在是第幾頁
            //    if (!String.IsNullOrEmpty(condition.PageIndex))
            //    {
            //        int.TryParse(condition.PageIndex, out _pageIndex);
            //        _pageIndex = _pageIndex < 1 ? 1 : _pageIndex;
            //    }
            //}
            #endregion

            var query = from p in db.Shippers.AsQueryable()
                        select new ShipperGridViewItem
                        {
                            ShipperID = p.ShipperID.ToString(),
                            CompanyName = p.CompanyName,
                            Phone = p.Phone
                        };
            if (condition != null)
            {
                if (!String.IsNullOrWhiteSpace(condition.CompanyName))
                {
                    query = query.Where(x => x.CompanyName.Contains(condition.CompanyName));
                }

                if (!String.IsNullOrWhiteSpace(condition.Phone))
                {
                    query = query.Where(x => x.Phone.Contains(condition.Phone));
                }
            }

            //IPagedList<ShipperGridViewItem> _dataSource = query.ToPagedList(_pageIndex, _pageSize);

            viewModel.dataSource = query.ToList<ShipperGridViewItem>();

            if (condition != null)
            {
                viewModel.condition = condition;
            }
            else
            {
                viewModel.condition = new ShipperCondition();
                //viewModel.condition.PageSize = _pageSize.ToString();
            }

            //_dataSource = query.ToPagedList(_pageIndex, _pageSize);

            return viewModel;
        }

        public ResultObject AddShipper(AddViewModel item)
        {
            ResultObject result = new ResultObject();
            result.ReturnCode = "000";

            try
            {
                Shipper newShipper = new Shipper();
                newShipper.InjectFrom(item);
                db.Shippers.Add(newShipper);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                result.ReturnCode = "999";
                result.ReturnMessage = ex.Message;
            }

            return result;
        }
        //public

        public ResultObject EditShipper(EditViewModel item)
        {
            ResultObject result = new ResultObject();
            result.ReturnCode = "000";

            int iShipperID = Convert.ToInt32(item.ShipperID);

            try
            {
                Shipper query = (from p in db.Shippers.AsQueryable()
                                 where p.ShipperID == iShipperID
                                 select p).FirstOrDefault();

                if (query != null)
                {
                    query.Phone = item.Phone;
                    query.CompanyName = item.CompanyName;
                }

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                result.ReturnCode = "999";
                result.ReturnMessage = ex.Message;
            }
            return result;
        }


        public ResultObject DeleteShipper(String delShipperID)
        {
            ResultObject result = new ResultObject();
            result.ReturnCode = "000";

            int idelShipperID = Convert.ToInt32(delShipperID);
            try
            {

                Shipper query = (from p in db.Shippers.AsQueryable()
                                 where p.ShipperID == idelShipperID
                                 select p).FirstOrDefault();

                if (query != null)
                {
                    db.Shippers.Remove(query);
                    db.SaveChanges();
                }
                else
                {
                    result.ReturnCode = "999";
                    result.ReturnMessage = "Error ShipperID!";
                }

            }
            catch (Exception ex)
            {
                result.ReturnCode = "999";
                result.ReturnMessage = ex.Message;
            }
            return result;
        }

    }
}