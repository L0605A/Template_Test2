using ExampleTest2.Models;

namespace ExampleTest2.Services;

public interface IDbService
{
    
    Task<bool> DoesObjectExist(int id);
    Task<SampleModel3?> GetObjectByName(string name);
    Task<ICollection<SampleModelJoint>> GetMultipleObjectsData(string? name);
    Task AddNewObject(SampleModelJoint samObj);
    Task AddMultipleObjects(IEnumerable<SampleAssociativeModel> mulObjects);
}