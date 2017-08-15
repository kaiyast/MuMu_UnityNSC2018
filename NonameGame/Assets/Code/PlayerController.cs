using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private bool IsShowCodeEditor = false;
    public GameObject CodeEditorBar;
    public bool CheckCanUseCodeEditer = false;
    private GameObject Hero;
    // Use this for initialization
    void Start () {
        CodeEditorBar.SetActive(false);
        Hero = GameObject.FindGameObjectWithTag("Hero");
    }
	
	// Update is called once per frame
	void Update () {

        if (CheckCanUseCodeEditer == true)
        {

            if (Input.GetKeyDown(KeyCode.Q))
            {
                // Showeditor
                if (IsShowCodeEditor)
                {
                    IsShowCodeEditor = false;
                    Hero.GetComponent<HeroMovement>().setIsOpenEditor(false);
                    CodeEditorBar.SetActive(false);
                }
                else
                {
                    this.GetComponent<C_2_Py>().ReadCodeFileToInputField("pythonlib/" + GameInformationModel.mission, GameInformationModel.hoverobject);
                    Hero.GetComponent<HeroMovement>().setIsOpenEditor(true);
                    IsShowCodeEditor = true;
                    CodeEditorBar.SetActive(true);
                }

            }

        }

	}
    public void ForceCloseCodeEditer()
    {
        IsShowCodeEditor = false;
        CodeEditorBar.SetActive(false);
    }
}
