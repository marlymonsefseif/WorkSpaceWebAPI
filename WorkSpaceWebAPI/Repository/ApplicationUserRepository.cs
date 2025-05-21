using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorkSpaceWebAPI.DTO;
using WorkSpaceWebAPI.Models;

namespace WorkSpaceWebAPI.Repository
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly WorkSpaceDbContext _context;
        public ApplicationUserRepository(WorkSpaceDbContext context)
        {
            _context = context;
        }

        public void Delete(ApplicationUser entity)
        {
            _context.Users.Remove(entity);
        }

        public void DeleteById(int id)
        {
            ApplicationUser user = GetById(id);
            _context.Users.Remove(user);
        }

        public List<ApplicationUser> GetAll()
        {
            return _context.Users.ToList();
        }

        public ApplicationUser GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public UserDataDto GetUserById(int id)
        {
            return _context.Users.Select(u => new UserDataDto()
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                membershipName = u.Memberships.Select(m => m.MembershipPlan.Name).ToList()
            }).FirstOrDefault(u => u.Id == id);
        }

        public void Insert(ApplicationUser entity)
        {
            _context.Users.Add(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(ApplicationUser entity)
        {
            _context.Update(entity);
        }
    }
}
