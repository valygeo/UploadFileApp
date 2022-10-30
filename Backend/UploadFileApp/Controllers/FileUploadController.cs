using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UploadFileApp.Models;

namespace UploadFileApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        public static IWebHostEnvironment _environment;
        private readonly string _basePath;
       
       
        public FileUploadController(IWebHostEnvironment environment)
        {
            _environment = environment;
            _basePath = _environment.WebRootPath + "\\Upload\\";
        }
        [HttpPost("UploadFile")]

        public async Task<string> Post([FromForm]FileUpload objFile)
        {
            try
            {
                if (objFile.files.Length > 0)
                {
                    if (!Directory.Exists(_basePath))
                    {
                        Directory.CreateDirectory(_basePath);
                    }
                    using (FileStream fileStream = System.IO.File.Create(_basePath + objFile.files.FileName))
                    {

                        //if (Directory.GetFiles(_environment.WebRootPath + "\\Upload\\" + objFile.files.FileName) == null)
                        //{
                        //    objFile.files.CopyTo(fileStream);
                        //    fileStream.Flush();
                        //    return "\\Upload\\" + objFile.files.FileName;
                        //}
                        //else return "numele deja exista!"
                       
                          
                            objFile.files.CopyTo(fileStream);
                            fileStream.Flush();
                            return _basePath + objFile.files.FileName;
                       
                       

                    }
                }
                else
                {
                    return "Failed!";
                }
            }
            catch (Exception exception)
            {

                return exception.Message.ToString();
            }
        }

       
    }
    
}
