using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using org.pdfclown.documents;
using org.pdfclown.files;
using org.pdfclown.documents.contents.composition;
using org.pdfclown.documents.contents.fonts;
using File = org.pdfclown.files.File;

namespace PDFGen.Controllers
{
    [RoutePrefix("api/pdf")]
    public class ClownController : ApiController
    {
        [Route("clown")]
        public HttpResponseMessage Get()
        {
            // https://pdfclown.org/overview/features/#PDFCreation
            
            var file = new File();
            
// 1. Instantiate a new PDF document!
            var document = file.Document;

// 2. Add a page to the document!
            var page = new Page(document); // Instantiates the page inside the document context.
            
            document.Pages.Add(page); // Puts the page in the pages collection (you may choose an arbitrary position).

// 3. Create a content composer for the page!
            var composer = new PrimitiveComposer(page);

// 4. Add contents through the composer!
            composer.SetFont(new StandardType1Font(document, StandardType1Font.FamilyEnum.Courier, true, false), 32);
            composer.ShowText("Hello World!", new PointF(32, 48));
            
            composer.Flush();
            
            byte[] pdf;
            
            using (var oms = new MemoryStream())
            {
                using (org.pdfclown.bytes.IOutputStream os = new org.pdfclown.bytes.Stream(oms))
                {
                    file.Save(os, SerializationModeEnum.Incremental);
                }

                pdf = oms.ToArray();
            }
            
            var response = new HttpResponseMessage(HttpStatusCode.OK) {Content = new ByteArrayContent(pdf)};
            response.Content.Headers.ContentDisposition =
                new ContentDispositionHeaderValue("inline") {FileName = "template.pdf"};
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");

            return response;
        }
    }
}