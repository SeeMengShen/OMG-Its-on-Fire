using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour
{
    private QuestItem questItem;
    public static int insideWardrobeRecipeCount = 0;

    void Start()
    {
        questItem = GetComponent<QuestItem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "MoveRecipeToHere")
        {
            insideWardrobeRecipeCount++;
            questItem.Complete();
            if(insideWardrobeRecipeCount >= 3)
            {
                Destroy(other.gameObject);
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "MoveRecipeToHere")
        {
            insideWardrobeRecipeCount--;
            questItem.Uncomplete();
        }
    }
}
