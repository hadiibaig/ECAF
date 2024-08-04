using ECAF.INFRASTRUCTURE.Models;
using ECAF.INFRASTRUCTURE.Repositories;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECAF.Controllers
{
    public class FormController : Controller
    {
        private readonly SiteCardRepository siteCardRepository;
        private readonly FormRepository FormRepository;
        public FormController()
        {
            FormRepository = new FormRepository();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CompletedForms()
        {
            var data = FormRepository.GetCompletedForms();
            return View(data);
        }
        public PartialViewResult ViewForm(long Id , string section = "")
        {
            var userId = User.Identity.GetUserId();
            var data = FormRepository.GetFormBYCardId(Id , userId);
            ViewBag.section = section;
            return PartialView("Partial_ViewForms" , data);
        }
        public JsonResult SaveComment(SaveComment model)
        {
            var data = FormRepository.SaveComment(model, User.Identity.GetUserId());
            return Json(data);
        }
        public JsonResult SaveForm(SaveFormModel model)
        {
            model.UserId = User.Identity.GetUserId();
            string pdf = GeneratePdf(model);
            if (!string.IsNullOrEmpty(pdf))
            {

                var baseUrl = Request.Url.GetLeftPart(UriPartial.Authority);
                var approvalUrl = Url.Action("ApprovalForm", "Form", new { formId = model.FormId }, protocol: Request.Url.Scheme);
                var link = $"{approvalUrl}";



                model.PdfPath = pdf;
                var res = FormRepository.SaveForm(model , link);
                return Json(res);
            }
            return Json(false);
        }

        public string GeneratePdf(SaveFormModel model)
        {
            try { 

            string pdfDirectory = Server.MapPath("~/Content/Pdfs");
            if (!Directory.Exists(pdfDirectory))
            {
                Directory.CreateDirectory(pdfDirectory);
            }

            string fileName = $"Form_{model.FormId}_{DateTime.Now:yyyyMMddHHmmss}.pdf";
            string filePath = Path.Combine(pdfDirectory, fileName);
            string relativePath = $"~/Content/Pdfs/{fileName}";
                using (MemoryStream ms = new MemoryStream())
                {
                    PdfWriter writer = new PdfWriter(ms);
                    PdfDocument pdf = new PdfDocument(writer);
                    Document document = new Document(pdf);
                    document.Add(new Paragraph("Questions and Answers"));
                    foreach (var qa in model.QuestionsAnswers)
                    {
                        document.Add(new Paragraph("Question: " + qa.Question));
                        document.Add(new Paragraph("Answer: " + qa.Answer));
                    }
                    document.Close();
                    byte[] pdfBytes = ms.ToArray();
                    System.IO.File.WriteAllBytes(filePath, pdfBytes);
                    return relativePath;
                }
            }
            catch(Exception ex)
            {
                return "";
            }
        }

        [HttpGet]
        public ActionResult ApprovalForm(int formId)
        {
            var data = FormRepository.GetApprovalForm(formId);
            return View(data);
        }

        [HttpGet]
        public JsonResult ApproveForm(int Id , bool Approved)
        {
            var data = FormRepository.ApproveForm(Id, Approved);
            return Json(data , JsonRequestBehavior.AllowGet);
        }

    }
}