
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Sirenix.OdinInspector;
[CreateAssetMenu(fileName = "QuestDatabase", menuName = "ScriptableObjects/Database/Quest Database")]
public class QuestDatabase : SingletonSO<QuestDatabase>
{
    [TableList][SerializeField] private List<QuestEntry> quests = new List<QuestEntry>();
    [TableList][SerializeField] private List<TimeBasedQuestEntry> timeBasedQuests = new List<TimeBasedQuestEntry>();
    [TableList][SerializeField] private List<CountBasedQuestEntry> countBasedQuests = new List<CountBasedQuestEntry>();
    public QuestEntry GetQuestEntry(int ID)
    {
        return quests.FirstOrDefault(x => x.ID == ID);
    }
    public TimeBasedQuestEntry GetTimeBasedQuestEntry(int ID)
    {
        return timeBasedQuests.FirstOrDefault(x => x.ID == ID);
    }
    public CountBasedQuestEntry GetCountBasedQuestEntry(int ID)
    {
        return countBasedQuests.FirstOrDefault(x => x.ID == ID);
    }
}
