using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Door : MonoBehaviour
{
    private Animator animator;
    private const string OPEN_DOOR_STR = "open";
    private const string DESTROYED_STR = "destroyed";
    private const string AXE_STR = "Axe";    
    private bool isOpen;
    private AudioSource audioSource;
    public bool locked;
    public AudioClip destroySound;

    // Start is called before the first frame update
    void Start()
    {
        animator = transform.parent.GetComponent<Animator>();
        isOpen = animator.GetBool(OPEN_DOOR_STR);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenDoor()
    {
        if(locked)
        {
            return;
        }

        if (!audioSource.isPlaying)
        {
            audioSource.Play();
            isOpen = !isOpen;
            animator.SetBool(OPEN_DOOR_STR, isOpen);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(AXE_STR))
        {
            QuestItem questItem = GetComponent<QuestItem>();
           if(questItem != null)
            {
                questItem.Complete();
            }

            GetComponent<Rigidbody>().isKinematic = false;
            audioSource.clip = destroySound;
            audioSource.Play();
            animator.SetBool(DESTROYED_STR, true);
            Destroy(this);
        }
    }
}
