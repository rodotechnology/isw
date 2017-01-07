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
                        Title = "Vacation",
                        StartDate = now.AddDays(-20).AddHours(10),
                        EndDate = now.AddDays(-10).AddHours(15),
                        IsAllDay = false,
                        Notes = "Have fun"
                    },
                    new EventModel
                    {
                        EventId = 1002,
                        CalendarId = 2,
                        Title = "Lunch with Matt",
                        StartDate = now.AddHours(11).AddMinutes(30),
                        EndDate = now.AddHours(13),
                        IsAllDay = false,
                        Location = "Chuy's!",
                        Url = "http://chuys.com",
                        Notes = "Order the queso",
                        Reminder = "15"
                    },
                    new EventModel
                    {
                        EventId = 1003,
                        CalendarId = 3,
                        Title = "Project due",
                        StartDate = now.AddHours(15),
                        EndDate = now.AddHours(15),
                        IsAllDay = false
                    },
                    new EventModel
                    {
                        EventId = 1004,
                        CalendarId = 1,
                        Title = "Sarah's birthday",
                        StartDate = now,
                        EndDate = now,
                        IsAllDay = true,
                        Notes = "Need to get a gift"
                    },
                    new EventModel
                    {
                        EventId = 1005,
                        CalendarId = 2,
                        Title = "A long one...",
                        StartDate = now.AddDays(-12),
                        EndDate = now.AddDays(10).AddSeconds(-1),
                        IsAllDay = true
                    },
                    new EventModel
                    {
                        EventId = 1006,
                        CalendarId = 3,
                        Title = "School holiday",
                        StartDate = now.AddDays(5),
                        EndDate = now.AddDays(7).AddSeconds(-1),
                        IsAllDay = true,
                        Reminder = "2880"
                    },
                    new EventModel
                    {
                        EventId = 1007,
                        CalendarId = 1,
                        Title = "Haircut",
                        StartDate = now.AddHours(9),
                        EndDate = now.AddHours(9).AddMinutes(30),
                        IsAllDay = false,
                        Notes = "Get cash on the way"
                    },
                    new EventModel
                    {
                        EventId = 1008,
                        CalendarId = 3,
                        Title = "An old event",
                        StartDate = now.AddDays(-30),
                        EndDate = now.AddDays(-28),
                        IsAllDay = true,
                        Notes = "Get cash on the way"
                    },
                    new EventModel
                    {
                        EventId = 1009,
                        CalendarId = 2,
                        Title = "Board meeting",
                        StartDate = now.AddDays(-2).AddHours(13),
                        EndDate = now.AddDays(-2).AddHours(18),
                        IsAllDay = false,
                        Location = "ABC Inc.",
                        Reminder = "60"
                    },
                    new EventModel
                    {
                        EventId = 1010,
                        CalendarId = 3,
                        Title = "Jenny's final exams",
                        StartDate = now.AddDays(-2),
                        EndDate = now.AddDays(3).AddSeconds(-1),
                        IsAllDay = true
                    },
                    new EventModel
                    {
                        EventId = 1011,
                        CalendarId = 1,
                        Title = "Movie night",
                        StartDate = now.AddDays(2).AddHours(19),
                        EndDate = now.AddDays(2).AddHours(23),
                        IsAllDay = false,
                        Notes = "Don't forget the tickets!",
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
                    new { InsuranceCode="11111", Name="Juan Pérez", Address="Main Street", Telephone="555 1234 123" },
                    new { InsuranceCode="22222", Name="José López", Address="Cromwell Street", Telephone="923 672 485" },
                    new { InsuranceCode="33333", Name="Carmen Ramírez", Address="Over The Rainbow", Telephone="555 321 0987" },
                    new { InsuranceCode="44444", Name="Sophia Hernández", Address="Blimp Street", Telephone="555 111 2222" },
                    new { InsuranceCode="55555", Name="Leopoldo Campos", Address="Talbot County, Maryland", Telephone="N/A" }
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