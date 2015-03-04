
namespace Spike.ConsoleApp.Workers
{
    using System.IO;

    public class FileWorker
    {
        private readonly string _filePath;
        private FileStream _file;

        public FileWorker(string filePath)
        {
            this._filePath = filePath;
            this.CreateFile();
        }

        private void CreateFile()
        {
            _file = File.Create(_filePath);
            _file.Close();
        }

        public static void RemoveFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public void AppendLineToFile(string line)
        {
            using (var sw = File.AppendText(_filePath))
            {
                sw.WriteLine(line);
            }	
        }

        public void Close()
        {
            _file.Close();
        }
    }
}
