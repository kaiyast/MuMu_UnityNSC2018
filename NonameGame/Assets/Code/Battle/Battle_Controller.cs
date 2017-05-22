using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle_Controller : MonoBehaviour {


    public GameObject Hero;


    // Use this for initialization
    void Start () {
        Hero.GetComponent<Animator>().Play("Land");
    }
	
	// Update is called once per frame
	void Update () {

        Hero.GetComponent<Animator>().SetBool("Grounded", true);

    }
}
