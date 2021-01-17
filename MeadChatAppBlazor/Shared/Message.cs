using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeadChatAppBlazor.Shared
{
    public class Message
    {
        public string User { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }

        public bool Location { get; set; } = false;

        public static Message Generate(string name, string text) =>
            new Message()
            {
                User = name,
                Text = text,
                CreatedAt = DateTime.Now
            };

    }
}
