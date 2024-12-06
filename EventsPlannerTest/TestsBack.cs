using EventsPlannerTest.Model;

namespace EventsPlannerTest
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
                    Name="Тимур",
                    EventId=1,
                },

                new Speaker() 
                {
                    Id=2,
                    Name="Олег",
                    EventId=3,
                },
            },
            new List<Equipment>()
            {
                new Equipment()
                {
                    Id=1,
                    Name="Микрофон",
                    EventId=1,
                },
                new Equipment()
                {
                    Id=2,
                    Name="Колонка",
                    EventId=1,
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
            var events=Model.GetEventsList();
            Assert.That(events.Contains(eventToAdd));
        }

        [Test]
        public void RemoveEventTest()
        {
            var eventToRemove = new Event()
            {
                Id = 3,
                Name = "Выпускной",
                Type = "Праздничное",
                Date = new DateTime(2025 / 6 / 20),
                PlaceId = 3,
            };
            Model.RemoveEvent(eventToRemove);
            var events = Model.GetEventsList();
            Assert.That(!events.Contains(eventToRemove));
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
            var old_event=events.FirstOrDefault(e=>e.Id==eventToUpdate.Id);
            Model.UpdateEvent(eventToUpdate);
            events.Clear();
            events = Model.GetEventsList();
            Assert.That(events.Contains(eventToUpdate)&&!events.Contains(old_event));
        }

        [Test]
        public void SetSpeakerToEventTest()
        {
            int event_id = 2;
            var speaker = new Speaker()
            {
                Id=3,
                Name="Я",
                EventId=event_id,
            };

            Model.SetSpeakersToEvent(speaker);
            var speakers = Model.GetEventSpeackersList(event_id);
            Assert.That(speakers.Contains(speaker));
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

            Model.UnsetSpeakersToEvent(speaker);
            var speakers = Model.GetEventSpeackersList(event_id);
            Assert.That(!speakers.Contains(speaker));
        }

        [Test]
        public void ReservEquipmentToEventTest()
        {
            int event_id = 2;
            var equipment = new Equipment()
            {
                Id = 3,
                Name = "Еще колонка",
                EventId = event_id
            };
            Model.ReservEquipmentToEvent(equipment);
            var equipments=Model.GetEventEquipmentList(event_id);
            Assert.That(equipments.Contains(equipment));
        }

        [Test]
        public void UnsetEquipmentToEventTest()
        {
            int event_id = 2;
            var equipment = new Equipment()
            {
                Id = 3,
                Name = "Еще колонка",
                EventId = event_id
            };
            Model.UnsetEquipmentToEvent(equipment);
            var equipments = Model.GetEventEquipmentList(event_id);
            Assert.That(!equipments.Contains(equipment));
        }
    }
}
