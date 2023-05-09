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

/*    IEnumerator continuousHapticFeedback(ActionBasedController controller)
    {
        while(isUsing)
        {
            controller.SendHapticImpulse(1.0f, 0.1f);
            yield return new WaitForSeconds(0.1f);
        }
        ps.Stop();
        yield break;
    }*/
}
