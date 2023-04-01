using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Outline))]
public class Interactables : MonoBehaviour
{
    private Outline outline;
    // Start is called before the first frame update
    void Start()
    {
        outline = GetComponent<Outline>();
        outline.eraseRenderer = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void highlight()
    {
        outline.eraseRenderer = false;
    }

    public void quitHighlight()
    {
        outline.eraseRenderer = true;
    }
}
