namespace InstafoodApp.Web.Client.DTO
{
    public class LoginResponse
    {
        public string message { get; set; } = string.Empty;
        public string role { get; set; }=string.Empty;
        public string userId {  get; set; } =string.Empty;
        public string name { get; set; } = string.Empty;
    }
}
