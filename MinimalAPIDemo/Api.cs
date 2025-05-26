namespace MinimalAPIDemo;

public static class Api
{
    public static void ConfigureApi(this WebApplication app)
    {
        // All of my API endpoints will be defined here
        app.MapGet("/Users", GetUsers);
        app.MapGet("/Users/{id}", GetUser);
        app.MapPost("/Users", InsertUser);
        app.MapPut("/Users", UpdateUser);
        app.MapDelete("/Users/{id}", DeleteUser);
    }

    private static async Task<IResult> GetUsers(IUserData data)
    {
        try
        {
            var users = await data.GetUsers();
            return Results.Ok(users);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetUser(int id, IUserData data)
    {
        try
        {
            var user = await data.GetUser(id);
            if (user is null)
            {
                return Results.NotFound();
            }
            return Results.Ok(user);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> InsertUser(UserModel user, IUserData data)
    {
        try
        {
            await data.InserUser(user);
            return Results.Created($"/Users/{user.Id}", user);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateUser(UserModel user, IUserData data)
    {
        try
        {
            await data.UpdateUser(user);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteUser(int id, IUserData data)
    {
        try
        {
            await data.DeleteUser(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
