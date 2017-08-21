using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveStoneService : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter(Collider col)
    {

        if (col.name == "Hero")
        {
            string missionname = GameInformationModel.mission;
            GameInformationModel.savemission = missionname;

            GameObject savepointstone = GameObject.FindGameObjectWithTag("Savepointstone");
            savepointstone.GetComponent<Animator>().Play("start");

            print("On Trigger : Save Stone");
        }


    }

}
