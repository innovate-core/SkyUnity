using SkyUnityCore.Entities;

namespace SkyUnityCore.Repositories;

public interface IUserRepository
{
    Task Insert(User user);
}

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task Insert(User user)
    {
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        try
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex}");
        }
    }
}
