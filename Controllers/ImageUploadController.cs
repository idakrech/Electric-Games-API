using Microsoft.AspNetCore.Mvc;

namespace ElectricGamesApi.Controllers;

[ApiController]
[Route("[controller]")]

public class ImageUploadController : ControllerBase
{
    private readonly IWebHostEnvironment hosting;
    public ImageUploadController(IWebHostEnvironment _hosting)
    {
        hosting = _hosting;
    }

    [HttpGet]
    public string Get()
    {
        return "Hei fra ImageUploadController";
    }

    [HttpPost]
    public IActionResult SaveImage(IFormFile file)
    {
        
        string wwwrootPath = hosting.WebRootPath;
        string absolutePath = Path.Combine($"{wwwrootPath}/images/{file.FileName}");

        try {
        using (var fileStream = new FileStream(absolutePath, FileMode.Create))
        {
            file.CopyTo(fileStream);
        }
        
        return Ok();
        }
        catch
        {
            return StatusCode(500);
        }
    }
}