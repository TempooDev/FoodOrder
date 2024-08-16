using Carter;
using FoodOrder.ApiService.Data.Models;

namespace FoodOrder.ApiService.Modules.Users
{
    public class Endpoints : ICarterModule
    {
        public  void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("", () => Collections.Users);

            app.MapGet("/{id}", (int id) => Collections.Users
                                                       .FirstOrDefault(user => user.Id == id));

            app.MapPost("", (User user) => Collections.Users.Add(user));

            app.MapPut("/{id}", (int id, User user) =>
            {
                User? currentUser = Collections.Users
                                              .FirstOrDefault(user => user.Id == id);
                if (currentUser == null)
                {
                    return;
                }
                currentUser.FirstName = user.FirstName;
                currentUser.LastName = user.LastName;
                currentUser.BirthDate = user.BirthDate;
            });

            app.MapDelete("/{id}", (int id) =>
            {
                var userForDeletion = Collections.Users
                                                 .FirstOrDefault(user => user.Id == id);

                Collections.Users.Remove(userForDeletion!);
            });
        }
    }
}
