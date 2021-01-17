using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeadChatAppBlazor.Shared
{
    public class RoomData
    {
        public string Room { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}
