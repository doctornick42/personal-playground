using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Playground.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public async Task<JsonResult> TestRxThreads()
        {
            int originalThreadId = Environment.CurrentManagedThreadId;
            var originalContext = SynchronizationContext.Current;
            List<string> usedThreadsMessages = new List<string>();

            var toBeSerialized = new ExpandoObject() as IDictionary<string, Object>;

            Observable.Interval(TimeSpan.FromSeconds(1))
                .ObserveOn(originalContext)
                .Subscribe(x =>
                {
                    usedThreadsMessages.Add("Interval" + x + " on thread " + Environment.CurrentManagedThreadId);
                    
                });

            if (usedThreadsMessages.Count >= 10)
            {
                toBeSerialized.Add("OriringalThread", originalThreadId);
                toBeSerialized.Add("Intervals", usedThreadsMessages);

                return Json(toBeSerialized, JsonRequestBehavior.AllowGet);
            }

            return Json(toBeSerialized, JsonRequestBehavior.AllowGet);
        }
    }
}