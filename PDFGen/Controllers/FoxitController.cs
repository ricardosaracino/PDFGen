using System.Web.Http;
using Foxit.PDF;
using Foxit.PDF.Merger;
using Foxit.PDF.PageElements;

namespace PDFGen.Controllers
{
    [RoutePrefix("api/pdf")]
    public class FoxitController : ApiController
    {
        [Route("foxit")]
        public void Get()
        {
            //https://developers.foxitsoftware.com/kb/article/developer-guide-foxit-pdf-sdk-net/#getting-started
            var document = new MergeDocument(@"E:\RicardoSaracino\Projects\PDFGen\PDFGen\App_Data\0875.pdf")
            {
                Creator = "CSC-SCC", Author = "eSOR API", Title = "0875-51000-20200421-01"
            };

            var page = document.Pages[0];
            page.Dimensions.SetMargins(30, 38, 35, 48);

            // Tracking No
            page.Elements.Add(new Label("0875-51000-20200421-01", 460, 89, -1, 32, Font.Courier, 10));

            // Institution
            page.Elements.Add(new Label("Lorem ipsum dolor sit amet, consectetur adipiscing elit.", 0, 132, 150, 32,
                Font.Courier, 10));

            // Subject
            page.Elements.Add(new Label(
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus sit amet hendrerit eros. Vestibulum condimentum, sem at rutrum volutpat, ex orci efficitur libero, ac feugiat nisi mauris vel odio. Sed tristique eros ut odio facilisis, vel aliquet tellus tempus. Integer scelerisque tellus at congue malesuada. Nam sed facilisis erat. Cras sed vulputate lectus. Praesent non mollis risus. Integer ac lorem at nibh fermentum volutpat. Aliquam at ligula est. Sed interdum sodales sem, sed vulputate sapien tempus vitae.",
                0, 177, 360, 32, Font.Courier, 10));

            // Statement
            page.Elements.Add(new Label(
                @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus sit amet hendrerit eros. Vestibulum condimentum, sem at rutrum volutpat, ex orci efficitur libero, ac feugiat nisi mauris vel odio. Sed tristique eros ut odio facilisis, vel aliquet tellus tempus. Integer scelerisque tellus at congue malesuada. Nam sed facilisis erat. Cras sed vulputate lectus. Praesent non mollis risus. Integer ac lorem at nibh fermentum volutpat. Aliquam at ligula est. Sed interdum sodales sem, sed vulputate sapien tempus vitae.
In a turpis sapien. Donec ut ipsum mi. Praesent vel suscipit erat. Donec ut pretium nibh. Praesent quis elit a tellus pharetra ornare. Nullam tempor egestas dui, sit amet facilisis libero auctor non. Nullam iaculis vehicula lorem eleifend placerat. Mauris vitae augue ex. Mauris ultricies id nisi ornare auctor. Etiam fringilla tellus ante, in maximus tellus sodales vel. Suspendisse eu varius nunc.
Donec et lacus ut augue scelerisque auctor. Morbi nibh nibh, gravida id accumsan ut, gravida nec enim. Nullam pellentesque quam at scelerisque lacinia. Aliquam cursus pharetra diam in viverra. Sed suscipit rhoncus magna, vel accumsan neque volutpat non. Suspendisse eu enim ex. Fusce nec sapien vitae elit interdum cursus sit amet dignissim nunc. Proin rhoncus commodo turpis, non elementum tellus. Nam molestie arcu eu sem scelerisque pulvinar. Nam semper iaculis arcu, sed sagittis nibh sodales quis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer rhoncus neque non dapibus blandit. Sed eget dolor libero.
Nullam quis nibh urna. Fusce porttitor volutpat ex ac sodales. Vestibulum bibendum fringilla augue a ullamcorper. Duis non posuere justo. Donec id massa sit amet sem euismod suscipit. Fusce porta dolor non massa semper, quis vestibulum sem euismod. Nam lectus erat, lobortis tincidunt ipsum non, sagittis tempor nisl. Maecenas at aliquam urna. Mauris elementum, quam ut ultricies cursus, augue dolor maximus dui, a sodales ipsum lectus a diam. Fusce quis tellus ac dolor mattis consequat rhoncus et lorem.
Ut a varius dui. Vestibulum feugiat velit est, sit amet vulputate lorem mattis ut. Maecenas dignissim vel arcu ac mattis. Quisque congue sodales erat semper laoreet. Donec eget nibh elit. Duis elit lorem, blandit vel vulputate ut, laoreet eu risus. Nulla facilisi. Vivamus faucibus leo ut erat vehicula, id commodo tortor vulputate. Cras in eros vitae magna efficitur consequat sit amet at lorem.
Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus sit amet hendrerit eros. Vestibulum condimentum, sem at rutrum volutpat, ex orci efficitur libero, ac feugiat nisi mauris vel odio. Sed tristique eros ut odio facilisis, vel aliquet tellus tempus. Integer scelerisque tellus at congue malesuada. Nam sed facilisis erat. Cras sed vulputate lectus. Praesent non mollis risus. Integer ac lorem at nibh fermentum volutpat. Aliquam at ligula est. Sed interdum sodales sem, sed vulputate sapien tempus vitae.
In a turpis sapien. Donec ut ipsum mi. Praesent vel suscipit erat. Donec ut pretium nibh. Praesent quis elit a tellus pharetra ornare. Nullam tempor egestas dui, sit amet facilisis libero auctor non. Nullam iaculis vehicula lorem eleifend placerat. Mauris vitae augue ex. Mauris ultricies id nisi ornare auctor. Etiam fringilla tellus ante, in maximus tellus sodales vel. Suspendisse eu varius nunc.
Donec et lacus ut augue scelerisque auctor. Morbi nibh nibh, gravida id accumsan ut, gravida nec enim. Nullam pellentesque quam at scelerisque lacinia. Aliquam cursus pharetra diam in viverra. Sed suscipit rhoncus magna, vel accumsan neque volutpat non. Suspendisse eu enim ex. Fusce nec sapien vitae elit interdum cursus sit amet dignissim nunc. Proin rhoncus commodo turpis, non elementum tellus. Nam molestie arcu eu sem scelerisque pulvinar. Nam semper iaculis arcu, sed sagittis nibh sodales quis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer rhoncus neque non dapibus blandit. Sed eget dolor libero.
Nullam quis nibh urna. Fusce porttitor volutpat ex ac sodales. Vestibulum bibendum fringilla augue a ullamcorper. Duis non posuere justo. Donec id massa sit amet sem euismod suscipit. Fusce porta dolor non massa semper, quis vestibulum sem euismod. Nam lectus erat, lobortis tincidunt ipsum non, sagittis tempor nisl. Maecenas at aliquam urna. Mauris elementum, quam ut ultricies cursus, augue dolor maximus dui, a sodales ipsum lectus a diam. Fusce quis tellus ac dolor mattis consequat rhoncus et lorem.
Ut a varius dui. Vestibulum feugiat velit est, sit amet vulputate lorem mattis ut. Maecenas dignissim vel arcu ac mattis. Quisque congue sodales erat semper laoreet. Donec eget nibh elit. Duis elit lorem, blandit vel vulputate ut, laoreet eu risus. Nulla facilisi. Vivamus faucibus leo ut erat vehicula, id commodo tortor vulputate. Cras in eros vitae magna efficitur consequat sit amet at lorem."
                , 0, 220, 540, 500, Font.Courier, 10));

            document.DrawToWeb("0875-20200511.pdf");
        }
    }
}