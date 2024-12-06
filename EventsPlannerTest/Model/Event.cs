using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsPlannerTest.Model
{
    public class Event
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public DateTime Date { get; set; }

        public int PlaceId { get; set; }

        //public virtual Place Place { get; set; }

        //public virtual ICollection<Speaker> Speakers { get; set; }
        //public virtual ICollection<Equipment> EquipmentCollection { get;set; }
    }
}
