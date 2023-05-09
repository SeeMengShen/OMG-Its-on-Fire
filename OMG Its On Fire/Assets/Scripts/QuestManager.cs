using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;
    public Quest[] questList;
    private int currentQIndex = 0;
    public Quest currentQuest;

    public TextMeshProUGUI questTitle;
    public TextMeshProUGUI questDescription;
    public TextMeshProUGUI questProgress;
    public TextMeshProUGUI questStatus;

    private const string SLASH_STR = "/";
    private const string COMPLETE_STR = "Complete";
    private const string IN_PROGRESS_STR = "In Progress";

    private WaitForSeconds wait = new WaitForSeconds(3f);

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentQuest = questList[currentQIndex];
        LoadQuest();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetQuest(Quest newQuest)
    {
        currentQuest = newQuest;
        LoadQuest();
    }

    public void LoadQuest()
    {
        UpdateQuestProgress();

        questTitle.text = currentQuest.questName;
        questDescription.text = currentQuest.questDesc;
    }

    public void UpdateQuestProgress()
    {
        questProgress.text = currentQuest.currentProgress + SLASH_STR + currentQuest.questItems.Count;

        if (currentQuest.currentProgress == currentQuest.questItems.Count)
        {
            questStatus.text = COMPLETE_STR;
            ChangeTextColor(Color.green);
            currentQIndex++;
            Instance.StartCoroutine(DelaySwitchQuest());
        }
        else
        {
            questStatus.text = IN_PROGRESS_STR;
        }
    }

    IEnumerator DelaySwitchQuest()
    {
        yield return wait;
        ChangeTextColor(Color.white);
        SetQuest(questList[currentQIndex]);
    }

    private void ChangeTextColor(Color color)
    {
        questTitle.color = color;
        questDescription.color = color;
        questProgress.color = color;
        questStatus.color = color;
    }
}
