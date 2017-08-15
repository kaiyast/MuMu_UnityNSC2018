using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GlowWhenHover : MonoBehaviour {


    public GameObject ObjectToGlow;

    private GameObject CoreCodeController;
    // Use this for initialization
    Behaviour Halo;

    void Start () {
        CoreCodeController = GameObject.FindGameObjectWithTag("SceneCore");
        Halo = (Behaviour)ObjectToGlow.GetComponent("Halo");
        Halo.enabled = false;
        

    }
	

    void OnTriggerEnter(Collider col)
    {

        if (col.name == "Hero")
        {
            Halo.enabled = true;
            CoreCodeController.GetComponent<PlayerController>().CheckCanUseCodeEditer = true;

            GameInformationModel.hoverobject = ObjectToGlow.name;

            print("On Trigger");
        }


    }

    void OnTriggerExit(Collider col)
    {
        if (col.name == "Hero")
        {
            Halo.enabled = false;
            CoreCodeController.GetComponent<PlayerController>().CheckCanUseCodeEditer = false;
            CoreCodeController.GetComponent<PlayerController>().ForceCloseCodeEditer();
            print("Off Trigger");
        }
    }



}
