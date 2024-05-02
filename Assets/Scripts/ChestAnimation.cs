using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class ChestAnimation : MonoBehaviour
{
    public GameObject PopUpUI;
    public GameObject PopDownUI;
    public Animator animator;
    bool InTriggerRange = false;
    bool open = false;


    public GameObject instance { get; private set; }


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
                animator.SetTrigger("OpenTrigger");
            }

            else if(open == true)
            {
                HidePopUpUi();
                ShowPopDownUi();   
                if (Input.GetKeyDown(KeyCode.E))
                {
                    open = false;
                    animator.ResetTrigger("OpenTrigger");
                }

            }
            else if(open == false)
            {
                HidePopUpUi();
                ShowPopUpUi();
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
            ShowPopUpUi();
            InTriggerRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            HidePopUpUi();
            InTriggerRange = false;
            open = false;
        }
    }

    public void ShowPopUpUi()
    {
        instance = Instantiate(PopUpUI, transform.position, Quaternion.identity, transform);
    }

    public void ShowPopDownUi()
    {
        instance = Instantiate(PopDownUI, transform.position, Quaternion.identity, transform);
    }

    private void HidePopUpUi()
    {
        Destroy(instance);
    }
}
