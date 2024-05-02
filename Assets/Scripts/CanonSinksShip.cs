using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.InputSystem;

public class CanonSinksShip : MonoBehaviour
{
    public GameObject PopUpUI;

    public GameObject instance { get; private set; }

    public Animator cannon_animator;
    public Animator ship_animator;
    public Animator pineapple_animator;

    private AudioSource cannon;
    
    bool InTriggerRange = false;
    bool shot = false;
    bool fired = false;
    bool sinking = false;
    System.Timers.Timer aTimer = new System.Timers.Timer();
    // Start is called before the first frame update
    void Start()
    {
        cannon = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (InTriggerRange == true)
        {
            if (Input.GetKeyDown(KeyCode.E) && shot == false)
            {
                shot = true;
                cannon_animator.SetTrigger("Shoot");
                
                aTimer.Elapsed += new ElapsedEventHandler(ShootEvent);
                aTimer.Interval = 1000; // ~ 5 seconds
                aTimer.Enabled = true;
                cannon.Play();


            }

            if(fired == true) 
            {
                
                pineapple_animator.SetTrigger("Firing");
                HidePopUpUi();
            }

            if(sinking == true) 
            {
                ship_animator.SetTrigger("Sinking");
            }
        }
        if(InTriggerRange == false) 
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
            InTriggerRange = false;
            HidePopUpUi() ; 
        }
    }

    void ShootEvent(object source, ElapsedEventArgs e)
    {
        fired = true;
        aTimer.Elapsed += new ElapsedEventHandler(SinkEvent);
        aTimer.Interval = 1000; // ~ 5 seconds
        aTimer.Enabled = true;
    }

    void SinkEvent(object source, ElapsedEventArgs e)
    {
        sinking = true;
    }

    public void ShowPopUpUi()
    {
        instance = Instantiate(PopUpUI, transform.position, Quaternion.Euler(0, -180, 0), transform);
    }

    public void HidePopUpUi()
    {
        Destroy(instance);
    }
}
