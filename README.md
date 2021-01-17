# Intro

The following is a popular Udemy course on Node.js:

[The Complete Node.js Developer Course (3rd Edition)](https://www.udemy.com/course/the-complete-nodejs-developer-course-2/)

One of the projects in the course is a chat app. This repository contains that chat app converted to [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor).

# What does the chat app look like?

<img src="https://i.imgur.com/Nq3xw8c.png" width="500">

# Key files in implementation

## Shared

- [Shared/Message.cs](https://github.com/dharmatech/MeadChatAppBlazor/blob/master/MeadChatAppBlazor/Shared/Message.cs)
- [Shared/RoomData.cs](https://github.com/dharmatech/MeadChatAppBlazor/blob/master/MeadChatAppBlazor/Shared/RoomData.cs)
- [Shared/User.cs](https://github.com/dharmatech/MeadChatAppBlazor/blob/master/MeadChatAppBlazor/Shared/User.cs)

## Client

- [Client/Pages/Chat.razor](https://github.com/dharmatech/MeadChatAppBlazor/blob/master/MeadChatAppBlazor/Client/Pages/Chat.razor)
- [Client/Pages/Chat.razor.cs](https://github.com/dharmatech/MeadChatAppBlazor/blob/master/MeadChatAppBlazor/Client/Pages/Chat.razor.cs)
- [Client/Pages/Index.razor](https://github.com/dharmatech/MeadChatAppBlazor/blob/master/MeadChatAppBlazor/Client/Pages/Index.razor)
- [Client/wwwroot/index.html](https://github.com/dharmatech/MeadChatAppBlazor/blob/master/MeadChatAppBlazor/Client/wwwroot/index.html#L15-L23) - Mainly the javascript function inside the script tag. Used for the geolocation.

## Server

- [Server/Hubs/ChatHub.cs](https://github.com/dharmatech/MeadChatAppBlazor/blob/master/MeadChatAppBlazor/Server/Hubs/ChatHub.cs)

# References

- [Microsoft Blazor](https://www.apress.com/us/book/9781484259276) (Apress 2020) by Peter Himschoot.
