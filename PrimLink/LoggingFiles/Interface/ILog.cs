namespace PrimLink.LoggingFiles.Interface
{
    public interface ILog
    {
        void Error(string ex);
        void Information(string message);
        void Warning(string message);
        void Debuging(string message);
    }
}
