using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victim : QuestItem
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Complete()
    {
        base.Complete();
        GetComponent<Animator>().SetBool("rescued", true);
        StartCoroutine(DelayDestroy());
    }

    IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);
    }
}
