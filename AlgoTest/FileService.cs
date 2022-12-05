using CsvHelper;
using Microsoft.Extensions.Logging;
using System.Globalization;
using System.Reflection;

namespace AlgoTest
{
    public interface IFileService
    {
        int[] ReadPhoneNumbers(string fileName);
        void WritePhoneNumbers(int[] phoneNumbers, string fileName);
    }

    public class FileService : IFileService
    {
        private readonly ILogger<IFileService> _logger;
        public FileService(ILogger<IFileService> logger)
        {
            _logger = logger;
        }

        public int[] ReadPhoneNumbers(string filePath)
        {
            try
            {
                using (var streamReader = new StreamReader(filePath))
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                    return csvReader.GetRecords<int>().ToArray();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{GetType().Name}.{MethodBase.GetCurrentMethod()?.Name}: Error {ex.Message}", ex);
                throw ex;
            }
        }

        public void WritePhoneNumbers(int[] phoneNumbers, string filePath)
        {
            try
            {
                using (var streamWriter = new StreamWriter(filePath))
                using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
                    csvWriter.WriteRecords(phoneNumbers);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{GetType().Name}.{MethodBase.GetCurrentMethod()?.Name}: Error {ex.Message}", ex);
                throw ex;
            }
        }
    }
}