using WorkSpaceWebAPI.Models;

namespace WorkSpaceWebAPI.Repository
{
    public class UserMembershipPlansRepository : IUserMembershipPlansRepository
    {
        private readonly WorkSpaceDbContext _context;
        public UserMembershipPlansRepository(WorkSpaceDbContext context)
        {
            _context = context;
        }

        public void Delete(UserMembership entity)
        {
            _context.UserMemberships.Remove(entity);
        }

        public void DeleteById(int id)
        {
            UserMembership userMembership = GetById(id);
            _context.UserMemberships.Remove(userMembership);
        }

        public List<UserMembership> GetAll()
        {
            return _context.UserMemberships.ToList();
        }

        public UserMembership GetById(int id)
        {
            return _context.UserMemberships.FirstOrDefault(u => u.Id == id);
        }

        public void Insert(UserMembership entity)
        {
            _context.UserMemberships.Add(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(UserMembership entity)
        {
            _context.Update(entity);
        }
    }
}
