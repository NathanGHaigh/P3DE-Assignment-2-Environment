using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class JobCheck : MonoBehaviour
{
    public GameObject PopUpUI;
    public GameObject Bartender;
    bool InTriggerRange = false;

    public GameObject instance { get; private set; }

    public bool canDrink = false;
    public GameObject drinkingCollider;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] pineapples = GameObject.FindGameObjectsWithTag("Pineapple");
        bool finished = pineapples.All(p => p.activeInHierarchy == false);
        if (finished) 
        {
            canDrink = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ShowPopUpUi();
            InTriggerRange = true;
        }

        if (InTriggerRange == true)
        {
            ShowPopUpUi();
        }
        else if (InTriggerRange == false)
        {
            HidePopUpUi();
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
        instance = Instantiate(PopUpUI, new Vector3(Bartender.transform.position.x, Bartender.transform.position.y + 2, Bartender.transform.position.z), Quaternion.Euler(0, -90, 0));
    }

    private void HidePopUpUi()
    {
        Destroy(instance);
    }



}
