using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.JSInterop;
using MeadChatAppBlazor.Shared;
using Microsoft.AspNetCore.Components;

namespace MeadChatAppBlazor.Client.Pages
{
    public partial class Chat
    {
        [Inject]
        IJSRuntime JSRuntime { get; set; }

        private HubConnection hub_connection;

        private List<Message> messages = new List<Message>();

        private RoomData room_data = null;
        
        private string message_input;

        Task SendMessage() => hub_connection.SendAsync("SendMessage", message_input);

        private async void SendLocation()
        {
            var obj_ref = DotNetObjectReference.Create(this);

            await JSRuntime.InvokeVoidAsync("blazor_send_location", obj_ref);
        }

        [JSInvokable]
        public async Task SendLocationAux(double latitude, double longitude)
        {
            hub_connection.SendAsync("SendLocation", latitude, longitude);
        }

        protected override async Task OnInitializedAsync()
        {
            hub_connection = new HubConnectionBuilder()
                .WithUrl(NavigationManager.ToAbsoluteUri("/chathub"))
                .Build();

            hub_connection.On<RoomData>("RoomData", room_data =>
            {
                this.room_data = room_data;

                StateHasChanged();
            });

            hub_connection.On<Message>("Message", message =>
            {
                messages.Add(message);

                StateHasChanged();
            });

            hub_connection.On<Message>("LocationMessage", message =>
            {
                messages.Add(message);

                StateHasChanged();
            });

            await hub_connection.StartAsync();
         
            {
                var username = "";
        
                var room = "";

                var query = new Uri(NavigationManager.Uri).Query;

                if (QueryHelpers.ParseQuery(query).TryGetValue("username", out var username_out))
                    username = username_out;

                if (QueryHelpers.ParseQuery(query).TryGetValue("room", out var room_out))
                    room = room_out;

                await hub_connection.SendAsync("Join", username, room);
            }
        }
    }
}
