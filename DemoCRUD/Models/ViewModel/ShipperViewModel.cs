using System;
using System.Collections.Generic;

namespace DemoCRUD.Models
{
    public class ShipperCondition
    {
        public String CompanyName { get; set; }

        public String Phone { get; set; }
    }

    public class ShipperGridViewItem
    {
        public String ShipperID { get; set; }

        public String CompanyName { get; set; }

        public String Phone { get; set; }
    }

    public class ShipperViewModel
    {
        public ShipperCondition condition { get; set; }
        public List<ShipperGridViewItem> dataSource { get; set; }
    }

    public class AddViewModel
    {
        public String CompanyName { get; set; }

        public String Phone { get; set; }
    }

    public class EditViewModel
    {
        public String ShipperID { get; set; }

        public String CompanyName { get; set; }

        public String Phone { get; set; }
    }
}