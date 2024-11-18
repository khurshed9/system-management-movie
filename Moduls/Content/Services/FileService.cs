namespace SystemManagementMovie.Moduls.Content.Services;

public class FileService : IFileService
{
    private readonly IWebHostEnvironment _hostEnvironment;
    private const long MaxFileSize = 10 * 1024 * 1024; 

    private readonly HashSet<string> _allowedExtensions = new(StringComparer.OrdinalIgnoreCase)
    { ".jpg", ".png", ".pdf", ".txt" };

    public FileService(IWebHostEnvironment hostEnvironment)
    {
        _hostEnvironment = hostEnvironment;
    }

    public async Task<string> CreateFile(IFormFile file, string folder)
    {
        if (!_allowedExtensions.Contains(Path.GetExtension(file.FileName).ToLower()))
            throw new InvalidOperationException("Invalid file type.");

        if (file.Length > MaxFileSize)
            throw new InvalidOperationException("File size exceeds the maximum allowed size.");

        string fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        string folderPath = Path.Combine(_hostEnvironment.WebRootPath, folder);

        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        string fullPath = Path.Combine(folderPath, fileName);

        try
        {
            await using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return fileName;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("An error occurred while saving the file.", ex);
        }
    }

    public bool DeleteFile(string file, string folder)
    {
        string folderPath = Path.Combine(_hostEnvironment.WebRootPath, folder);
        string fullPath = Path.Combine(folderPath, file);

        try
        {
            if (Directory.Exists(folderPath) && File.Exists(fullPath))
            {
                File.Delete(fullPath);
                return true;
            }
            return false;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("An error occurred while deleting the file.", ex);
        }
    }
}
