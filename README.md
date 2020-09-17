# EnglishHelper [Telegram Bot]

The main idea of this project is to implement a web functionality wich serve as the valuble help for studing English language with telegram bot help.
For using the current bot you should [follow this link](https://t.me/instance1_bot)

# Getting Started

When you start interacting with the Telegram Bot, the user can use the "/start" command, after which it is enough to follow the instructions and use the bot that performs certain commands and tasks.

# Application settings
For the correct functioning of Telegram Bot, it is necessary to update the appsettnigs.json file in the root directory of the web project, filled in according to the template below.

```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "Url": "https://your-url-app.herokuapp.com",
  "Token": "your-telegram-token"
}
```

# Build with

* [Docker](https://www.docker.com/)
* [ASP.NET Core 3.1](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-3.1)
* [Telegram Bot](https://www.nuget.org/packages/Telegram.Bot/)
* [Flurl.HTTP](https://www.nuget.org/packages/Flurl.Http/3.0.0-pre3)

# Author
[Maksim Straltsou](https://github.com/green1971weekend)

# License
This project is licensed under the MIT License - see the [LICENSE.md](https://github.com/green1971weekend/TelegramBot/blob/master/LICENSE) file for details.


