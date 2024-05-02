using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIPopUp : MonoBehaviour
{
    public GameObject PopUpUI;
    bool InTriggerRange = false;

    public GameObject instance { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (InTriggerRange == true)
        {
            ShowPopUpUi();
        }
        else if (InTriggerRange == false)
        {
            HidePopUpUi(); 
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
        }
    }

    public void ShowPopUpUi()
    {
        instance = Instantiate(PopUpUI, transform.position, Quaternion.Euler(0,90,0), transform) ;
    }

    private void HidePopUpUi()
    {
        Destroy(instance);
    }
}
