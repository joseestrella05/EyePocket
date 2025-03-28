using Microsoft.AspNetCore.Identity;

namespace EyePocket.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public DateTime FechaIngreso { get; set; } = DateTime.Now;
        public DateTime FechaNacimiento { get; set; } = DateTime.Now;
    }

}
