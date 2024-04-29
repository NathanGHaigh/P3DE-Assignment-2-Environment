using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{

    public Animator animator;
    bool InTriggerRange = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (InTriggerRange == true)
        {
            animator.SetTrigger("DoorOpening");
        }

        else if (InTriggerRange == false)
        {
            animator.ResetTrigger("DoorOpening");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            InTriggerRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            InTriggerRange = false;
        }
    }
}
