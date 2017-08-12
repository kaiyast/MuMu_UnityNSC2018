using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene2 : MonoBehaviour {

    private int FallenNum = 0;
    private GameObject SceneCore;
    private GameObject Hero;

    public GameObject StoneTrigger;

    public bool CheckTalking = false;
    // Use this for initialization
    void Start () {
        SceneCore = GameObject.FindGameObjectWithTag("SceneCore");
        Hero = GameObject.FindGameObjectWithTag("Hero");
    }
	
	// Update is called once per frame
	void Update () {

        if (CheckTalking == false)
        {
            if (FallenNum == 1)
            {
                SceneCore.GetComponent<TalkingEvent>().StartTalking();
                Hero.GetComponent<HeroMovement>().SetCheckCutScene(true);

                CheckTalking = true;
                FallenNum += 10000;
            }
        }
        else
        {
            if (SceneCore.GetComponent<TalkingEvent>().CheckTalkingDone == true)
            {
               
                Hero.GetComponent<HeroMovement>().SetCheckCutScene(false);
                CheckTalking = false;

                // Unlock CodeTab Skill
                StoneTrigger.GetComponent<Scene2StoneTrigger>().CheckUnlockTriger = true;
            }

        }




	}

    public void AddFallenNum()
    {

        FallenNum += 1;
        print(FallenNum);
         
    }


}
