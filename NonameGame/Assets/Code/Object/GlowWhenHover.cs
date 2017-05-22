﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GlowWhenHover : MonoBehaviour {


    public GameObject ObjectToGlow;

    private GameObject CodeController;
    // Use this for initialization
    Behaviour Halo;

    void Start () {
        CodeController = GameObject.FindGameObjectWithTag("SceneCode");
        Halo = (Behaviour)ObjectToGlow.GetComponent("Halo");
        Halo.enabled = false;
        

    }
	
	// Update is called once per frame
	void Update () {
       

    }

    void OnTriggerEnter(Collider col)
    {

        if (col.name == "Hero")
        {
            Halo.enabled = true;
            CodeController.GetComponent<PlayerController>().CheckCanUseCodeEditer = true;
            print("On Trigger");
        }


    }

    void OnTriggerExit(Collider col)
    {
        if (col.name == "Hero")
        {
            Halo.enabled = false;
            CodeController.GetComponent<PlayerController>().CheckCanUseCodeEditer = false;
            CodeController.GetComponent<PlayerController>().ForceCloseCodeEditer();
            print("Off Trigger");
        }
    }



}