using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(AudioSource))]
public class Axe : Grabbables
{
    private Animator animator;
    private const string SWING_STR = "swing";
    private AudioSource audioSource;
    private Rigidbody rb;
    private XRGrabInteractable xrGI;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        animator = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        xrGI = GetComponent<XRGrabInteractable>();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    public void Swing()
    {
        if(!grabbed)
        {
            return;
        }

        if (!audioSource.isPlaying)
        {
            rb.isKinematic = false;
            xrGI.trackRotation = false;
            audioSource.Play();
            animator.SetBool(SWING_STR, true);
            StartCoroutine(ResetBool());
        }
    }

    IEnumerator ResetBool()
    {
        yield return new WaitForSeconds(0.1f);
        rb.isKinematic = true;
        yield return new WaitForSeconds(0.9f);
        animator.SetBool(SWING_STR, false);
        xrGI.trackRotation = true;
    }
}
