using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMission : MonoBehaviour {



    public Texture2D fadeoutTexture;
    public float fadeSpeed = 0.8f;

    private int drawDepth = -1000;
    private float alpha = 1.0f;
    private int fadeDir = -1;

    static private int static_fadeDir = -1;
    static public float static_fadeSpeed = 0.8f;



    void OnGUI()
    {

        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeoutTexture);

    }

    public float BeginFade(int direction)
    {
        fadeDir = direction;
        return (fadeSpeed);
    }


    public void loadscene(string mission)
    {
        BeginFade(-1);
        GameInformationModel.mission = mission;
        SceneManager.LoadScene("mission");
    }


}
