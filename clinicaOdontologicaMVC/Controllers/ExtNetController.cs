using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Ext.Net;
using Ext.Net.MVC;
using clinicaOdontologicaMVC.Models;

namespace clinicaOdontologicaMVC.Controllers
{
    [DirectController(AreaName = "Calendar_Overview", IDMode = DirectMethodProxyIDMode.None)]
    public class ExtNetController : Controller
    {
        public ActionResult Index()
        {
            ExtNetModel model = new ExtNetModel()
            {
                Title = "Welcome to Ext.NET",
                TextAreaEmptyText = ">> Enter a Message Here <<"
            };

            return this.View(model);
        }

        public ActionResult SampleAction(string message)
        {
            X.Msg.Notify(new NotificationConfig
            {
                Icon = Icon.Accept,
                Title = "Working",
                Html = message
            }).Show();

            return this.Direct();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Button1_Click(string user, string pass)
        {
            DirectResult r = new DirectResult();

            // Do some Authentication...
            if (user != "Demo" || pass != "demo")
            {
                r.Success = false;
                r.ErrorMessage = "Invalid username or password.";
            }

            return r;
        }

        public ActionResult Main()
        {
            return View();
        }

        public ActionResult LoadPages(string node)
        {
            NodeCollection result = null;
            if (node == "_root")
            {
                result = SiteMapModel.CreateNode(SiteMap.RootNode).Children;
            }
            else
            {
                SiteMapNode siteMapNode = SiteMap.Provider.FindSiteMapNodeFromKey(node);
                SiteMapNodeCollection children = siteMapNode.ChildNodes;
                result = new NodeCollection();

                if (children != null && children.Count > 0)
                {
                    foreach (SiteMapNode mapNode in siteMapNode.ChildNodes)
                    {
                        result.Add(SiteMapModel.CreateNodeWithOutChildren(mapNode));
                    }
                }
            }

            return this.Store(result);
        }

        public ActionResult Agenda()
        {
            return View(BasicModel.Events);
        }

        public ActionResult SubmitData(string data)
        {
            List<EventModel> events = JSON.Deserialize<List<EventModel>>(data);

            return new Ext.Net.MVC.PartialViewResult
            {
                ViewName = "EventsViewer",
                ViewBag =
                {
                    Events = events
                }
            };
        }

        [DirectMethod(Namespace = "CompanyX")]
        public ActionResult ShowMsg(string msg)
        {
            X.Msg.Notify("Message", msg).Show();

            return this.Direct();
        }

        public ActionResult Cita()
        {
            return View(new CitaModel());
        }

    }
}