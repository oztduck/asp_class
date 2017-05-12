using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using database;

namespace Web.Controllers
{
    public class dataController : Controller
    {
        // GET: data
        public ActionResult IndexMessage()
        {
            var data = new db() ;

            var bookstore = data.Readhomework();
            var message = string.Format("共收到{0}筆監測站的資料<br/>", bookstore.Count);
            bookstore.ForEach(x =>
            {
                message += string.Format("店名：{0},地址:{1},開店時間:{2},電話:{3} <br/>", x.name, x.address,x.openTime,x.phone);


            });
            return Content(message);
        }
   
    }
}