# Описание
Телеграмм бот на C#

# Стек технологий
.NET / C#

ASP.NET Core Web API

MSSQL

ADO.NET

JSON / HttpClient

Telegam.Bot

# Структура
```
NevenBot/
  ├── API               # ASP.NET Core API (контроллеры, репозитории, логика)
  ├── Classes           # Модели данных (DTO, Entity и т.д.)
  ├── Handlers          # Обработчики callback
  ├── Keyboards         # Inline кнопки
  ├── Utils             # Вспомогательные классы
  ├── Host.cs           # Инициализация бота
  ├── Program.cs        # Точка входа
  ├── bin/
      ├── Debug/
          ├── net 8.0/
              ├── appsettings.json # Это файл конфигурации, его нужно создать по этому пути (Если нету этого пути, то его надо тоже создать)
├── README.md           # Это описание проекта
├── .gitignore          # gitingore
├── NevenBot.sln        # Солюшин файл
```

# Функционал
Учет трат, создание напомнинаний и задач

# Запуск
Клонировать репозиторий:
```
Через exe в релизе (Скоро)
```
Обновить строки подключения в appsettings.json

```
{
 "ApiToken": Токен телеграмм,
 "DebugID" : ID клиента Телеграм, куда будут отправлятся дебаг сообщения при ошибках
}
```
Запустить через exe


Автор: [tseneven](https://github.com/tseneven)
