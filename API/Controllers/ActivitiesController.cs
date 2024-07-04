using Application.Activities;
using Domain.obj;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        [HttpGet]
        // public async Task<ActionResult<List<Activity>>> GetActivities()
        public async Task<IActionResult> GetActivities()
        {
            // return await Mediator.Send(new List.Query());
            var result = await Mediator.Send(new List.Query());
            return HandelResult(result);
        }

        [HttpGet("{id}")]
        // public async Task<ActionResult<Activity>> GetActivity(Guid id)
        public async Task<IActionResult> GetActivity(Guid id)
        {
            // return await Mediator.Send(new Details.Query{Id = id});
            var result = await Mediator.Send(new Details.Query{Id = id});

            // if (result.IsSuccess && result.Value != null)
            //     return Ok(result.Value);
            // if (result.IsSuccess && result.Value == null)
            //     return NotFound();
            // return BadRequest(result.Error);

            return HandelResult(result);
            
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity(Activity activity)  
        {
            return HandelResult(await Mediator.Send(new Create.Command{Activity =  activity}));
            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivity(Guid id, Activity activity)
        {
            activity.Id = id;
            return HandelResult(await Mediator.Send(new Edit.Command{Activity = activity}));
           
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id)
        {
           return HandelResult(await Mediator.Send(new Delete.Command{Id = id}));
            
        }
    }
}