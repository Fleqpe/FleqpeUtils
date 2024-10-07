using System;
using System.Globalization;
using System.Threading;
using Cysharp.Threading.Tasks;

public class DailyQuestManager : PersistentSingletonManager<DailyQuestManager>
{
    private CancellationTokenSource cts = new CancellationTokenSource();
    void OnDestroy()
    {
        cts?.Cancel();
        cts?.Dispose();
    }
    private void Start()
    {
        CheckForNewDay();
        PassTime().Forget();
    }
    private void CheckForNewDay()
    {
        DateTime pastTime = DateTime.Parse(SaveManager.gameFiles.time, CultureInfo.InvariantCulture);
        DateTime presentTime = DateTime.UtcNow;
        DateTime todayAtMidnight = new DateTime(presentTime.Year, presentTime.Month, presentTime.Day, 0, 0, 0, DateTimeKind.Utc);
        if (presentTime >= todayAtMidnight && pastTime < todayAtMidnight)
            SaveManager.gameFiles.dailyQuestData.ResetQuests();
    }
    private async UniTaskVoid PassTime()
    {
        while (!cts.Token.IsCancellationRequested)
        {
            await UniTask.WaitForSeconds(1)
            .AttachExternalCancellation(cts.Token);
            SaveManager.gameFiles.dailyQuestData.timeBasedQuests.ForEach(x =>
            {
                x?.PassTime(1);
            });
        }
    }
}
