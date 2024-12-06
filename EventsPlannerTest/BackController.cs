using EventsPlannerTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsPlannerTest
{
    public class BackController
    {
        private List<Event> events;
        private List<Speaker> speakers;
        private List<Equipment> equipments;

        public BackController(List<Event> _events, List<Speaker> _speakers, List<Equipment> _equipments)
        {
            events = _events;
            speakers = _speakers;
            equipments = _equipments;
        }
        //Events/GetEventsList 
        public List<Event> GetEventsList()
        {
            List<Event> result = [.. events];
            return result;
        }

        public void AddEvent(Event eventToAdd)
        {
            events.Add(eventToAdd);
        }

        public void UpdateEvent(Event eventToUpdate)
        {
            for (int i = 0; i < events.Count; i++)
            {
                if (events[i].Id == eventToUpdate.Id)
                {
                    events[i] = eventToUpdate;
                }
            }
        }

        public void RemoveEvent(Event eventToRemove)
        {
            events.Remove(eventToRemove);
        }

        public void SetSpeakersToEvent(Speaker speaker)
        {
            speakers.Add(speaker);
        }

        public void UnsetSpeakersToEvent(Speaker speaker)
        {
            speakers.Remove(speaker);
        }

        public List<Speaker> GetEventSpeackersList(int event_id)
        {
            List<Speaker> result = speakers.Where(s=>s.EventId==event_id).ToList();
            return result;
        }

        public List<Equipment> GetEventEquipmentList(int event_id)
        {
            List<Equipment> result = equipments.Where(s => s.EventId == event_id).ToList();
            return result;
        }

        public void ReservEquipmentToEvent(Equipment equipment)
        {
            equipments.Add(equipment);
        }

        public void UnsetEquipmentToEvent(Equipment equipment)
        {
            equipments.Remove(equipment);
        }

        public void Authorize()
        {

        }
    }
}
