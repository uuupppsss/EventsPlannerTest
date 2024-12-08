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
        public List<Speaker> speakers;
        public List<EquipmentReservation> EquipmentReservations { get; set; }
        public List<Equipment> Equipments;
        public List<Place> Places;

        public BackController(List<Event> _events, List<Speaker> _speakers, List<EquipmentReservation> _equipments)
        {
            events = _events;
            speakers = _speakers;
            EquipmentReservations = _equipments;

            Equipments = new List<Equipment>()
            {
                new Equipment()
                {
                    Id=1,
                    Name="Микрофон"
                },
                new Equipment()
                {
                    Id=2,
                    Name="Колонка"
                },
                new Equipment()
                {
                    Id=3,
                    Name="Проектор"
                }
            };

            Places = new List<Place>()
            {
                new Place()
                {
                    Id=1,
                    Name="Актовый зал"
                },

                new Place()
                {
                    Id=2,
                    Name="Кабинет 103"
                },

                new Place()
                {
                    Id=3,
                    Name="Кабинет 100"
                },
            };
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
            speakers.RemoveAll(s => s.EventId == id);
            EquipmentReservations.RemoveAll(s => s.EventId == id);

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

        //Speakers/GetEventSpeackersList - Запрос Get на получение списка участников выбранного мероприятия. Принимает параметр: int event_id, параметр ответа:List<Speaker>
        public List<Speaker> GetEventSpeackersList(int event_id)
        {
            List<Speaker> result = speakers.Where(s => s.EventId == event_id).ToList();
            return result;
        }

        //Equipment/GetEventEquipmentList - Запрос Get на получение списка оборудования для выбранного мероприятия. Принимает параметр: int event_id, параметр ответа:List<Equipment>
        public List<Equipment> GetEventEquipmentList(int event_id)
        {
            List<Equipment> result = [];
            var reservations=EquipmentReservations.Where(s => s.EventId == event_id).ToList();
            foreach (var reservation in reservations)
            {
                var equipment = Equipments.FirstOrDefault(e => e.Id == reservation.EquipmentId);
                result.Add(equipment);
            }
            return result;
        }

        //Equipment/ReservEquipmentToEvent - Запрос Post на резервирование нового оборудования. Принимает параметр: объект Equipment, параметр ответа:200
        public void ReservEquipmentToEvent(EquipmentReservation equipment)
        {
            EquipmentReservations.Add(equipment);
        }

        //Equipment/UnsetEquipmentToEvent - Запрос Delete на удаление брони оборудования. Принимает параметр: int id, параметр ответа:200
        public void UnsetEquipmentToEvent(int id)
        {
            var equipment = EquipmentReservations.FirstOrDefault(e => e.Id == id);
            if (equipment != null) EquipmentReservations.Remove(equipment);
        }

        //Equipment/UpdateEquipmentsList - Запрос Post на обновление списка оборудования. Принимает параметр: List<Equipment>, параметр ответа:200
        public void UpdateEquipmentsList(List<Equipment> equipments_list)
        {
            Equipments=equipments_list;
        }

        //Equipment/GetEquipmentsList - Запрос Get на получение списка всего доступного оборудования. Принимает параметр DateTime, параметр ответа:List<Equipment>
        public List<Equipment> GetEquipmentsList(DateTime? date=null)
        {
            List<Equipment> result = [.. Equipments];

            if (date != null)
            {
                var thisdate_eventsIds = events.Where(e => e.Date == date).Select(e=>e.Id).ToList();
                var reservedEquipmentIds = EquipmentReservations.Where(r => thisdate_eventsIds.Contains(r.EventId)).Select(r=>r.EquipmentId).ToList();
                result=result.Where(r=>!reservedEquipmentIds.Contains(r.Id)).ToList();
            }

            return result;
        }

        //Place/GetPlacesList - Запрос Get на получение списка всего доступных мест. Принимает параметр DateTime, параметр ответа:List<Place>
        public List<Place> GetPlacesList(DateTime? date = null)
        {
            List<Place> result = [.. Places];

            if (date != null)
            {
                var reservedPlacesIds = events.Where(e => e.Date == date).Select(e => e.PlaceId).ToList();
                result = result.Where(r => !reservedPlacesIds.Contains(r.Id)).ToList();
            }

            return result;
        }

        //Place/UpdatePlacesList - Запрос Post на обновление списка мест. Принимает параметр: List<Place>, параметр ответа:200
        public void UpdatePlacesList(List<Place> places_list)
        {
            Places= places_list;
        }
    }
}
