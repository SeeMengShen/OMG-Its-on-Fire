using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllowEntry : MonoBehaviour
{
    public Fire[] transforms;
    public int questItemsCount;
    public CanvasGroup canvas;

    // Start is called before the first frame update
    void Start()
    {
        transforms = GetComponentsInChildren<Fire>();
        //Transform[] transforms = GetComponentsInChildren<Transform>();

        questItemsCount = transforms.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckQeustItemsCount()
    {
        if (questItemsCount <= 0)
        {
            CanvasGroup cg = canvas.GetComponent<CanvasGroup>();
            cg.alpha = 1;
            cg.interactable = true;
            cg.blocksRaycasts = true;
        }
    }
}
