using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceNewFireExtinguisher : QuestItem
{
    private const string NEW_FE_STR = "NewFireExtinguisher";

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == NEW_FE_STR)
        {
            Complete();
        }
    }
}
