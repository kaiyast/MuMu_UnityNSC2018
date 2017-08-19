using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class C_2_Py : MonoBehaviour {

   private enum CodeFieldPos { Top,Mid,Bot};

    public InputField CodeInputFieldMid;
    public InputField CodeInputFieldTop;
    public InputField CodeInputFieldBot;
    public Button RunButton;

    private string fileName = "helloworld";

    private string fullCodeFileName = "helloworld";

    private string sourcePath = @"\Assets\Code";

    // old
    private string codedata = "";

    private string[] fullPathFileNames = { "helloworld-top.txt","helloworld-mid.txt", "helloworld-bot.txt" };


    // keep 3 index top mid bot
    private string[] codedatas = {"","","" };

    // line 3 index top mid bot
    private int[] linenums = { 0,0,0 };

    private string saveFilePath = "";

    // Use this for initialization
    void Start () {

        //ReadCodeFileToInputField(SourcePath, NewFileName + ".py");
    }
	
	// Update is called once per frame
	void Update () {


    }

    public void ResetCode()
    {
       
        CodeInputFieldMid.text = File.ReadAllText(Application.streamingAssetsPath + "/" + sourcePath + "/" + fileName + "-mid.txt");
        saveFile();

    }

    public void RunCode()
    {
        saveFile();
        CopyFile(sourcePath, fileName + ".txt", fileName + ".py");
        CompilePyAndGet(sourcePath, fileName + ".py" );
    }

    public void ReadCodeFileToInputField( string sourcePath, string fileName)
    {
        

        this.fileName = fileName;
        this.sourcePath = sourcePath;

        this.saveFilePath = Application.persistentDataPath + "/" + sourcePath;
        this.fullCodeFileName = saveFilePath + "/" + fileName + ".txt";

        this.fullPathFileNames[(int)CodeFieldPos.Top] = saveFilePath + "/" + fileName + "-top" + ".txt";
        this.fullPathFileNames[(int)CodeFieldPos.Mid] = saveFilePath + "/" + fileName + "-mid" + ".txt";
        this.fullPathFileNames[(int)CodeFieldPos.Bot] = saveFilePath + "/" + fileName + "-bot" + ".txt";

        print(saveFilePath);
        print(fullPathFileNames[(int)CodeFieldPos.Mid]);

        // Check if file in savepath is exist load this  ** only mid file **
        if (File.Exists(fullPathFileNames[(int)CodeFieldPos.Mid]))
        {
            print("Found in savepath");
            readcode();
            show();
        }
        // if not found (first time open) read orgin file in asset ** only mid file **
        else
        {
            print("Not Found in savepath --> save this");
            // init code

            print(sourcePath + "/" + fileName + "-top.txt");

            // File.ReadAllLines
            string toptext = File.ReadAllText(Application.streamingAssetsPath + "/" + sourcePath + "/" + fileName + "-top.txt");
            string midtext = File.ReadAllText(Application.streamingAssetsPath + "/" + sourcePath + "/" + fileName + "-mid.txt");
            string bottext = File.ReadAllText(Application.streamingAssetsPath + "/" + sourcePath + "/" + fileName + "-bot.txt");
            // TextAsset toptext = (TextAsset)Resources.Load("pythonlib/missioneditor/testbox-top.txt");
            //  TextAsset midtext = (TextAsset)Resources.Load(sourcePath + "/" + fileName + "-mid.txt");
            //TextAsset bottext = (TextAsset)Resources.Load(sourcePath + "/" + fileName + "-bot.txt");

            print(toptext);

            CodeInputFieldTop.text = toptext;
            CodeInputFieldMid.text = midtext;
            CodeInputFieldBot.text = bottext;

            saveFile();
            readcode();
            show();
            
           
        }

    }

    private void show()
    {
        CodeInputFieldTop.text = codedatas[0];
        CodeInputFieldMid.text = codedatas[1];
        CodeInputFieldBot.text = codedatas[2];
    }

    private void resetAllCodeData()
    {
        codedatas[(int)CodeFieldPos.Top] = "";
        codedatas[(int)CodeFieldPos.Mid] = "";
        codedatas[(int)CodeFieldPos.Bot] = "";
    }

    private void readcode()
    {
        resetAllCodeData();

        // Top Mid Bot

        for (int i = 0; i < 3; i++)
        {
            string[] lines = File.ReadAllLines(fullPathFileNames[i]);
            linenums[i] = lines.Length;
            foreach (string line in lines)
            {
                codedatas[i] += line + "\n";
            }
        }

        print(linenums[0]+","+linenums[1]+","+linenums[2]);
    }

    private void saveFile()
    {
        // Check for new open
        if (!File.Exists(saveFilePath))
        {
            // create folder
            Directory.CreateDirectory(saveFilePath);
        }

        // Write Top
        File.WriteAllText(fullPathFileNames[(int)CodeFieldPos.Top], CodeInputFieldTop.text);

        File.WriteAllText(fullPathFileNames[(int)CodeFieldPos.Mid], CodeInputFieldMid.text);

        File.WriteAllText(fullPathFileNames[(int)CodeFieldPos.Bot], CodeInputFieldBot.text);

        // Combine Py file
        string fullcodefile = CodeInputFieldTop.text + "\n" + CodeInputFieldMid.text + "\n" + CodeInputFieldBot.text;

        File.WriteAllText(fullCodeFileName, fullcodefile);
    }

    private void CopyFile(string sourcePath, string FileName, string NewFileName)
    {
        string sourcesaveFile = Application.persistentDataPath + "/" + sourcePath + "/" + FileName;
        string destsaveFile = Application.persistentDataPath + "/" + sourcePath + "/" + NewFileName;

        print("Copy to .py ");
        print("sourceFile : " + sourcesaveFile);
        print("destFile : " + destsaveFile);

        try {
            File.Copy(sourcesaveFile, destsaveFile, true);
            UnityEngine.Debug.Log("Copy Success..");
        }
        catch{ UnityEngine.Debug.Log("Copy Fail..");  }
      
    }

    private void CompilePyAndGet(string sourcePath,string fileName)
    {
        string FullFilePath = Application.persistentDataPath + "/" + sourcePath + "/" + fileName;
        UnityEngine.Debug.Log(FullFilePath);

        string cmd = "/c python " + FullFilePath;

        Process process = new Process();
        process.StartInfo.FileName = "cmd.exe";
        process.StartInfo.Arguments = cmd;
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;

        //* Start process
        process.Start();
        //* Read the other one synchronously
        string output = process.StandardOutput.ReadToEnd();
        process.WaitForExit();

        UnityEngine.Debug.Log(output);
    }

 }
