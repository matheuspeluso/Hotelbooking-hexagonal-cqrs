using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Room
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public bool InMaintenance { get; set; }
        public bool IsAvailable 
        {
            get
            {
                if(this.InMaintenance == true || this.HasGuest == true)
                {
                    return false;
                }
                    return true;
                
            }
        }
        public bool HasGuest 
        {
            //verificar se existe bookings abertos para essa room
            get { return true; }
        }
    }
}
