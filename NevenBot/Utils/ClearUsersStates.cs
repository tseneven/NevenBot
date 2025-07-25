using NevenBot.Handlers;

namespace NevenBot.Utils
{
    internal class ClearUsersStates
    {
        private Timer? _timer;

        public void Start()
        {
            Logger.TimerStart();
            _timer = new Timer(
                callback: ClearUserStates,
                state: null,
                dueTime: 0,         // запуск сразу
                period: 60000       // повтор каждые 60 сек
            );
        }

        private void ClearUserStates(object? state)
        {
            Logger.TimerEnd();
            MessageHandler.UserStates.Clear();
        }
    }
}
