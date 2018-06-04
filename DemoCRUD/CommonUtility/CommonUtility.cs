using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DemoCRUD.CommonUtility
{
    public class CommonUtility
    {


        public class PageSizeModel
        {
            public String PageSize { get; set; }

            public String PageIndex { get; set; }

            public PageSizeModel()
            {
                PageSize = "10";
                PageIndex = "1";
            }

        }

        public SelectList GetPageSizeSeletList
        {
            get
            {
                List<SelectListItem> lis = new List<SelectListItem>();

                lis.Add(new SelectListItem() { Text = "10", Value = "10" });
                lis.Add(new SelectListItem() { Text = "20", Value = "20" });
                lis.Add(new SelectListItem() { Text = "30", Value = "30" });
                lis.Add(new SelectListItem() { Text = "40", Value = "40" });
                lis.Add(new SelectListItem() { Text = "50", Value = "50" });

                SelectList li = new SelectList(lis);


                //var query = (from code_define in db.CODE_DEFINE.AsQueryable()
                //             where code_define.CODE_FIELD == "PAGE_SIZE"
                //             orderby code_define.CODE_SEQ
                //             select new DropDownPageItem
                //             {
                //                 ItemText = code_define.CODE_CONTENT,
                //                 ItemValue = code_define.CODE_CONTENT
                //             }).ToList();

                //SelectList li = new SelectList(query, dataValueField: "ItemValue", dataTextField: "ItemText");

                return li;
            }
        }

        public class PageSizeViewModel
        {
            public SelectList PageSize_ListItem { get; set; }
        }

        public class DropDownPageItem
        {
            public String ItemText { get; set; }
            public String ItemValue { get; set; }
        }

        /// <summary>
        /// 回傳資料庫執行結果
        /// </summary>
        public class ResultObject
        {
            // 000 or 999
            public String ReturnCode { get; set; }
            public String ReturnMessage { get; set; }

            public ResultObject()
            {
                ReturnCode = null;
                ReturnMessage = null;
            }
        }
    }
}