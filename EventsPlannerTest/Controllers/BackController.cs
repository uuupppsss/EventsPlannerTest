using EventsPlannerTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsPlannerTest.Controllers
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
        //Events/GetEventsList - Запрос Get на получение списка мероприятий.  Принимает параметры:string? filtertype и DateTime? filterdate, параметр ответа: List<Event>
        public List<Event> GetEventsList(string? filtertype = null, DateTime? filterdate = null)
        {
            List<Event> result = [.. events];

            if (filterdate != null) result = result.Where(e => e.Date == filterdate).ToList();

            if (filtertype != null) result = result.Where(e => e.Type == filtertype).ToList();

            return result;
        }

        //Events/AddEvent - Запрос Post на создание нового мероприятия. Принимает параметр: объект Event, параметр ответа:200
        public void AddEvent(Event eventToAdd)
        {
            events.Add(eventToAdd);
        }

        //Events/UpdateEvent - Запрос Put на изменение мероприятия. Принимает параметр: объект Event, нпараметр ответа:200
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

        //Events/RemoveEvent - Запрос Delete на удаление мероприятия. Принимает параметр: int id, параметр ответа:200
        public void RemoveEvent(int id)
        {
            Event eventToRemove = events.FirstOrDefault(e => e.Id == id);
            if (eventToRemove != null) events.Remove(eventToRemove);
        }

        //Speakers/SetSpeakersToEvent - Запрос Post на добавление нового участника. Принимает параметр: объект Speaker, параметр ответа:200
        public void SetSpeakersToEvent(Speaker speaker)
        {
            speakers.Add(speaker);
        }

        //Speakers/UnsetSpeakersToEvent - Запрос Delete на удаление участника. Принимает параметр: int id, параметр ответа:200
        public void UnsetSpeakersToEvent(int id)
        {
            Speaker speaker = speakers.FirstOrDefault(e => e.Id == id);
            if (speaker != null) speakers.Remove(speaker);
        }

        //Speakers/GetEventSpeackersList - Запрос Get на получение списка участников выбранного мероприятия. Принимает параметр: int event_id, параметр ответа:200
        public List<Speaker> GetEventSpeackersList(int event_id)
        {
            List<Speaker> result = speakers.Where(s => s.EventId == event_id).ToList();
            return result;
        }

        //Equipment/GetEventEquipmentList - Запрос Get на получение списка оборудования для выбранного мероприятия. Принимает параметр: int event_id, параметр ответа:200
        public List<Equipment> GetEventEquipmentList(int event_id)
        {
            List<Equipment> result = equipments.Where(s => s.EventId == event_id).ToList();
            return result;
        }

        //Equipment/ReservEquipmentToEvent - Запрос Post на резервирование нового оборудования. Принимает параметр: объект Equipment, параметр ответа:200
        public void ReservEquipmentToEvent(Equipment equipment)
        {
            equipments.Add(equipment);
        }

        //Equipment/UnsetEquipmentToEvent - Запрос Delete на удаление брони оборудования. Принимает параметр: int id, параметр ответа:200
        public void UnsetEquipmentToEvent(int id)
        {
            Equipment equipment = equipments.FirstOrDefault(e => e.Id == id);
            if (equipment != null) equipments.Remove(equipment);
        }
    }
}
