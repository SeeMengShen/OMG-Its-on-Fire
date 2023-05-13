using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Usable : Grabbables
{
    protected bool isUsing = false;
    private WaitForSeconds wait = new WaitForSeconds(0.1f);
    public AudioSource audioSource;

    protected IEnumerator ContinuousHapticFeedback(ActionBasedController controller, ParticleSystem ps)
    {
        while (isUsing && grabbed && controller.GetComponentInChildren<XRDirectInteractor>().hasSelection)
        {
            if(!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            
            controller.SendHapticImpulse(1.0f, 0.1f);
            yield return wait;
        }

        audioSource.Stop();
        ps.Stop();
        isUsing = false;
        yield break;
    }
}