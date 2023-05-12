using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlugManager : MonoBehaviour
{
    public Quest quest;
    public static PlugManager Instance = null;
    public int plugOnExtentionCount = 3;
    public GameObject[] extensionCord;
    private XRSocketInteractor[] xrSocket;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {

        xrSocket = new XRSocketInteractor[3];
        for (int i = 0; i < extensionCord.Length; i++)
        {
            GameObject gameObject = extensionCord[i];
            xrSocket[i] = gameObject.GetComponent<XRSocketInteractor>();
        }



        plugOnExtentionCount = 0;
        foreach (var socket in xrSocket)
        {
            if (socket.hasSelection)
            {
                plugOnExtentionCount++;
            }
        }
    }


    public void PlugOrUnplug()
    {
        plugOnExtentionCount = 0;
        foreach (var socket in xrSocket)
        {
            if (socket.hasSelection)
            {
                plugOnExtentionCount++;
            }
        }

        if (QuestManager.Instance.currentQuest == quest)
        {
            QuestManager.Instance.currentQuest.currentProgress = 3 - plugOnExtentionCount;
            QuestManager.Instance.LoadQuest();
            if(QuestManager.Instance.currentQuest.currentProgress == 3)
            {
                print(true);
                Destroy(gameObject);
            }
        }
    }











}
