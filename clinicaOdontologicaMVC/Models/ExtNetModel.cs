using System;
using System.Web;
using Ext.Net;
using System.Collections.Generic;

namespace clinicaOdontologicaMVC.Models
{
    public class ExtNetModel
    {
        public string Title { get; set; }
        public string TextAreaEmptyText { get; set; }
    }

    public class BasicModel
    {
        public static EventModelCollection Events
        {
            get
            {
                DateTime now = DateTime.Now.Date;

                return new EventModelCollection {
                    new EventModel
                    {
                        EventId = 1001,
                        CalendarId = 1,
                        Title = "Endodoncia",
                        StartDate = now.AddDays(-20).AddHours(10),
                        EndDate = now.AddDays(-10).AddHours(15),
                        IsAllDay = false,
                        Notes = "Endodoncia"
                    },
                    new EventModel
                    {
                        EventId = 1002,
                        CalendarId = 2,
                        Title = "Odontologia estetica",
                        StartDate = now.AddHours(11).AddMinutes(30),
                        EndDate = now.AddHours(13),
                        IsAllDay = false,
                        Location = "Clinica",
                        Url = "http://chuys.com",
                        Notes = "Odontologia estetica",
                        Reminder = "15"
                    },
                    new EventModel
                    {
                        EventId = 1003,
                        CalendarId = 3,
                        Title = "Periodoncia",
                        StartDate = now.AddHours(15),
                        EndDate = now.AddHours(15),
                        IsAllDay = false
                    },
                    new EventModel
                    {
                        EventId = 1004,
                        CalendarId = 1,
                        Title = "Ortodoncia",
                        StartDate = now,
                        EndDate = now,
                        IsAllDay = true,
                        Notes = "Ortodoncia"
                    },
                    new EventModel
                    {
                        EventId = 1005,
                        CalendarId = 2,
                        Title = "Cirugía Maxilofacial",
                        StartDate = now.AddDays(-12),
                        EndDate = now.AddDays(10).AddSeconds(-1),
                        IsAllDay = true
                    },
                    new EventModel
                    {
                        EventId = 1006,
                        CalendarId = 3,
                        Title = "Odontopediatría",
                        StartDate = now.AddDays(5),
                        EndDate = now.AddDays(7).AddSeconds(-1),
                        IsAllDay = true,
                        Reminder = "2880"
                    },
                    new EventModel
                    {
                        EventId = 1007,
                        CalendarId = 1,
                        Title = "Prótesis dentales",
                        StartDate = now.AddHours(9),
                        EndDate = now.AddHours(9).AddMinutes(30),
                        IsAllDay = false,
                        Notes = "Prótesis dentales"
                    },
                    new EventModel
                    {
                        EventId = 1008,
                        CalendarId = 3,
                        Title = "Implantes dentales",
                        StartDate = now.AddDays(-30),
                        EndDate = now.AddDays(-28),
                        IsAllDay = true,
                        Notes = "Implantes dentales"
                    },
                    new EventModel
                    {
                        EventId = 1009,
                        CalendarId = 2,
                        Title = "Odontopediatría",
                        StartDate = now.AddDays(-2).AddHours(13),
                        EndDate = now.AddDays(-2).AddHours(18),
                        IsAllDay = false,
                        Location = "Clinica",
                        Reminder = "60"
                    },
                    new EventModel
                    {
                        EventId = 1010,
                        CalendarId = 3,
                        Title = "Cirugía Maxilofacial",
                        StartDate = now.AddDays(-2),
                        EndDate = now.AddDays(3).AddSeconds(-1),
                        IsAllDay = true
                    },
                    new EventModel
                    {
                        EventId = 1011,
                        CalendarId = 1,
                        Title = "Ortodoncia",
                        StartDate = now.AddDays(2).AddHours(19),
                        EndDate = now.AddDays(2).AddHours(23),
                        IsAllDay = false,
                        Notes = "Ortodoncia",
                        Reminder = "60"
                    }
                };
            }
        }
    }

    public class SiteMapModel
    {
        //dynamic node creation
        public static Node CreateNodeWithOutChildren(SiteMapNode siteMapNode)
        {
            Node treeNode;

            if (siteMapNode.ChildNodes != null && siteMapNode.ChildNodes.Count > 0)
            {
                treeNode = new Node();
            }
            else
            {
                treeNode = new Node();
                treeNode.Leaf = true;
            }

            if (!string.IsNullOrEmpty(siteMapNode.Url))
            {
                treeNode.Href = siteMapNode.Url.StartsWith("~/") ? siteMapNode.Url.Replace("~/", "http://examples.ext.net/") : ("http://examples.ext.net" + siteMapNode.Url);
            }

            treeNode.NodeID = siteMapNode.Key;
            treeNode.Text = siteMapNode.Title;
            treeNode.Qtip = siteMapNode.Description;

            return treeNode;
        }

        //static node creation with children
        public static Node CreateNode(SiteMapNode siteMapNode)
        {
            Node treeNode = new Node();

            if (!string.IsNullOrEmpty(siteMapNode.Url))
            {

                treeNode.CustomAttributes.Add(new ConfigItem("url", siteMapNode.Url.StartsWith("~/") ? siteMapNode.Url.Replace("~/", "http://examples.ext.net/") : ("http://examples.ext.net" + siteMapNode.Url)));
                treeNode.Href = "#";
            }

            treeNode.NodeID = siteMapNode.Key;
            treeNode.CustomAttributes.Add(new ConfigItem("hash", siteMapNode.Key.GetHashCode().ToString()));
            treeNode.Text = siteMapNode.Title;
            treeNode.Qtip = siteMapNode.Description;

            SiteMapNodeCollection children = siteMapNode.ChildNodes;

            if (children != null && children.Count > 0)
            {
                foreach (SiteMapNode mapNode in siteMapNode.ChildNodes)
                {
                    treeNode.Children.Add(SiteMapModel.CreateNode(mapNode));
                }
            }
            else
            {
                treeNode.Leaf = true;
            }

            return treeNode;
        }
    }

    public class CitaModel
    {
        public IEnumerable<object> Patients
        {
            get
            {
                return new List<object>
                {
                    new { InsuranceCode="11111", Name="Juan Pérez", Address="Main Street", Telephone="2222-3333", Mail="jperez@gmail.com" },
                    new { InsuranceCode="22222", Name="José López", Address="Cromwell Street", Telephone="2222-4444", Mail="jlopez@yahoo.com" },
                    new { InsuranceCode="33333", Name="Carmen Ramírez", Address="Over The Rainbow", Telephone="2222-5555", Mail="cramirez@hotmail.com" },
                    new { InsuranceCode="44444", Name="Sophia Hernández", Address="Blimp Street", Telephone="2222-6666", Mail="shernandez@gmail.com" },
                    new { InsuranceCode="55555", Name="Leopoldo Campos", Address="Talbot County, Maryland", Telephone="2222-7777", Mail="lcampos@yahoo.com" }
                };
            }
        }

        public IEnumerable<object> Hospitals
        {
            get
            {
                return new List<object>
                {
                    new { Code="AAAAA", Name="Juan Martínez", Address="A1", Telephone="Cariología" },
                    new { Code="BBBBB", Name="Luis Gavidia", Address="B1", Telephone="Ortodoncia" },
                    new { Code="CCCCC", Name="Oscar Gutiérrez", Address="C1", Telephone="Periodontología" },
                    new { Code="DDDDD", Name="Rodrigo Ortiz", Address="D1", Telephone="Odontopediatría" }
                };
            }
        }
    }
}