using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireExtinguisher : Usable
{
    public ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    public void togglePressed(ActionBasedController controller)
    {
        if(!grabbed)
        {
            return;
        }

        isUsing = !isUsing;

        if (isUsing)
        {
            ps.Play();
            base.StartCoroutine(ContinuousHapticFeedback(controller, ps));
        }
    }
}
