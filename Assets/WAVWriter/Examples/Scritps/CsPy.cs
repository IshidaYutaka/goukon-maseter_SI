using System.Diagnostics;
using System.IO;
using UnityEngine;

public class CsPy : MonoBehaviour
{
    //pythonがある場所
    private string pyExePath = @"C:\Users\kikuc\Anaconda3\python.exe";

    //実行したいスクリプトがある場所
    

    public void Python(string pyCodePath)
    {
        UnityEngine.Debug.Log("test");
        //外部プロセスの設定
        ProcessStartInfo processStartInfo = new ProcessStartInfo()
        {
            FileName = pyExePath, //実行するファイル(python)
            UseShellExecute = false, //シェルを使うかどうか
            CreateNoWindow = true, //ウィンドウを開くかどうか
            RedirectStandardOutput = true, //テキスト出力をStandardOutputストリームに書き込むかどうか
            Arguments = pyCodePath, //実行するスクリプト 引数(複数可)
        };

        //外部プロセスの開始
        Process process = Process.Start(processStartInfo);

        //ストリームから出力を得る
        StreamReader streamReader = process.StandardOutput;

        //外部プロセスの終了
        process.WaitForExit();
        string result = streamReader.ReadLine();
        process.Close();
        UnityEngine.Debug.LogWarning(result);
        //実行
        UnityEngine.Debug.Log(result);
    }
}