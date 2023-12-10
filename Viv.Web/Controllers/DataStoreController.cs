using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Viv.Bll;

namespace Viv.Web.Controllers
{
    [RoutePrefix("DataStore")]
    public class DataStoreController : ApiController
    {
        [Inject]
        public IDataImportService ImportService { get; set; }

        [HttpPost]
        [Route("Clear")]
        public async Task<HttpResponseMessage> Clear()
        {
            await ImportService.ClearAllDataAsync();
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("")]
        public async Task<HttpResponseMessage> Post()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            var provider = new MultipartMemoryStreamProvider();

            try
            {
                await Request.Content.ReadAsMultipartAsync(provider);

                if(provider.Contents.Count() == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "No file was provided");
                }

                foreach (var file in provider.Contents)
                {
                    var fileData = await file.ReadAsByteArrayAsync();

                    await ImportService.ImportDataAsync(fileData);

                    //Only process one file
                    break;
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
