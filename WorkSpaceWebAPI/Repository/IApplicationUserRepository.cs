using WorkSpaceWebAPI.DTO;
using WorkSpaceWebAPI.Models;

namespace WorkSpaceWebAPI.Repository
{
    public interface IApplicationUserRepository : IGenericRepository<ApplicationUser>
    {
        public UserDataDto GetUserById(int id);
    }
}
