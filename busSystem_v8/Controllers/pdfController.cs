using busSystem_v8.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace busSystem_v8.Controllers
{
    public class PdfController : Controller
    {
        User info;
        // BusSystemDB db = new BusSystemDB();
        BusSystemDB _context = new BusSystemDB();
        public ActionResult Index()
        {
            info = Session["userData"] as User;
            if (info != null)
            {
                if (info.user_types_id == 1)
                {
                    List<User> users = _context.users.ToList<User>();
                    return View(users);
                }
                else
                {
                    return RedirectToAction("page_error_400", "Dashboard");
                }
            }
            else
            {
                return RedirectToAction("page_error_400", "Dashboard");
            }
        }


        public FileResult CreatePdf()
        {
            MemoryStream workStream = new MemoryStream();
            StringBuilder status = new StringBuilder("");
            DateTime dTime = DateTime.Now;
            //file name to be created 
            string strPDFFileName = string.Format("SamplePdf" + dTime.ToString("yyyyMMdd") + "-" + ".pdf");
            Document doc = new Document();
            doc.SetMargins(0f, 0f, 0f, 0f);
            //Create PDF Table with 5 columns
            PdfPTable tableLayout = new PdfPTable(4);
            doc.SetMargins(0f, 0f, 0f, 0f);
            //Create PDF Table

            //file will created in this path
            string strAttachment = Server.MapPath("~/Downloadss/" + strPDFFileName);

            PdfWriter.GetInstance(doc, workStream).CloseStream = false;
            doc.Open();

            //Add Content to PDF 
            doc.Add(Add_Content_To_PDF(tableLayout));

            // Closing the document
            doc.Close();
            byte[] byteInfo = workStream.ToArray();
            workStream.Write(byteInfo, 0, byteInfo.Length);
            workStream.Position = 0;
            return File(workStream, "application/pdf", strPDFFileName);
        }
        protected PdfPTable Add_Content_To_PDF(PdfPTable tableLayout)
        {

            int[] headers = { 20, 40, 45, 35};  //Header Widths
            tableLayout.SetWidths(headers);        //Set the pdf headers
            tableLayout.WidthPercentage = 100;       //Set the PDF File witdh percentage
            tableLayout.HeaderRows = 1;
            //Add Title to the PDF file at the top
            List<User> users = _context.users.ToList<User>();

            tableLayout.AddCell(new PdfPCell(new Phrase("Users Data", new Font(Font.FontFamily.HELVETICA, 8, 1, new iTextSharp.text.BaseColor(0, 0, 0)))) { Colspan = 12, Border = 0, PaddingBottom = 5, HorizontalAlignment = Element.ALIGN_CENTER });
            ////Add header
            AddCellToHeader(tableLayout, "Age");
            AddCellToHeader(tableLayout, "Email");
            AddCellToHeader(tableLayout, "Name");
            AddCellToHeader(tableLayout, "BirthDate");
      //      AddCellToHeader(tableLayout, "BirthDate");

            ////Add body

            foreach (var emp in users)
            {
                AddCellToBody(tableLayout, emp.Age.ToString());
                AddCellToBody(tableLayout, emp.Email.ToString());
                AddCellToBody(tableLayout, emp.Name);
                AddCellToBody(tableLayout, emp.BirthDate.ToString());
              //  AddCellToBody(tableLayout, emp.BirthDate.ToString());
            }
            return tableLayout;
        }

        // Method to add single cell to the Header
        private static void AddCellToHeader(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.YELLOW))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5, BackgroundColor = new iTextSharp.text.BaseColor(128, 0, 0) });
        }

        // Method to add single cell to the body
        private static void AddCellToBody(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5, BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255) });
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
    }
}