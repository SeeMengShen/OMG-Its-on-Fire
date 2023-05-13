using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExhasutDestroy : MonoBehaviour
{
    public Fire fire;
    public GameObject emitHead;

    // Update is called once per frame
    void Update()
    {
        if(fire == null)
        {
            Destroy(emitHead);
            Destroy(gameObject);
        }
    }
}
