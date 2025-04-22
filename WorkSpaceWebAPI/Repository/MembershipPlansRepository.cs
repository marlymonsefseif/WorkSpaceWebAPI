using WorkSpaceWebAPI.Models;

namespace WorkSpaceWebAPI.Repository
{
    public class MembershipPlansRepository : IMembershipPlansRepository
    {
        WorkSpaceDbContext context;
        public MembershipPlansRepository(WorkSpaceDbContext context)
        {
            this.context = context;
        }
        public void Delete(MembershipPlan entity)
        {
            if (entity != null)
            {
                context.MembershipPlans.Remove(entity);
            }
        }

        public void DeleteById(int id)
        {
            MembershipPlan item = GetById(id);
            if (item != null)
            {
                context.MembershipPlans.Remove(item);
            }
        }

        public List<MembershipPlan> GetAll()
        {
            return context.MembershipPlans.ToList();
        }

        public MembershipPlan GetById(int id)
        {
            return context.MembershipPlans.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(MembershipPlan entity)
        {
            context.MembershipPlans.Add(entity);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(MembershipPlan entity)
        {
            context.Update(entity);
        }
    }
}
