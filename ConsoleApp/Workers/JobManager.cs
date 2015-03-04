
namespace Spike.ConsoleApp.Workers
{
    using System;
    using System.Threading;
    using Model;


    public class JobManager
    {
        public const string FilePath = @"C:\ConsoleApp.txt";
        private const int DelayInMilliseconds = 1000;
        private readonly Timer _timer;

        public JobManager()
        {
            _timer = new Timer(DoWork, null, Timeout.Infinite, Timeout.Infinite);
        }

        public void Start()
        {
            _timer.Change(DelayInMilliseconds, Timeout.Infinite);
        }
        
        private static void UpdateAuthorsAndSaveFile()
        {
            var provider = ProviderFactory.CreateAuthorProvider();
            var authors = provider.GetAllAuthors();

            var time = string.Format("Time: [{0}]", DateTime.Now.ToUniversalTime());

            var file = new FileWorker(FilePath);
            file.AppendLineToFile(time);
            file.AppendLineToFile(string.Empty);

            foreach (var author in authors)
            {
                file.AppendLineToFile(string.Format("Name: [{0}] Birth Day: [{1}]", author.Name, author.BirthDay));
            }

            file.Close();
        }

        private void DoWork(object obj)
        {
            // Pause timer during processing so it
            // wont be run twice if the processing takes longer
            // than the interval for some reason
            _timer.Change(Timeout.Infinite, Timeout.Infinite);

            UpdateAuthorsAndSaveFile();

            _timer.Change(DelayInMilliseconds, Timeout.Infinite);
        }
    }
}
