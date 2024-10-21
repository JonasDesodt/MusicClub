using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicClub.DbCore;

namespace MusicClub.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PushController(CalendarService googleCalendarService, MusicClubDbContext dbContext, IGoogleEventService googleEventDbService, IGoogleCalendarService googleCalendarDbService) : ControllerBase
    {
        [HttpPost("Google-Calendar")] // should this be a get? there are only ids send
        public async Task<IActionResult> GoogleCalendar([FromBody] GoogleCalendarPushRequest googleCalendarPushRequest)
        {
            if ((await googleCalendarDbService.Get(googleCalendarPushRequest.GoogleCalendarId)).Data is not { } googleCalendar)
            {
                return BadRequest(); //todo
            }

            if ((await dbContext.Acts.Include(a => a.GoogleEvent).FirstOrDefaultAsync(a => a.Id == googleCalendarPushRequest.ActId)) is not {/* GoogleEventId: null, */Start: not null, Duration: > 0 } act)
            {
                return BadRequest(); //todo
            }

            var @event = new Event
            {
                Summary = act.Name,
                Description = act.Title,
                //Location = "800 Howard St., San Francisco, CA 94103",
                Start = new EventDateTime
                {
                    DateTimeRaw = act.Start?.ToString("o"),
                    TimeZone = "Europe/Brussels"
                },
                End = new EventDateTime
                {
                    DateTimeRaw = (act.Start?.AddMinutes((double)act.Duration))?.ToString("o"),
                    TimeZone = "Europe/Brussels"
                }
            };

            if (act.GoogleEventId > 0 && act.GoogleEvent is not null)
            {
                //first check if an update is possible (does the event still exist)?
                if (await googleCalendarService.Events.Update(@event, googleCalendar.GoogleIdentifier, act.GoogleEvent.GoogleIdentifier).ExecuteAsync() is null)
                {
                    return BadRequest(); //todo
                }
                //else create Insert & create new GoogleEvent in db & change googleEventId in db act 
                
            }
            else
            {
                if (await googleCalendarService.Events.Insert(@event, googleCalendar.GoogleIdentifier).ExecuteAsync() is not { } eventResponse)
                {
                    return BadRequest(); //todo
                }

                var googleEventServiceresult = await googleEventDbService.Create(new GoogleEventRequest
                {
                    ActId = act.Id,
                    GoogleCalendarId = googleCalendar.Id,
                    GoogleIdentifier = eventResponse.Id
                });
                if (googleEventServiceresult.Data is null)
                {
                    await googleCalendarService.Events.Delete(googleCalendar.GoogleIdentifier, eventResponse.Id).ExecuteAsync();

                    return BadRequest(); //todo
                }

                act.GoogleEventId = googleEventServiceresult.Data.Id;
                act.Updated = DateTime.UtcNow;

                dbContext.Acts.Update(act);
                await dbContext.SaveChangesAsync();
            }

            return Ok();
        }
    }
}
