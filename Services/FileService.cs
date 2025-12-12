using State_Managment.Options;

namespace State_Managment.Services
{
    public class FileService : IFileService
    {
        private readonly FileSettings _fileSettings;
        public FileService( FileSettings fileSettings)
        {
            _fileSettings = fileSettings;
        }
        public void WriteToFile(string content)
        {
            if(!Directory.Exists(_fileSettings.DefaultLogFolder))
                Directory.CreateDirectory(_fileSettings.DefaultLogFolder);

            File.AppendAllText(Path.Combine(_fileSettings.DefaultLogFolder ,_fileSettings.LogFileName), content + "\n");
        }
    }
}
