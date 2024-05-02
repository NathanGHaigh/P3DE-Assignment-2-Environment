using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PineAppleInteraction : MonoBehaviour
{
    public GameObject PopUpUI;
    public GameObject Pineapple;
    bool InTriggerRange = false;
    bool picked = false;
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

            if (Input.GetKeyDown(KeyCode.E) && picked == false)
            {
                picked = true;
                Pineapple.SetActive(false);
            }

            else if (picked == true)
            {
                HidePopUpUi();
            }
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
        instance = Instantiate(PopUpUI, new Vector3(Pineapple.transform.position.x, Pineapple.transform.position.y + 1, Pineapple.transform.position.z), Quaternion.Euler(0, 30, 0));
    }

    private void HidePopUpUi()
    {
        Destroy(instance);
    }
}
