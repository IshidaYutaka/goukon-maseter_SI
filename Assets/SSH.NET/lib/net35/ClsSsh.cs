using Renci.SshNet;
using System;
using System.IO;
using System.Text;
using System.Threading;
using UnityEngine;

static public class ClsSsh
{

    static private SshClient m_sshClient;
    static private ShellStream m_shellStream;
    public static string f_answer;


    /////////////////////////////////////////////////////////
    //  概要：ssh接続処理                     
    //  はまみ：2020/02/20                                 
    /////////////////////////////////////////////////////////
    static public Boolean Connect(string strHostName, string strLoginId, string strPassword, ref string strResult)
    {
        Boolean bRet = true;

        try
        {
            // 接続情報
            ConnectionInfo ConnNfo = new ConnectionInfo(strHostName,22,strLoginId,new PasswordAuthenticationMethod(strLoginId, strPassword));
                // SSHクライアント生成
            m_sshClient = new SshClient(ConnNfo);
            m_sshClient.ConnectionInfo.Timeout = new TimeSpan(0, 0, 5);

            // SSH接続
            m_sshClient.Connect();
            // SSH接続成功
            if (m_sshClient.IsConnected)
                {
                using (var client = new SftpClient(ConnNfo))
                {
                    //接続してアップロードディレクトリに移動
                    client.Connect();
                    client.ChangeDirectory("opensmile");
                    string fileName = (@"C:\Users\kikuc\Desktop\gokon-master-2018\Assets\WAV\result.wav");
                    Debug.Log(fileName);
                    using (var fs = System.IO.File.OpenRead(fileName))
                    {
                        //ファイルのアップロード（trueで上書き）
                        client.UploadFile(fs,"result.wav", true);
                    }

                    //接続してダウンロードディレクトリに移動
                   
                    m_shellStream = m_sshClient.CreateShellStream("", 80, 40, 80, 40, 1024);

                    StreamReader streamReader = new StreamReader(m_shellStream, Encoding.GetEncoding("shift_jis"));
                    StreamWriter streamWriter = new StreamWriter(m_shellStream, Encoding.GetEncoding("shift_jis"));
                    streamWriter.AutoFlush = true;
                    //Thread.Sleep(2000);
                    var cmd = "sh /home/yutaka/opensmile/opensmile.sh";
                    streamWriter.WriteLine(cmd);
                    SshCommand sc = m_sshClient.CreateCommand(cmd);
                    sc.Execute();
                    string answer = sc.Result;
                    f_answer = answer;
                    Debug.Log("1:"+answer);
                    //var result = streamReader.ReadToEnd();
                    ResultData.result = answer;
                    //Debug.Log("2:"+result);
                    client.Disconnect();
                    //client.Connect();
                    //client.ChangeDirectory("opensmile");
                    //using (var fs = System.IO.File.OpenWrite("text.txt"))
                    //{
                        //ファイルのダウンロード
                        //client.DownloadFile(@"C:\Users\kikuc\Desktop\gokon-master-2018\Assets\WAV\text.txt", fs);
                    //}
                    //client.Disconnect();
                }
                // コマンド実行

                m_shellStream.Dispose();
                m_sshClient.Disconnect();
                m_sshClient.Dispose();
                //別手法
            }

        }
        catch (Exception ex)
        {
            bRet = false;
            strResult = ex.ToString();
        }

        return bRet;
    }

}
