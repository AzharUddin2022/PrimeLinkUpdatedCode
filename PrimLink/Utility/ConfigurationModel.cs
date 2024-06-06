namespace PrimLink.Utility
{
    public class ConfigurationModel
    {
        public string FromAddress { get; set; }
        public string Server { get; set; }
        public int Port { get; set; }
        public string Domain { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool? TLS { get; set; }
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
    }
}
