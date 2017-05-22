using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private bool IsShowCodeEditor = false;
    public GameObject CodeEditorBar;
    public bool CheckCanUseCodeEditer = false;

    // Use this for initialization
    void Start () {
        CodeEditorBar.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

        if (CheckCanUseCodeEditer == true)
        {

            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (IsShowCodeEditor)
                {
                    IsShowCodeEditor = false;
                    CodeEditorBar.SetActive(false);
                }
                else
                {
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
