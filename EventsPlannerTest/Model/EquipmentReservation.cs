using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsPlannerTest.Model
{
    public class EquipmentReservation
    {
        public int Id { get; set; }
        public int EquipmentId { get; set; }
        public int EventId { get; set; }
        //public virtual Event Event { get; set; }
        //public virtual Equipment Equipment { get; set; }
    }
}
