﻿using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;
using System;
using System.Data;
using System.Web.Mvc;

namespace HTML_Samples.Controllers
{
    public class DesignerController : Controller
    {
        static DesignerController()
        {
            // How to Activate
            //Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnO...";
            //Stimulsoft.Base.StiLicense.LoadFromFile("license.key");
            //Stimulsoft.Base.StiLicense.LoadFromStream(stream);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetReport()
        {
            StiReport report = new StiReport();
            report.Load(Server.MapPath("~/Content/Reports/TwoSimpleLists.mrt"));
            
            return StiMvcDesigner.GetReportResult(report);
        }

        public ActionResult PreviewReport()
        {
            StiReport report = StiMvcDesigner.GetActionReportObject();

            DataSet data = new DataSet("Demo");
            data.ReadXml(Server.MapPath("~/Content/Data/Demo.xml"));

            report.RegData(data);

            return StiMvcDesigner.PreviewReportResult(report);
        }

        public ActionResult SaveReport()
        {
            StiReport report = StiMvcDesigner.GetReportObject();
            
            // Save the report template, for example to JSON string
            string json = report.SaveToJsonString();
            
            return StiMvcDesigner.SaveReportResult();
        }

        public ActionResult SaveReportAs()
        {
            return StiMvcDesigner.SaveReportResult();
        }

        public ActionResult DesignerEvent()
        {
            return StiMvcDesigner.DesignerEventResult();
        }
    }
}