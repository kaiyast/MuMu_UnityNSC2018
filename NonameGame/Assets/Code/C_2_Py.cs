using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class C_2_Py : MonoBehaviour {

    string FileName = "helloworld";
    string NewFileName = "helloworld_new";
    string NewFileType = "py";
    string SourcePath = @"E:\MuMu_UnityNSC2018\NonameGame\Assets\Code";
    string TargetPath = @"E:\MuMu_UnityNSC2018\NonameGame\Assets\Code";

    public InputField CodeInputField;
    public Button RunButton;

    // Use this for initialization
    void Start () {


       

        ReadCodeFileToInputField(SourcePath, NewFileName + ".py");
    }
	
	// Update is called once per frame
	void Update () {


    }

    public void RunCode()
    {
        SaveFile(CodeInputField, SourcePath, FileName + ".txt");
        CopyFile(SourcePath, TargetPath, FileName + ".txt", NewFileName, "py");
        CompilePyAndGet(TargetPath, NewFileName + "." + NewFileType);
    }

    private void ReadCodeFileToInputField( string SourcePath, string FileName)
    {

        string[] lines = System.IO.File.ReadAllLines(SourcePath+ @"\" + FileName);

       
        foreach (string line in lines)
        {
            CodeInputField.text += line + "\n";
        }


    }

    private void SaveFile(InputField CodeInputField,  string SourcePath, string FileName)
    {

        
        System.IO.File.WriteAllText(SourcePath+@"\"+FileName, CodeInputField.text);

    }

    private void CopyFile(string SourcePath, string TartgetPath, string FileName,string NewFileName, string NewFileType)
    {
        string sourceFile = System.IO.Path.Combine(SourcePath, FileName);
        string destFile = System.IO.Path.Combine(TartgetPath, NewFileName + "." + NewFileType);

        if (!System.IO.Directory.Exists(TartgetPath))
        {
            System.IO.Directory.CreateDirectory(TartgetPath);
        }

        try {
            System.IO.File.Copy(sourceFile, destFile, true);
            UnityEngine.Debug.Log("Copy Success..");
        }
        catch{ UnityEngine.Debug.Log("Copy Fail..");  }

        

        
    }

    private void CompilePyAndGet(string SourcePath,string FileName)
    {
        string FullFilePath = SourcePath + @"\" + FileName;
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
