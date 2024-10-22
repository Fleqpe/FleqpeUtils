using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class DailyQuestData
{
    public List<QuestData> quests = new List<QuestData>();
    public List<TimeBasedQuestData> timeBasedQuests = new List<TimeBasedQuestData>();
    public List<CountBasedQuestData> countBasedQuests = new List<CountBasedQuestData>();
    public void ResetQuests()
    {
        quests.Clear();
    }
}
[System.Serializable]
public abstract class QuestData
{
    public int ID;
    public bool isCompleted;
}
[System.Serializable]
public class TimeBasedQuestData : QuestData
{
    public int timeSpent;
    public void PassTime(int seconds)
    {
        if (isCompleted)
        {
            return;
        }
        else
        {
            if (timeSpent >= QuestDatabase.Instance.GetTimeBasedQuestEntry(ID).requiredTime)
                isCompleted = true;
            else
                timeSpent += seconds;
        }
    }
    public void ClaimTimeBasedQuestReward()
    {
        TimeBasedQuestEntry timeBasedQuestEntry = QuestDatabase.Instance.GetTimeBasedQuestEntry(ID);
        if (isCompleted && timeBasedQuestEntry != null)
        {
            SaveManager.gameFiles.playerData.currencyData.EarnPremiumMoney(timeBasedQuestEntry.reward);
            SaveManager.gameFiles.dailyQuestData.timeBasedQuests.Remove(this);
        }
        else
            return;
    }
}
[System.Serializable]
public class CountBasedQuestData : QuestData
{
    public int current;
    public void AddProgress(int progress, int required)
    {
        if (isCompleted)
        {
            return;
        }
        else
        {
            if (current >= required)
                isCompleted = true;
            else
                current += progress;
        }
    }
}