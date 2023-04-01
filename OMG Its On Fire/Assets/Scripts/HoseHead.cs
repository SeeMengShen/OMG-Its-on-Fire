using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HoseHead : MonoBehaviour
{
    private bool attachedToHydrant = false;
    private ParticleSystem childPS;
    public ActionBasedController controller;

    // Start is called before the first frame update
    void Start()
    {
        childPS = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void emitWater(bool activate)
    {
        if(activate && attachedToHydrant)
        {
            childPS.Play();
            controller.SendHapticImpulse(1.0f, 0.1f);
        }
        else
        {
            childPS.Stop();
        }
    }

    public void attach(bool attach)
    {
        attachedToHydrant = attach;
    }
}
