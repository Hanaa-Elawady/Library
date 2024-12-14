namespace Library.Services.Helper
{
    public class DocumentSettings
    {
        public async static Task<string> UploadFile(string file, string folderName ,string Name)
        {
            var fileData = Convert.FromBase64String(file.Split(',')[1]);
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Assests", folderName);
            var fileName = $"{Guid.NewGuid()}-{Name}.png";
            var filePath = Path.Combine(folderPath, fileName);

            var directoryPath = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            await File.WriteAllBytesAsync(filePath, fileData);
            return $"/Assests/{folderName}/{fileName}";
        }
    }
}
