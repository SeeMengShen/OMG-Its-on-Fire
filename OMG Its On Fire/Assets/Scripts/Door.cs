using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator animator;
    private const string OPEN_DOOR_STR = "open";
    private bool isOpen;
    private Outline outline;

    // Start is called before the first frame update
    void Start()
    {
        animator = transform.parent.GetComponent<Animator>();
        isOpen = animator.GetBool(OPEN_DOOR_STR);
        outline = GetComponent<Outline>();
        outline.eraseRenderer = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void openDoor()
    {
        isOpen = !isOpen;
        animator.SetBool(OPEN_DOOR_STR, isOpen);
    }

    public void highlight()
    {
        Debug.Log(1);
        outline.eraseRenderer = false;
    }

    public void quitHighlight()
    {
        Debug.Log(0);
        outline.eraseRenderer = true;
    }
}
