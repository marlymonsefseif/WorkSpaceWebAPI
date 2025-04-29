using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkSpaceWebAPI.DTO;
using WorkSpaceWebAPI.Models;
using WorkSpaceWebAPI.Repository;

namespace WorkSpaceWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipPlansController : ControllerBase
    {
        private readonly IMembershipPlansRepository membershipPlansRepository;
        public MembershipPlansController(IMembershipPlansRepository membershipPlansRepository) 
        {
            this.membershipPlansRepository = membershipPlansRepository;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            List<MembershipPlan> list = membershipPlansRepository.GetAll();
            if(list == null)
                return NotFound();
            return Ok(list);
        }
        [HttpGet("{id:int}")]
        public ActionResult Get(int id)
        {
            MembershipPlan plan = membershipPlansRepository.GetById(id);
            if(plan == null)
                return NotFound();
            return Ok(plan);
        }
        [HttpPost]
        public ActionResult Add(MembershipPlanDTO planDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MembershipPlan plan = new MembershipPlan
                    {
                        Name = planDTO.Name,
                        Description = planDTO.Description,
                        DurationInDays = planDTO.DurationInDays,
                        Price = planDTO.Price
                    };
                    membershipPlansRepository.Insert(plan);
                    membershipPlansRepository.Save();
                    return Created();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.InnerException.Message);
                }
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{id:int}")]
        public ActionResult Edit(int id, MembershipPlanDTO plan)
        {
            if (ModelState.IsValid)
            {
                MembershipPlan membershipPlan = membershipPlansRepository.GetById(id);
                if (membershipPlan == null)
                    return NotFound();
                try
                {
                    membershipPlan.Name = plan.Name;
                    membershipPlan.Description = plan.Description;
                    membershipPlan.DurationInDays = plan.DurationInDays;
                    membershipPlan.Price = plan.Price;
                    membershipPlansRepository.Update(membershipPlan);
                    membershipPlansRepository.Save();
                    return Ok();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.InnerException.Message);
                }
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            MembershipPlan plan = membershipPlansRepository.GetById(id);
            if(plan == null)
                return NotFound();
            membershipPlansRepository.Delete(plan);
            membershipPlansRepository.Save();
            return Ok();
        }
    }
}
