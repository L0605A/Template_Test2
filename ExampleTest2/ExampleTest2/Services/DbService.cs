using ExampleTest2.Data;
using ExampleTest2.Models;
using Microsoft.EntityFrameworkCore;

namespace ExampleTest2.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;
    public DbService(DatabaseContext context)
    {
        _context = context;
    }
    

    public async Task<bool> DoesObjectExist(int id)
    {
        return await _context.SampleModel1.AnyAsync(e => e.Id == id);
    }

    public async Task<SampleModel3?> GetObjectByName(string name)
    {
        return await _context.SampleModel3.FirstOrDefaultAsync(e => e.Name == name);
    }

    public async Task<ICollection<SampleModelJoint>> GetMultipleObjectsData(string? name)
    {
        return await _context.SampleModelJoint
            .Include(e => e.Client)
            .Include(e => e.sampleAssociativeModels)
            .ThenInclude(e => e.Pastry)
            .Where(e => name == null || e.Client.LastName == name)
            .ToListAsync();
    }

    public async Task AddNewObject(SampleModelJoint samObj)
    {
        await _context.AddAsync(samObj);
        await _context.SaveChangesAsync();
    }

    public async Task AddMultipleObjects(IEnumerable<SampleAssociativeModel> mulObjects)
    {
        await _context.AddRangeAsync(mulObjects);
        await _context.SaveChangesAsync();
    }
}