using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using SystemManagementMovie.Common.Base.Repository;
using SystemManagementMovie.Common.UOW;
using SystemManagementMovie.Moduls.Content.Enums;
using SystemManagementMovie.Moduls.Content.Repository;
using SystemManagementMovie.Moduls.Content.Services;

namespace SystemManagementMovie.Moduls.Content.Controllers;


[Route("api/contents")]
[ApiController]
public class ContentController : ControllerBase
{
    private readonly IFileService _fileService;
    private readonly IContentRepository _contentRepository; 

    public ContentController(IFileService fileService, IContentRepository contentRepository)
    {
        _fileService = fileService;
        _contentRepository = contentRepository;
    }

    [HttpPost("upload")]
    public async Task<IActionResult> UploadContent([FromForm] IFormFile file, [FromForm] string title, [FromForm] ContentTypes type, [FromForm] int adminId)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }

        try
        {
            string folder = type switch
            {
                ContentTypes.Video => "videos", 
                ContentTypes.Photo => "photos",    
                ContentTypes.Document => "documents", 
                _ => throw new InvalidOperationException("Invalid content type.") 
            };
            
            string fileName = await _fileService.CreateFile(file, folder);

            var content = new Entities.Content
            {
                Title = title,
                FileName = fileName,
                FilePath = Path.Combine(folder, fileName),
                Type = type,
                UploadDate = DateTime.UtcNow,
                AdminId = adminId
            };

            await _contentRepository.AddAsync(content);  
            await _contentRepository.SaveChangesAsync();

            return Ok(new { message = "Content uploaded successfully." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteContent(Guid id)
    {
        try
        {
            var content = await _contentRepository.GetByIdAsync(id);  
            if (content == null)
                return NotFound("Content not found.");
            

            bool fileDeleted = _fileService.DeleteFile(content.FileName, content.FilePath);

            if (fileDeleted)
            {
                await _contentRepository.DeleteAsync(content);  
                await _contentRepository.SaveChangesAsync();

                return Ok(new { message = "Content deleted successfully." });
            }

            return BadRequest("Failed to delete the file.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
