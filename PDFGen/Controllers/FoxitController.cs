using System.Net;
using System.Net.Http;
using System.Web.Http;
using foxit.common;
using foxit.pdf;

namespace PDFGen.Controllers
{
    [RoutePrefix("api/pdf")]
    public class FoxitController : ApiController
    {
        [Route("foxit")]
        public HttpResponseMessage Get()
        {
            //https://developers.foxitsoftware.com/kb/article/developer-guide-foxit-pdf-sdk-net/#getting-started
            
            const string sn = "heN3fJ2eE24gHop/NqBTmCrvkmAquENF6ph2NwYe+lmIKLxUIKdstw==";
            const string key = "8f0YFcOJvRsN+ndWh5Aln+yqs1AphKdVQIGRHjWyxmE4r/x3UJEjGpdwLKOHw8scymkOcx77m5PvgeEtZfTag24wAeC50RTRbcVXRiSJ1+FdAFfTZfGt+ItinVegb8j3Qtm65Q4vsPFkH+qSvUgkyOD4xFoaVMcpuDWcGtILwV/zK/G2XOU6Brk90xY2+w+adL/I2nhxU5IU9W/a0OUlZOoVVmEwPUQWqUOUZJUyr0/7gOXjC4ejLPTzuBTWA05vPPzjif6G7k8UgIuBXiIYwUXKsJHgCktFHOxxCS0S/ba3YtHKpHh4bOXM15wsVFfWGK5HFukUhONn86FKAz1FdN/oBmLK4NRCnHpT6tPkDjOX6yirzJpBt6L8mmMtuLvSjTsGbx3OEKWPXEEqAJPKmVMvhzPoxJd8aMz4oZi13gNrVcQtuaNSBCYpN8DX0IWGGSQUgRBmKVpbVex5kcsGs7aiwVtZIwtaLpl4Gtzr3JlZ1S1Rfr5eHCLZzCO6OH87mFsadwUj4ppYyw4S5dMwznmiwoxnmF2g6KCDcUmYSyaWWJ3z60vcKbk4pY9ivLcIjOi2H+cwlqQBYRoyU8JrX2qNGmbj7Fz8yNcgIlc6JgYHV5JAaoCl+F56GKIBKZplFgH2+EYg/0ph46LBVLUTPxVeZWIwIhoKGb7z9ZfTuOz+brANLV4p98Maij0z8v1P8W1N7iR+BP1KbbXsOfajtPVu2t4YgSgtrk2rj9CLhnJAnJKrvggSO1IH9WZ6gVm/ff5XEzdv4bQvNBW75G+vFgZWd7XOgPYcT7jW3iKZC0EaJxKN7YEmu0BmhRfzVNkfK7T5s8+KIL1+xslz805s+pwnH6u0VWzZwfTNINuDkUBxsXo2elRKr6mhKOqxcrst7lXk/AEsHwhc+P8dPhuItgkVA7jhozsNkyyx5qTlg+QTFsaZRDMAIsYYQS/Km0ySvY3e3lKrg5LuhIE54cUqoeGd8PjXA9yKrbDTfmFLkYjlogPG+A1aHk48C1PqCu7JaC8dH1lw7Z/A5MiyMq1Mlp/Y9b0ZfOWZO9/Weu4ChURkduSI3Xr6Q6S5VRrUhLfX6/Lg/P3V9K9c4LQ8QNQjQDjUZ2pDDvqn+94JQO0e1ld0IGj+u68CB1fw99Cp5o/PuDY9TwLIb1Vhcsw8x4YE/cXCLg8qNl2eH8jjdz1eXwzubIatg16QHzcPMOGHNp/beMW3xzCMhIl7O8tzgZqTXl7+60e3MVWrAIe/0izRQwcVFIiI/Nbvije/Dr4AcJyAssFOQsGmpb15/0VQBF6YMvqtM3OJJV0MTMD/zbcd";

            var errorCode = Library.Initialize(sn, key);

            if (errorCode != ErrorCode.e_ErrSuccess)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
            
            var doc = new PDFDoc(@"E:\RicardoSaracino\Projects\PDFGen\PDFGen\App_Data\0875.pdf");

            errorCode = doc.LoadW("");
            
            if (errorCode != ErrorCode.e_ErrSuccess)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}