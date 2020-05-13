using System.Web.Http;
using Foxit.PDF.Merger;
using GrapeCity.Documents.Word;

namespace PDFGen.Controllers
{
    [RoutePrefix("api/pdf")]
    public class GrapeCityController : ApiController
    {
        [Route("grape")]
        public void Get()
        {
            var doc = new GcWordDocument();
            doc.Load(@"E:\RicardoSaracino\Projects\PDFGen\PDFGen\App_Data\0875.docx");
            
            doc.Body.Replace("{FirstName}", "asdfasdfasdfasdf");
            
            doc.SaveAsPdf(@"E:\RicardoSaracino\Projects\PDFGen\PDFGen\App_Data\0875-20100511.pdf");
        }
    }
}