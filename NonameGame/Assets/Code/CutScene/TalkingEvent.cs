using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkingEvent : MonoBehaviour {

    // GameObj
    private GameObject TalkingTab;
    public Text Talker;
    public Text Detail;
    public Image Char_PicL;
    public Image Char_PicR;

    // Speech Data
    public string[] SpeechText;
    public string[] TalkerText;
    private int TalkingIndex = 0;
    private int LastTalkingIndex;

    // Contition
    private bool CheckStart = false;
    public bool CheckTalkingDone = false;

    // Use this for initialization
    void Start () {

        // GetObjectRef
        TalkingTab = GameObject.FindGameObjectWithTag("TalkingTab");
        LastTalkingIndex = SpeechText.Length;
        print(LastTalkingIndex);


        // Start
        Hide();
        CharLHide();
        CharRHide();
    }
	
	// Update is called once per frame
	void Update () {

        // Check if Talking not Start (Tab not Show)
        if (CheckStart)
        {

            // Check Spacebar  next Conversation
             if (Input.GetKeyDown(KeyCode.Mouse0))
            {

                SetConversationNow();
            }
        }
	}

    public void StartTalking()
    {
        Show();
        CheckStart = true;
        SetConversationNow();
    }

    private void SetConversationNow()
    {
        // Check Talking Done ?
        if (TalkingIndex == LastTalkingIndex)
        {
            Hide();
            CharLHide();
            CharRHide();

            CheckTalkingDone = true;

        }
        else
        {
            print(TalkingIndex);
            Detail.text = SpeechText[TalkingIndex];
            Talker.text = TalkerText[TalkingIndex];
            TalkingIndex += 1;
        }



    }

    public void Show()
    {
        TalkingTab.gameObject.SetActive(true);
    }

    public void Hide()
    {
        TalkingTab.gameObject.SetActive(false);
    }

    //Char_PicL
    public void CharLShow()
    {
        Char_PicL.gameObject.SetActive(true);
    }

    public void CharLHide()
    {
        Char_PicL.gameObject.SetActive(true);
    }

    //Char_PicR
    public void CharRShow()
    {
        Char_PicR.gameObject.SetActive(true);
    }

    public void CharRHide()
    {
        Char_PicR.gameObject.SetActive(true);
    }
}
