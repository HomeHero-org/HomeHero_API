using HomeHero_API.Data;
using HomeHero_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Reflection.Emit;
using System.Threading.Tasks;

public class DatabaseInitializer
{
    public async Task InitializeDatabaseAsync(IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())  
        {
            var initializer = scope.ServiceProvider.GetRequiredService<DatabaseInitializer>();
            await initializer.InitializeAsync();
        }
    }

    private readonly ApplicationDbContext _context;

    public DatabaseInitializer(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task InitializeAsync()
    {
        await _context.Database.EnsureDeletedAsync();

        await _context.Database.EnsureCreatedAsync();

        Seed();
        await _context.SaveChangesAsync();
    }
    private void Seed()
    {
        if (!_context.Role.Any())
        {
            _context.Role.AddRange(
                new Role {  NameRole = "Admon" },
                new Role {  NameRole = "User" },
                new Role {  NameRole = "PUser" },
                new Role {  NameRole = "Reviewer" },
                new Role {  NameRole = "TSupport" }
            );
        }
        if (!_context.State.Any())
        {
            _context.State.AddRange(
                new State { NameState = "Preparado" },
                new State { NameState = "Progreso" },
                new State { NameState = "Evaluacion" },
                new State { NameState = "Pagado" },
                new State { NameState = "PagoConfirmado" },
                new State { NameState = "Terminado" }
            );
        }
        if (!_context.Area.Any())
        {
            _context.Area.AddRange(
                new Area { NameArea = "Fontaneria" },
                new Area { NameArea = "Educacion" },
                new Area { NameArea = "Mascotas" },
                new Area { NameArea = "Medicina" },
                new Area { NameArea = "Construccion" }
            );
        }
        if (!_context.User.Any())
        {
            _context.User.AddRange(
                new User
                {
                    RoleID_User = 1,
                    RealUserID = null,
                    NamesUser = "John",
                    SurnamesUser = "Doe",
                    ProfilePicture = null,
                    VolunteerVoucher = null,
                    QualificationUser = 5,
                    Email = "john.doe@example.com",
                    Password = "",                
                    LocationResidenceID = 1,
                    SexUser = 'M',
                    Curriculum = null,
                    VolunteerPermises = true,
                    Applications = null,
                    AttentionRequests = null,
                    Messages = null,
                    UnsatisfiedUsers = null,
                    AttenderUsers = null,
                    ComplaintedUsers = null,
                    Contacts = null,
                    Doubts = null,
                    Qualifications = null,
                    Requests = null,
                    Tutorials = null
                }

            );
        }

    }

}
