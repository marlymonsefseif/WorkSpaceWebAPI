using WorkSpaceWebAPI.Models;

namespace WorkSpaceWebAPI.Repository
{
    public interface IUserMembershipPlansRepository : IGenericRepository<UserMembership>
    {
        public List<UserMembership> GetSpecificMembership(int purchaseId);
    }
}
