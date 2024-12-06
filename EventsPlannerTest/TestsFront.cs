using EventsPlannerTest.Model;
namespace EventsPlannerTest
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
            });
        }

        [Test]
        public void GetFullEventsListTest()
        {
            List<Event> events = Model.GetEventsList();
            Assert.That(events.Count, Is.EqualTo(4));
        }

        [Test]
        public void GetFiltredByDateEventsListTest()
        {
            List<Event> events = Model.GetFiltredByDateEvents(new DateTime(2025/2/23));
            Assert.That(events.Count, Is.EqualTo(1));
        }

        [Test]
        public void GetFiltredByTypeEventsListTest()
        {
            List<Event> events = Model.GetFiltredByTypeEvents("Праздничное");
            Assert.That(events.Count, Is.EqualTo(2));
        }

        [Test]
        public void GetFiltredByBothEventsListTest()
        {
            List<Event> events = Model.GetFiltredByTypeEvents("Праздничное");
            List<Event> events1 = Model.GetFiltredByDateEvents(new DateTime(2025 / 2 / 23), events);
            Assert.That(events1.Count, Is.EqualTo(1));
        }
    }
}