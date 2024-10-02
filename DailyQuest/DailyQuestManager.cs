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
        await UniTask.WaitForSeconds(1)
        .AttachExternalCancellation(cts.Token);
        SaveManager.gameFiles.dailyQuestData.timeBasedQuests.ForEach(x =>
        {
            if (x == null)
                return;
            else
            {
                x.PassTime(1);
                ClaimTimeBasedQuestReward(x);
            }
        });
        PassTime().Forget();
    }
    private void ClaimTimeBasedQuestReward(QuestData questData)
    {
        TimeBasedQuestEntry timeBasedQuestEntry = QuestDatabase.Instance.GetTimeBasedQuestEntry(questData.ID);
        if (questData.isCompleted && timeBasedQuestEntry != null)
            SaveManager.gameFiles.currencyData.EarnPremiumMoney(timeBasedQuestEntry.reward);
        else
            return;
    }
}
