using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Windows.Forms;

namespace PDFGen.Controllers
{
    [RoutePrefix("api/pdf")]
    public class RtfController : ApiController
    {
        [Route("rtf")]
        public HttpResponseMessage Get()
        {
            var richTextBox1 = new RichTextBox();
            richTextBox1.LoadFile(@"E:\RicardoSaracino\Projects\PDFGen\PDFGen\App_Data\0875.rtf",
                RichTextBoxStreamType.RichText);
            string text = richTextBox1.Rtf;

            var response = new HttpResponseMessage {Content = new StringContent(text)};
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = "0875-20200512.rtf";
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/rtf");
            return response;
        }
    }
}