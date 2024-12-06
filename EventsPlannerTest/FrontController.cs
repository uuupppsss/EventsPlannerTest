using EventsPlannerTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsPlannerTest
{
    public class FrontController
    {
        private List<Event> events;

        public FrontController(List<Event> _events)
        {
            events = _events;
        }
        public List<Event> GetEventsList()
        {
            List<Event> result = [.. events]; 
            return result;
        }

        public List<Event> GetFiltredByDateEvents(DateTime date, List<Event> events=null)
        {
            List<Event> sourseList;
            if (events == null) sourseList = this.events;
            else sourseList = events;

            List<Event> result = [];
            result.AddRange(sourseList.Where(e => e.Date == date));
            return result;
        }

        public List<Event> GetFiltredByTypeEvents(string type, List<Event> events = null)
        {
            List<Event> sourseList;
            if (events == null) sourseList = this.events;
            else sourseList = events;

            List<Event> result = [];
            result.AddRange(sourseList.Where(e => e.Type == type));
            return result;
        }
    }
}
