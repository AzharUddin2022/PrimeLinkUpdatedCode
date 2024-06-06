using Component;
using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Common
{
    public class FTPConfig
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Location { get; set; }
    }

    public class FTPFileDetail
    {
        public string FileName { get; set; }
        public decimal Size { get; set; }
        public string  Date { get; set; }
    }
    public class DatabaseConfig
    {
        public int Id { get; set; }
        public string Host { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }
        public string Table { get; set; }
        //[Required(ErrorMessage = "Source Title is required.")]
        public string SourceTitle { get; set; }
    }

    public class DatabaseConnection
    {
        public string DBconnection { get; set; }
        public string TableName { get; set; }
     
    }

     public class DatabaseTable
    {
        public string ColumnName { get; set; }
        public string DataType { get; set; }
    }
}
