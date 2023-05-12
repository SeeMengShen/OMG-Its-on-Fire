using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victim : QuestItem
{
    private bool rescued;
    // Start is called before the first frame update
    void Start()
    {
        rescued = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Complete()
    {
        if (!rescued)
        {
            base.Complete();
            rescued = true;
            GetComponent<Animator>().SetBool("rescued", rescued);
            StartCoroutine(DelayDestroy());
        }

    }

    IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);
    }
}
