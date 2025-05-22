using Microsoft.EntityFrameworkCore;

namespace RecruitX.Models
{
    public class Clients
    {
        public int Client_Id { get; set; }
        public string Client_Name { get; set; }
        public string? Client_Country { get; set; }
    }

}
