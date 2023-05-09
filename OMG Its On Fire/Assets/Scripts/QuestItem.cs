using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour
{
    public Quest quest;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Complete()
    {
        //quest.questItems.Remove(gameObject);
        quest.currentProgress++;
        QuestManager.Instance.LoadQuest();
    }
}
