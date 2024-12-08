using EventsPlannerTest.Controllers;
using EventsPlannerTest.Model;

namespace EventsPlannerTest.Tests
{
    public class TestsBack
    {
        BackController Model;
        [SetUp]
        public void SetUp()
        {
            Model = new BackController(new List<Event>()
            {
                new Event()
                {
                    Id = 1,
                    Name="Посвящение в студенты",
                    Type="Информационное",
                    Date=new DateTime(2024/9/20),
                    PlaceId=1,
                },

                new Event()
                {
                    Id = 2,
                    Name="Веселые старты",
                    Type="Спортивное",
                    Date=new DateTime(2024/9/14),
                    PlaceId=2,
                },

                new Event()
                {
                    Id = 3,
                    Name="Выпускной",
                    Type="Праздничное",
                    Date=new DateTime(2025/6/20),
                    PlaceId=3,
                },

                new Event()
                {
                    Id = 4,
                    Name="23 февраля",
                    Type="Праздничное",
                    Date=new DateTime(2025/2/23),
                    PlaceId=3,
                },
            },
            new List<Speaker>()
            {
                new Speaker()
                {
                    Id=1,
                    UserId=1,
                    Name="Тимур",
                    EventId=1,
                },

                new Speaker()
                {
                    Id=2,
                    UserId=1,
                    Name="Олег",
                    EventId=3,
                },
            },
            new List<EquipmentReservation>()
            {
                new EquipmentReservation()
                {
                    Id=1,
                    EquipmentId=1,
                    EventId=1,
                },
                new EquipmentReservation()
                {
                    Id=2,
                    EquipmentId = 2,
                    EventId=1,
                },

                new EquipmentReservation()
                {
                    Id=2,
                    EquipmentId = 2,
                    EventId=3,
                }
            });

        }

        [Test]
        public void AddEventTest()
        {
            var eventToAdd = new Event()
            {
                Id = 5,
                Name = "8 марта",
                Type = "Праздничное",
                Date = new DateTime(2025 / 3 / 8),
                PlaceId = 3
            };
            Model.AddEvent(eventToAdd);
            var events = Model.GetEventsList();
            Assert.That(events, Does.Contain(eventToAdd));
        }

        [Test]
        public void RemoveEventTest()
        {
            var events = Model.GetEventsList();
            var eventToRemove = events.FirstOrDefault(e => e.Id == 3);
            Model.RemoveEvent(eventToRemove.Id);
            events = Model.GetEventsList();

            var event_speakers = Model.GetEventSpeackersList(eventToRemove.Id);
            var event_equipment = Model.GetEventEquipmentList(eventToRemove.Id);

            Assert.That(!events.Contains(eventToRemove)
                && event_speakers.Count==0&&event_equipment.Count==0);
        }

        [Test]
        public void UpdateEventTest()
        {
            var events = Model.GetEventsList();
            var eventToUpdate = new Event()
            {
                Id = 3,
                Name = "Выпускной",
                Type = "Праздничное",
                Date = new DateTime(2025 / 6 / 20),
                PlaceId = 4,
            };
            var old_event = events.FirstOrDefault(e => e.Id == eventToUpdate.Id);
            Model.UpdateEvent(eventToUpdate);
            events.Clear();
            events = Model.GetEventsList();
            Assert.That(events.Contains(eventToUpdate) && !events.Contains(old_event));
        }

        [Test]
        public void SetSpeakerToEventTest()
        {
            int event_id = 2;
            var speaker = new Speaker()
            {
                Id = 3,
                Name = "Я",
                EventId = event_id,
            };

            Model.SetSpeakersToEvent(speaker);
            var speakers = Model.GetEventSpeackersList(event_id);
            Assert.That(speakers, Does.Contain(speaker));
        }

        [Test]
        public void UnsetSpeakerToEventTest()
        {
            int event_id = 2;
            var speaker = new Speaker()
            {
                Id = 1,
                Name = "Тимур",
                EventId = 1,
            };

            Model.UnsetSpeakersToEvent(speaker.Id);
            var speakers = Model.GetEventSpeackersList(event_id);
            Assert.That(speakers, Does.Not.Contain(speaker));
        }

        [Test]
        public void ReservEquipmentToEventTest()
        {
            var equipment = new EquipmentReservation()
            {
                Id = 3,
                EquipmentId = 2,
                EventId = 2
            };
            Model.ReservEquipmentToEvent(equipment);
            
            Assert.That(Model.EquipmentReservations, Does.Contain(equipment));
        }

        [Test]
        public void UnsetEquipmentToEventTest()
        {
            var equipment = new EquipmentReservation()
            {
                Id = 1,
                EquipmentId = 1,
                EventId = 1,
            };
            Model.UnsetEquipmentToEvent(equipment.Id);
            Assert.That(Model.EquipmentReservations, Does.Not.Contain(equipment));
        }

        [Test]
        public void GetEventEquipmentListTest()
        {
            int event_id = 1;
            var equipments=Model.GetEventEquipmentList(event_id);
            Assert.AreEqual(2, equipments.Count);
        }

        [Test]
        public void GetAvailibleEquipmentsListTest()
        {
            var events = Model.GetEventsList();
            var date = events.FirstOrDefault(e => e.Id == 1).Date;
            var availible_equipments = Model.GetEquipmentsList(date);
            Assert.AreEqual(availible_equipments.Count, 1);
        }

        [Test]
        public void UpdateEquipmentsListTest()
        {
            var equipments = new List<Equipment>()
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
                },
                new Equipment()
                {
                    Id=4,
                    Name="Колонка2"
                }
            };

            Model.UpdateEquipmentsList(equipments);
            Assert.That(Model.Equipments.Count==4);
        }

        [Test]
        public void GetEquipmentsListTest()
        {
            var equipments = Model.GetEquipmentsList();
            Assert.That(equipments.Count == 3);
        }

    }
}
