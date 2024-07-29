using Leopotam.Ecs;
using System.Threading.Tasks;
using UnityEngine;

public class TimerSystem : IEcsInitSystem
{
    private readonly EcsFilter<TimerComponent> _timerFilter;
    private readonly EcsFilter<WinComponent> _winFilter;

    public void Init() => AddSecond();

    private async void AddSecond()
    {
        await Task.Delay(1000);

        if (_winFilter.GetEntitiesCount() > 0) return;

        foreach (var i in _timerFilter)
        {
            var component = _timerFilter.Get1(i);
            var textComponent = component.Text;
            var timeText = textComponent.text;

            var timeParts = timeText.Split(':');

            if (timeParts.Length == 2 && int.TryParse(timeParts[0], out int minutes) && int.TryParse(timeParts[1], out int seconds))
            {
                seconds++;
                if (seconds >= 60)
                {
                    seconds = 0;
                    minutes++;
                }
                textComponent.text = $"{minutes:D2}:{seconds:D2}";
            }
            else
            {
                Debug.LogError($"Неверный формат времени: {timeText}");
            }
        }

        AddSecond();
    }
}