using Microsoft.AspNetCore.Mvc;
using Sportshop.Domain.Models;

namespace Sportshop.API.Controllers
{
    [ApiController]
    [Route("api/file")]
    public class FileController : ControllerBase
    {
        //[HttpPost]
        //[Route("upload")]
        //public async Task<ActionResult> UploadFile([FromForm] Thumbnail file)
        //{
        //    //string path = Path.Combine(@"C:\\Users\\karao\\source\\repos\\sportshop\\Sportshop.Persistence\\Thumbnails",
        //    //    file.FileName);

        //    //using (Stream stream = new FileStream(path, FileMode.Create))
        //    //{
        //    //    await file.Content.CopyToAsync(stream);
        //    //}

        //    return Ok("Image added successfully!");
        //}

        //[HttpGet]
        //[Route("fileId")]
        //public async Task<ActionResult> GetFile(int fileId)
        //{
        //    var files = Directory.GetFiles(@"C:\\Users\\karao\\source\\repos\\sportshop\\Sportshop.Persistence\\Thumbnails", );
        //}
    }
}
