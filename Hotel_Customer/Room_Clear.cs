using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Customer
{
    public class Room_Clear
    {
        public int Id { get; set; }

        public int RoomId { get; set; }

        public int ClearId { get; set; }

        public int Count { get; set; }

        public virtual Room Room { get; set; }

        public virtual Clear Clear { get; set; }
    }
}
