using Component;

namespace Model.Common
{
    public class ResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public bool IsAdmin { get; set; }
        public int Status { get; set; }
        public object Model { get; set; }
        public Action Action { get; set; }
    }
}
