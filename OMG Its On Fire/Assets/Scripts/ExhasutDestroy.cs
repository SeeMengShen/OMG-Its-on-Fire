using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExhasutDestroy : MonoBehaviour
{
    public Fire fire;
    public GameObject emitHead;

    // Start is called before the first frame update
    void Start()
    {
        
    }

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
