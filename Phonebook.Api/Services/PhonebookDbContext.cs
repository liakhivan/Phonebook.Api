using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Phonebook.Api.Services
{
    public class PhonebookDbContext: IdentityDbContext<IdentityUser>
    {
        public PhonebookDbContext(DbContextOptions<PhonebookDbContext> options) : base(options)
        {
        }
    }
}
