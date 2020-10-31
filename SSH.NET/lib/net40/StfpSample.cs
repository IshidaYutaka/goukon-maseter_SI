﻿using System;
using System.IO;
using Renci.SshNet;

class SftpSample
{
    static void Main(string[] args)
    {
        //秘密鍵使う場合
        //例としてユーザーディレクトリ配下の.sshディレクトリ内のsecret_key.pemを秘密鍵として使う
        string secretKeyPath = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".ssh", "secret_key.pem");
        var authMethod = new PrivateKeyAuthenticationMethod("username", new PrivateKeyFile(secretKeyPath, "finger_print"));

        //パスワードの場合
        var authMethod = new PasswordAuthenticationMethod("username", "password");

        //接続情報のインスタンス生成
        var connectionInfo = new ConnectionInfo("IP or domain", 22, "username", authMethod);

        using (var client = new SftpClient(connectionInfo))
        {
            //接続してアップロードディレクトリに移動
            client.Connect();
            client.ChangeDirectory("/home/username");
            using (var fs = System.IO.File.OpenRead("test.txt"))
            {
                //ファイルのアップロード（trueで上書き）
                client.UploadFile(fs, "test.txt", true);
            }
            client.Disconnect();

            //接続してダウンロードディレクトリに移動
            client.Connect();
            client.ChangeDirectory("/home/username");
            using (var fs = System.IO.File.OpenWrite("test.txt"))
            {
                //ファイルのダウンロード
                client.DownloadFile("test.txt", fs);
            }
            client.Disconnect();
        }
    }
}