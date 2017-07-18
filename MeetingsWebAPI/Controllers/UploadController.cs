using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MeetingsWebAPI.Controllers
{
    public class UploadController : ApiController
    {
        //upload a file to the server
       [Route("api/Files/Upload/{folder}")]
        public async Task<string> PostPhoto(string folder)
        {
            try
            {
         var httpRequest = HttpContext.Current.Request;

            if (httpRequest.Files.Count > 0)
            {
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];

                        //       var fileName = postedFile.FileName.Split('\\').LastOrDefault().Split('/').LastOrDefault();
                        bool folderExists =
                                           Directory.Exists(HttpContext.Current.Server.MapPath("~/Photos/" + folder));
                        if (!folderExists)
                            Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Photos/" + folder));
                        var filePath = HttpContext.Current.Server.MapPath("~/Photos/" +folder+"/"+ postedFile.FileName);

                    postedFile.SaveAs(filePath);

                    return "Photos/" + postedFile.FileName;
                }
         
            }
         

        }
            catch (Exception e)
            {
                return e.Message;
            }
            return "";
        }

        [Route("api/Files/UploadToFolder/{folderName}")]
        public async Task<string> PostPhotoToFolder(string folderName)
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;

                if (httpRequest.Files.Count > 0)
                {
                    foreach (string file in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[file];

                    //    var fileName = postedFile.FileName.Split('\\').LastOrDefault().Split('/').LastOrDefault();

                        bool folderExist =
                            Directory.Exists(
                                HttpContext.Current.Server.MapPath("~/Photos/" + folderName + "/" + postedFile.FileName));
                        if (!folderExist)
                        {
                            Directory.CreateDirectory("~/Photos/" + folderName);

                        }
                        string filePath = HttpContext.Current.Server.MapPath("~/Photos/") + folderName + "/" + postedFile.FileName;


                        postedFile.SaveAs(filePath);

                        return "Photos/" + folderName + "/" + postedFile.FileName;
                    }

                }


            }
            catch (Exception e)
            {
                return e.Message;
            }
            return "";
        }
     
    }
}
