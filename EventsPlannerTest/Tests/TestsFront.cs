using EventsPlannerTest.Controllers;
using EventsPlannerTest.Model;
namespace EventsPlannerTest.Tests
{
    public class TestsFront
    {
        FrontController Model;

        [SetUp]
        public void Setup()
        {
            Model = new FrontController(new List<Event>()
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
            });
        }

        [Test]
        public void GetFullEventsListTest()
        {
            List<Event> events = Model.GetEventsList();
            Assert.That(events, Has.Count.EqualTo(4));
        }

        [Test]
        public void GetFiltredByDateEventsListTest()
        {
            List<Event> events = Model.GetEventsList(null,new DateTime(2025 / 2 / 23));
            Assert.That(events, Has.Count.EqualTo(1));
        }

        [Test]
        public void GetFiltredByTypeEventsListTest()
        {
            List<Event> events = Model.GetEventsList("Праздничное");
            Assert.That(events, Has.Count.EqualTo(2));
        }

        [Test]
        public void GetFiltredByBothEventsListTest()
        {
            List<Event> events = Model.GetEventsList("Праздничное", new DateTime(2025 / 2 / 23));
            Assert.That(events, Has.Count.EqualTo(1));
        }

        [Test]
        public void RegisterToEventTest()
        {
            Speaker speaker = new Speaker()
            {
                Id = 3,
                UserId = 1,
                Name = "Глубокослав",
                EventId = 3,
            };

            Model.RegisterToEvent(speaker);
            Assert.That(Model.Speakers, Does.Contain(speaker));
        }
    }
}