using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using MeadChatAppBlazor.Shared;

namespace MeadChatAppBlazor.Server.Hubs
{
    public class ChatHub : Hub
    {
        public static List<User> Users { get; set; } = new List<User>();

        public async Task Join(string user_name, string room)
        {
            if (user_name == null)
                throw new Exception("user_name must not be blank");

            if (room == null)
                throw new Exception("room must not be blank");

            Users.Add(new User() 
            {
                Id = Context.ConnectionId,
                Name = user_name,
                Room = room
            });

            await Groups.AddToGroupAsync(Context.ConnectionId, room);

            await Clients.Caller.SendAsync("Message", Message.Generate("Admin", "Welcome!"));

            await Clients.OthersInGroup(room).SendAsync("Message", Message.Generate("Admin", $"{user_name} has joined"));

            await Clients.Group(room).SendAsync("RoomData",
                new RoomData()
                {
                    Room = room,
                    Users = Users.Where(elt => elt.Room == room)
                });
        }

        //public async Task SendMessage(string user, string message)
        //{
        //    await Clients.All.SendAsync("ReceiveMessage", user, message);
        //}

        //public async Task SendMessage(string message)
        //{
        //    await Clients.All.SendAsync("ReceiveMessage", message);
        //}

        public async Task SendMessage(string message)
        {
            System.Console.WriteLine(Context.ConnectionId);

            var user = Users.First(user => user.Id == Context.ConnectionId);

            await Clients.Group(user.Room).SendAsync("Message", Message.Generate(user.Name, message));
        }

        public async Task SendLocation(double latitude, double longitude)
        {
            var user = Users.First(user => user.Id == Context.ConnectionId);

            var url = $"http://google.com/maps?q={latitude},{longitude}";

            var message = Message.Generate(user.Name, url);

            message.Location = true;

            await Clients.Group(user.Room).SendAsync("LocationMessage", message);
        }
    }
}