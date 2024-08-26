using CaveProvider.Identity.API.Dto;

namespace CaveProvider.Identity.API.Models
{
    public class Token
    {
        public  string? Access_token { get; set; }
        public double Expires_in { get; set; }
    

    }
}
