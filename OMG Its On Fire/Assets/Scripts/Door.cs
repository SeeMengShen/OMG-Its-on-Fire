using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Door : MonoBehaviour
{
    private Animator animator;
    private const string OPEN_DOOR_STR = "open";
    private bool isOpen;
    private Outline outline;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        animator = transform.parent.GetComponent<Animator>();
        isOpen = animator.GetBool(OPEN_DOOR_STR);
        outline = GetComponent<Outline>();
        outline.eraseRenderer = true;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void openDoor()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
            isOpen = !isOpen;
            animator.SetBool(OPEN_DOOR_STR, isOpen);
        }
    }
}
