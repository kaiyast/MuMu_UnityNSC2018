using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionController : MonoBehaviour {

    // Use this for initialization

    void Start () {
        string mission = GameInformationModel.mission;

        print("Load mission prefab");
           Instantiate((GameObject)Resources.Load("prefabs/" + mission, typeof(GameObject)));

    }
	
}
