using HomeHero_API.Data;
using HomeHero_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Threading.Tasks;

public class DatabaseInitializer
{
    public async Task InitializeDatabaseAsync(IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())  // Crea un nuevo ámbito
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
        // Eliminar la base de datos
        await _context.Database.EnsureDeletedAsync();

        // Crear nuevamente la base de datos
        await _context.Database.EnsureCreatedAsync();

        // Sembrar o inicializar data
        Seed();
        await _context.SaveChangesAsync();
    }
    private void Seed()
    {
        // Comprueba si ya existen datos en la tabla Roles
        if (!_context.Role.Any())
        {
            _context.Role.AddRange(
                new Role { RoleID = 1, NameRole = "Admon" },
                new Role { RoleID = 2, NameRole = "User" },
                new Role { RoleID = 3, NameRole = "PUser" },
                new Role { RoleID = 4, NameRole = "Reviewer" },
                new Role { RoleID = 5, NameRole = "TSupport" }
            );
        }
        if (!_context.State.Any())
        {
            _context.State.AddRange(
                new State { StateID = 1, NameState = "Preparado" },
                new State { StateID = 2, NameState = "Progreso" },
                new State { StateID = 3, NameState = "Evaluacion" },
                new State { StateID = 4, NameState = "Pagado" },
                new State { StateID = 5, NameState = "PagoConfirmado" },
                new State { StateID = 6, NameState = "Terminado" }
            );
        }
        if (!_context.Location.Any())
        {
            _context.Location.AddRange(
                new Location { LocationID = 1, City = "Facatativa" },
                new Location { LocationID = 2, City = "San Juan" },
                new Location { LocationID = 3, City = "Bogota" },
                new Location { LocationID = 4, City = "Madrid" }
            );
        }
        if (!_context.User.Any())
        {
            /*_context.User.AddRange(
                new User
                {
                    UserId = 1,  
                    RoleID_User = 1,
                    RealUserID = null, 
                    NamesUser = "John",
                    SurnamesUser = "Doe",
                    ProfilePicture = null, 
                    VolunteerVoucher = null,
                    QualificationUser = 5, 
                    Email = "john.doe@example.com",
                    Password = new byte[] { 0x01, 0x02, 0x03, 0x04 }, 
                    Salt = new byte[] { 0x05, 0x06, 0x07, 0x08 }, 
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
               
            );*/
        }

    }

}
