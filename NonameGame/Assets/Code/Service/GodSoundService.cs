using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GodSoundService : MonoBehaviour {


    private string[] texts;
    private int textnow = 0;
    private Text godtext;
    // Use this for initialization
    void Start () {

        godtext = this.GetComponentInChildren<Text>();

        string[] textcase = { "Hello Boy", "Bye" };
        settexts(textcase);

        

    }
	


    public void settexts(string[] inputtexts)
    {
        texts = inputtexts;
        showtext();
        startanimation();
    }

    private void startanimation()
    {
        this.GetComponent<Animator>().Play("show");
    }

    private void stopanimation()
    {
        this.GetComponent<Animator>().Play("hide");
    }

    private void showtext()
    {
        if (textnow >= texts.Length)
        {
            stopanimation();
        }
        else
        {
            godtext.text = texts[textnow];
            textnow++;
        }




    }
}
