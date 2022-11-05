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


        [HttpGet("GetFile")]
        public ActionResult <FileUpload> GetFile([FromForm]FileUpload file)
        {
            //if (Directory.Exists(_basePath))
            //{
            //    return (Ok(Directory.EnumerateFiles(_basePath)));
            //}
            //return BadRequest("directory not found!");
            if(Directory.Exists(_basePath))
            {
                if(file.files.Length > 0)
                {
                    if (System.IO.File.Exists(_basePath + file.files.FileName) == true)
                    {
                       var stream = System.IO.File.OpenRead(_basePath+file.files.FileName);
                        return Ok(stream);
                    }
                    return BadRequest("file doesn't exist!");
                }
                return BadRequest("file is empty!");
            }
            return BadRequest("directory doesn't exist!");


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
                    
                    if (System.IO.File.Exists(_basePath + objFile.files.FileName) == false)
                    {
                        using (FileStream fileStream = System.IO.File.Create(_basePath + objFile.files.FileName))
                        {
                            {
                                objFile.files.CopyTo(fileStream);
                                fileStream.Flush();

                                return _basePath + objFile.files.FileName;
                            }
                        }
                    }
                    else
                    {
                        return "This file already exist!";
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
