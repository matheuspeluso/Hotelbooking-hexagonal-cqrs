using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Action = Domain.Enums.Action;

namespace Domain.Entities
{
    public class Booking
    {

        public Booking()
        {
            this.id = Guid.NewGuid();
            this.Status = Status.Created;
        }

        public Guid id { get; set; }
        public DateTime PlaceAdt { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Guid RoomId { get; set; }
        public Room? Room { get; set; }
        public Guest? Guest { get; set; }
        public Guid GuestId { get; set; }
        private Status Status { get; set; }

        public Status CurrentStatus 
        { 
            get
            {
                return this.Status;
            }
        }
        public void ChangeState(Action action) 
        {
            this.Status = (this.Status, action) switch
            {
                (Status.Created,      Action.Pay)      => Status.Paid,
                (Status.Created,      Action.Cancel)   => Status.Cancelled,
                (Status.Paid,         Action.Finish)   => Status.Finished,
                (Status.Paid,         Action.Refound)  => Status.Refounded,
                (Status.Cancelled,    Action.Reopen)   => Status.Created,
                _ => this.Status
            };
        }
    }
}
