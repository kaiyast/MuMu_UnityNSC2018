using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadTrigger : MonoBehaviour {

    private GameObject Hero;
    private GameObject SceneCode;

    // Use this for initialization
    void Start () {
        Hero = GameObject.FindGameObjectWithTag("Hero");
        SceneCode = GameObject.FindGameObjectWithTag("SceneCode");
    }
	
	// Update is called once per frame
	void Update () {
       


    }

    void OnTriggerEnter(Collider col)
    {

        if (col.name == "Hero")
        {
      
            Hero.transform.position = new Vector3(-2.5f, 1.1f, -4.5f);

            SceneCode.GetComponent<Scene2>().AddFallenNum();

            print("Die");

        }


    }


    }
