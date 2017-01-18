using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Ext.Net;
using Ext.Net.MVC;
using clinicaOdontologicaMVC.Models;
using System.Linq;
using System.Xml.Linq;

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
            XElement document = XElement.Load(Server.MapPath("~/xml/DashboardSchema.xml"));
            string defaultIcon = document.Attribute("defaultIcon") != null ? document.Attribute("defaultIcon").Value : "";

            IEnumerable<object> query = from g in document.Elements("group")
                                        select new
                                        {
                                            Title = g.Attribute("title") != null ? g.Attribute("title").Value : "",
                                            Items = (from i in g.Elements("item")
                                                     select new
                                                     {
                                                         Title = i.Element("title") != null ? i.Element("title").Value : "",
                                                         Icon = Url.Content("~/xml/" + (i.Element("item-icon") != null ? i.Element("item-icon").Value : defaultIcon)),
                                                         Id = i.Element("id") != null ? i.Element("id").Value : ""
                                                     }
                                                )
                                        };
            return View(query);

            //return View();
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

        public ActionResult Expediente()
        {
            return View();
        }

        public ActionResult Consulta()
        {
            return View();
        }

        public ActionResult OrdenDePago()
        {
            return View(GetData());
        }

        private object[] GetData()
        {
            return new object[]
            {
                new object[] { "Juan Pérez", 71.72, "Endodoncia", 0.03, "9/1 12:00am" },
                new object[] { "José López", 29.01, "Odontologia estetica", 1.47, "9/1 12:00am" },
                new object[] { "Carmen Ramírez", 83.81, "Periodoncia", 0.34, "9/1 12:00am" },
                new object[] { "Sophia Hernández", 52.55, "Ortodoncia", 0.02, "9/1 12:00am" },
                new object[] { "Leopoldo Campos", 64.13, "Odontopediatría", 0.49, "9/1 12:00am" }
                /*new object[] { "AT&T Inc.", 31.61, -0.48, -1.54, "9/1 12:00am" },
                new object[] { "Boeing Co.", 75.43, 0.53, 0.71, "9/1 12:00am" },
                new object[] { "Caterpillar Inc.", 67.27, 0.92, 1.39, "9/1 12:00am" },
                new object[] { "Citigroup, Inc.", 49.37, 0.02, 0.04, "9/1 12:00am" },
                new object[] { "E.I. du Pont de Nemours and Company", 40.48, 0.51, 1.28, "9/1 12:00am" },
                new object[] { "Exxon Mobil Corp", 68.1, -0.43, -0.64, "9/1 12:00am" },
                new object[] { "General Electric Company", 34.14, -0.08, -0.23, "9/1 12:00am" },
                new object[] { "General Motors Corporation", 30.27, 1.09, 3.74, "9/1 12:00am" },
                new object[] { "Hewlett-Packard Co.", 36.53, -0.03, -0.08, "9/1 12:00am" },
                new object[] { "Honeywell Intl Inc", 38.77, 0.05, 0.13, "9/1 12:00am" },
                new object[] { "Intel Corporation", 19.88, 0.31, 1.58, "9/1 12:00am" },
                new object[] { "International Business Machines", 81.41, 0.44, 0.54, "9/1 12:00am" },
                new object[] { "Johnson & Johnson", 64.72, 0.06, 0.09, "9/1 12:00am" },
                new object[] { "JP Morgan & Chase & Co", 45.73, 0.07, 0.15, "9/1 12:00am" },
                new object[] { "McDonald\"s Corporation", 36.76, 0.86, 2.40, "9/1 12:00am" },
                new object[] { "Merck & Co., Inc.", 40.96, 0.41, 1.01, "9/1 12:00am" },
                new object[] { "Microsoft Corporation", 25.84, 0.14, 0.54, "9/1 12:00am" },
                new object[] { "Pfizer Inc", 27.96, 0.4, 1.45, "9/1 12:00am" },
                new object[] { "The Coca-Cola Company", 45.07, 0.26, 0.58, "9/1 12:00am" },
                new object[] { "The Home Depot, Inc.", 34.64, 0.35, 1.02, "9/1 12:00am" },
                new object[] { "The Procter & Gamble Company", 61.91, 0.01, 0.02, "9/1 12:00am" },
                new object[] { "United Technologies Corporation", 63.26, 0.55, 0.88, "9/1 12:00am" },
                new object[] { "Verizon Communications", 35.57, 0.39, 1.11, "9/1 12:00am" },
                new object[] { "Wal-Mart Stores, Inc.", 45.45, 0.73, 1.63, "9/1 12:00am" }*/
            };
        }

        public ActionResult Alertas()
        {
            return View();
        }
    }
}