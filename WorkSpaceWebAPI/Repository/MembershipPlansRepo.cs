using WorkSpaceWebAPI.Models;

namespace WorkSpaceWebAPI.Repository
{
    public class MembershipPlansRepo : IMembershipPlansRepo
    {
        ApplicationDbContext context;
        public MembershipPlansRepo(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Delete(MemberShipPlan entity)
        {
            if (entity != null)
            {
                context.MemberShipPlans.Remove(entity);
            }
        }

        public void DeleteById(int id)
        {
            MemberShipPlan item = GetById(id);
            if (item != null)
            {
                context.MemberShipPlans.Remove(item);
            }
        }

        public List<MemberShipPlan> GetAll()
        {
            return context.MemberShipPlans.ToList();
        }

        public MemberShipPlan GetById(int id)
        {
            return context.MemberShipPlans.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(MemberShipPlan entity)
        {
            context.MemberShipPlans.Add(entity);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(MemberShipPlan entity)
        {
            context.Update(entity);
        }
    }
}
