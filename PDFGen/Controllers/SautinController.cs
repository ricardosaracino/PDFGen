using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Web.Hosting;
using System.Web.Http;
using SautinSoft.Document;

namespace PDFGen.Controllers
{
    [RoutePrefix("api/pdf")]
    public class SautinController : ApiController
    {
        [Route("sautin")]
        public HttpResponseMessage Get()
        {
            var contents = new
            {
                FirstName = "Testy",
                LastName = "McTesterton"
            };

            // https://code.msdn.microsoft.com/windowsapps/Create-digitally-signed-1ab9e3c3?fbclid=IwAR3DgEhRbiCCozagd5BzYXoWoU1P_Gm5ng77aEvHdozH-QOSTNtoyJ_jH1M

            var loadPath = HostingEnvironment.MapPath(@"~/App_Data/template.docx");

            //DocumentCore.Serial = "put your serial here"; 
            var document = DocumentCore.Load(loadPath);


            // https://www.sautinsoft.com/products/document/examples/find-replace-content-net-csharp-vb.php
            var regex = new Regex(@"{FirstName}", RegexOptions.IgnoreCase);

            foreach (var item in document.Content.Find(regex).Reverse())
            {
                item.Replace(contents.FirstName);
            }

            // https://www.sautinsoft.com/products/document/examples/find-replace-content-net-csharp-vb.php
            regex = new Regex(@"{LastName}", RegexOptions.IgnoreCase);

            foreach (var item in document.Content.Find(regex).Reverse())
            {
                item.Replace(contents.LastName);
            }

            var options = new PdfSaveOptions()
            {
                DigitalSignature =
                {
                    // Path to the certificate (*.pfx). 
                    CertificatePath = HostingEnvironment.MapPath(@"~/App_Data/mycert.pfx"),
                    // Password of the certificate. 
                    CertificatePassword = "test",
                    // Additional information about the certificate. 
                    Location = "World Wide Web",
                    Reason = "Document.Net by SautiSoft",
                    ContactInfo = "info@sautinsoft.com",
                    // Placeholder where signature should be visualized. 
                    // SignatureLine = signatureLine, 
                    // Visual representation of digital signature. 
                    //Signature = signature 
                }
            };

            byte[] pdf;

            using (var msPdf = new MemoryStream())
            {
                document.Save(msPdf, options);
                pdf = msPdf.ToArray();
            }

            var response = new HttpResponseMessage(HttpStatusCode.OK) {Content = new ByteArrayContent(pdf)};
            response.Content.Headers.ContentDisposition =
                new ContentDispositionHeaderValue("inline") {FileName = "template.pdf"};
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");

            return response;
        }
    }
}