using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public string questName;
    [TextArea] public string questDesc;
    public List<GameObject> questItems;
    public int currentProgress = 0;
}
