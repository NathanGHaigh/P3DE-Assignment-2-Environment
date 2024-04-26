using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestAnimation : MonoBehaviour
{

    public Animator animator;
    bool InTriggerRange = false;
    bool open = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(InTriggerRange == true)
        {
            if (Input.GetKeyDown(KeyCode.E) && open == false)
            {
                open = true;
                print("Hello");
                animator.SetTrigger("OpenTrigger");
            }

            else if(open == true)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    open = false;
                    print("Closing");
                    animator.ResetTrigger("OpenTrigger");
                }
            }
        }
        else if(InTriggerRange == false)
        {
            animator.ResetTrigger("OpenTrigger");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            print("Inside");
            InTriggerRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {

            print("Outsidee");
            InTriggerRange = false;
        }
    }
}
