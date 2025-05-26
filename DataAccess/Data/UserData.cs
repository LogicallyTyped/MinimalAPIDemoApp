using DataAccess.DbAccess;
using DataAccess.Models;

namespace DataAccess.Data;
public class UserData : IUserData
{
    private readonly ISqlDataAccess _db;

    public UserData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<UserModel>> GetUsers() =>
        _db.LoadData<UserModel, dynamic>(storedProcedure: "dbo.spuGetAll", new { });

    public async Task<UserModel?> GetUser(int id)
    {
        var results = await _db.LoadData<UserModel, dynamic>(storedProcedure: "dbo.spuGet", new { Id = id });
        return results.FirstOrDefault();
    }

    public Task InserUser(UserModel user) =>
        _db.SaveData(storedProcedure: "dbo.spuInsert", new { user.FirstName, user.LastName });

    public Task UpdateUser(UserModel user) =>
        _db.SaveData(storedProcedure: "dbo.spuUpdate", user);

    public Task DeleteUser(int id) =>
        _db.SaveData(storedProcedure: "dbo.spuDelete", new { Id = id });
}
