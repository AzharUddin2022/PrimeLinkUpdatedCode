using System.IO;
namespace Component
{
    public class Global
    {
        #region DocumentLibrary
        public static string AzureConnection = "DefaultEndpointsProtocol=https;AccountName=tccdocumentlibrary;AccountKey=V5H0deUHI7DPHm0M0YICSY0M6xEsZwoJy8XJVdU0LKsiY4DPFg1KFVZklH+bkNsydrDfYlxbIbw3mCDiEQclqQ==;EndpointSuffix=core.windows.net";
        public static string AzureSharefiles = "production";//"production";
        public static string _folderName = "files";
        public static string _fileformat = "xls,pdf";
        public static string webRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        public static string FolderPath = Path.Combine(webRootPath, _folderName);
        #endregion
    }
}
