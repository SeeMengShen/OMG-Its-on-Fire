using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour
{
    public Quest quest;

    public virtual void Complete()
    {
        //quest.questItems.Remove(gameObject);
        quest.currentProgress++;
        QuestManager.Instance.LoadQuest();
    }

    public virtual void Uncomplete()
    {
        quest.currentProgress--;
        QuestManager.Instance.LoadQuest();
    }
}
