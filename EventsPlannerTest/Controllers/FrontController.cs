using EventsPlannerTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsPlannerTest.Controllers
{
    public class FrontController
    {
        private List<Event> events;
        public List<Speaker> Speakers;

        public FrontController(List<Event> _events, List<Speaker> _speakers)
        {
            events = _events;
            Speakers = _speakers;
        }

        //Events/GetEventsList - Запрос Get на получение списка мероприятий.  Принимает параметры:string? filtertype и DateTime? filterdate, параметр ответа: List<Event>
        public List<Event> GetEventsList(string? filtertype=null, DateTime? filterdate=null)
        {
            List<Event> result = [.. events];

            if (filterdate != null) result=result.Where(e=>e.Date==filterdate).ToList();

            if (filtertype != null) result=result.Where(e=>e.Type==filtertype).ToList();

            return result;
        }

        //Speakers/SetSpeakersToEvent - Запрос Post на добавление нового участника. Принимает параметр: объект Speaker, параметр ответа:200
        public void SetSpeakersToEvent(Speaker speaker)
        {
            Speakers.Add(speaker);
        }
    }
}
