using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Grabbables : MonoBehaviour
{
    protected Collider thisCollider;
    protected Collider playerCollider;
    protected bool grabbed;
    protected bool isLeft;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        thisCollider = GetComponent<Collider>();
        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>();
    }

    // Update is called once per frame
    protected void Update()
    {
        grabbed = transform.parent == null;
        Physics.IgnoreCollision(thisCollider, playerCollider, grabbed);
    }
}
