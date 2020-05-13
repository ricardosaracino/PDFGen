using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace PDFGen.Controllers
{
    [RoutePrefix("api/pdf")]
    public class HtmlController : ApiController
    {
        [Route("html")]
        public HttpResponseMessage Get()
        {
            var text = File.ReadAllText(@"E:\RicardoSaracino\Projects\PDFGen\PDFGen\App_Data\0875.htm");

            var response = new HttpResponseMessage {Content = new StringContent(text)};
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return response;
        }
    }
}