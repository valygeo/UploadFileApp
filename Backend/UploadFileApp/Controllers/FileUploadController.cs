using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
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
            ////if (Directory.Exists(_basePath))
            ////{
            ////    return (Ok(Directory.EnumerateFiles(_basePath)));
            ////}
            ////return BadRequest("directory not found!");
            //if(Directory.Exists(_basePath))
            //{
            //    if(file.files.Length > 0)
            //    {
            //        if (System.IO.File.Exists(_basePath + file.files.FileName) == true)
            //        {
            //            var stream = System.IO.File.ReadAllText(_basePath + file.files.FileName);
            //            string jsonObject = JsonConvert.SerializeObject(stream);
            //            return Ok(jsonObject);
            //        }
            //        return BadRequest("File doesn't exist!");
            //    }
            //    return BadRequest("File is empty!");
            //}
            //return BadRequest("Directory doesn't exist!");
            if (Directory.Exists(_basePath))
            {
                if(file.files.Length>0)
                {
                    if(System.IO.File.Exists(_basePath + file.files.FileName) == true)
                    {
                        var data = System.IO.File.ReadAllText(_basePath + file.files.FileName);
                        var datas = data.Split("\r\n"); 
                        var MemberNames = datas[0].Split(','); 
                        var MYObj = datas.Skip(1) 
                                         .Select((x) => x.Split(',') 
                                                         
                                                         .Select((y, i) => new
                                                         {
                                                             Key = MemberNames[i].Trim('"'),
                                                             Value = y.Trim('"')

                                                         })
                                                         
                                                         .ToDictionary(d => d.Key, d => d.Value));

                       

                      
                        var Json = JsonConvert.SerializeObject(MYObj, Formatting.Indented);
                        Debug.WriteLine(Json);
                        return Ok(Json);

                    }
                    return BadRequest("File doesn't exist!");
                }
                return BadRequest("File is empty!");
            }
            return BadRequest("Directory doesn't exist!");
           


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
