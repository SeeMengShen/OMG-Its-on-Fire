using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HoseHead : Usable
{
    private bool attachedToHydrant = false;
    private ParticleSystem childPS;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        childPS = GetComponentInChildren<ParticleSystem>();
    }

    protected void Update()
    {
        base.Update();
    }

    public void EmitWater(ActionBasedController controller)
    {
        if (!grabbed)
        {
            return;
        }

        isUsing = !isUsing;

        if (isUsing && attachedToHydrant)
        {
            childPS.Play();
            base.StartCoroutine(ContinuousHapticFeedback(controller, childPS));
        }
    }

    public void Attach(bool attach)
    {
        attachedToHydrant = attach;
    }
}
