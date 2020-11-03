using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultData : MonoBehaviour
{
    public static string result;
    public Text ResultNumber;
    public Text ResultSubNumber;
    public Text ResultScore;
    public Text advice;
    public Text adviceRank;
    public Text Cluster;

    // Start is called before the first frame update
    void Start()
    {
        string tmp = "";
        float audSpec = 0;
        float mfcc = 0;
        float f0 = 0;
        float c_0 = 0;
        float c_1 = 0;
        float c_2 = 0;
        float c_3 = 0;
        string[] arr;
        
        arr = result.Replace("\r\n", "\n").Split(new[] { '\n', '\r' });
        //Debug.Log(arr[21]);
        for (int i = 0; i < arr.Length; i++)
        {
            Debug.Log( i +":"+ arr[i]);
            if (i > 3 && i < 19) {
                
                //得点に関する部分
                if (i == 4 || i == 6 || i == 7 || i == 16)
                {
                    //+= arr[i] + '\n';
                    string tmp_str = "";
                    tmp_str = arr[i];
                    string[] tmp_l = tmp_str.Split(',');
                    Debug.Log(tmp[0]);
                    tmp_str = tmp_l[2];
                    tmp_str = tmp_str.Replace(")", "");
                    audSpec += float.Parse(tmp_str);

                }
                else if (i >= 8 && i <= 12 || i == 17 || i == 18)
                {
                    //mfcc += arr[i] + '\n';
                    string tmp_str = "";
                    tmp_str = arr[i];
                    string[] tmp_l = tmp_str.Split(',');
                    tmp_str = tmp_l[2];
                    tmp_str = tmp_str.Replace(")", "");
                    mfcc += float.Parse(tmp_str);
                }
                else
                {
                    //f0 += arr[i] + '\n';
                    string tmp_str = "";
                    tmp_str = arr[i];
                    string[] tmp_l = tmp_str.Split(',');
                    Debug.Log(tmp_l[1]);
                    tmp_str = tmp_l[2];
                    tmp_str = tmp_str.Replace(")", "");
                    f0 += float.Parse(tmp_str);
                }
                
            } else if (i != 21) {
                //LRの精度に関する数値
                tmp += arr[i] + '\n';
            }
        }
        //100点に変換
        
        float a = Score(arr, 21);
        c_0 = Score(arr, 40);
        c_1 = Score(arr, 59);
        c_2 = Score(arr, 78);
        c_3 = Score(arr, 97);
        if (a < 1 )
        {
            ResultNumber.text = "Error";
        }
        else if (a > 6.8)
        {
            adviceRank.text = "S";
            ResultNumber.text = "100/100";
            advice.text = "Perfect　自己紹介の神様です";
        }
        else {
            if (a > 5.8) {
                adviceRank.text = "A+";
                advice.text = "Excellent! \n 完璧です！トレーニングの必要はありません。私のアドバイスはもういらないでしょう。自己紹介で彼女ができるかもしれません。";
            }
            else if (a > 5)
            {
                adviceRank.text = "A";
                advice.text = "Great!\n素晴らしい自己紹介です。ほぼ完璧です。合コンではあなたの自己紹介は頭一つ抜けるでしょう";
            }
            else if (a > 4)
            {
                adviceRank.text = "B+";
                advice.text = " Very Good!\nいい自己紹介です。合コンでは好印象なスタートを切れます";
            }
            else if (a > 2.8)
            {
                adviceRank.text = "B";
                advice.text = "Good\n素敵な自己紹介です。ほかの男性と差をつけるにはもう少しトレーニングが必要です。";
            }
            else if (a > 2)
            {
                adviceRank.text = "C+";
                advice.text = "Bad\nトレーニングの必要があります。左の項目を確認してみてください。頑張りましょう";
            }
            else if (a >= 1)
            {
                adviceRank.text = "C";
                advice.text = "You can do it\nもう一度チャレンジしてみましょう。";
            }
            a = a * 7 + 50;
            ResultNumber.text = a.ToString() + "/100";
        }
        c_0 = c_0 * 7 + 50;
        c_1 = c_1 * 7 + 50;
        c_2 = c_2 * 7 + 50;
        c_3 = c_3 * 7 + 50;
        Cluster.text =
            "社交的、飽きっぽい、好奇心旺盛な女性群:\n" + (int)c_0 +"点" + "\n\n" +
            "人見知り、飽きっぽい、繊細な女性群：\n" +(int)c_1 + "点"+ "\n\n" +
            "かなり社交的、面倒見がいい、自己抑制に優れた、冷静、好奇心旺盛な女性：\n" + (int)c_2 + "点" + "\n\n" +
            "社交的で、繊細な女性：\n" + (int)c_3 +"点"+"\n\n"
            ;
        
        ResultScore.text = tmp;
        ResultSubNumber.text =
            "基本周波数の安定性：\n" + Stars(f0) + "\n" + "声の高さを安定させましょう\n\n" +
            "スペクトル包絡：\n" + Stars(mfcc) + "\n" + "抑揚を意識して発生しましょう\n\n" +
            "声の大きさ・明瞭性：\n" + Stars(audSpec) + "\n" + "はっきり発声しましょう\n\n";
        Debug.Log(f0 +""+ mfcc +""+ audSpec);

    }

    private float Score(string[] ls,int num) {
        //100点に変換
        string stlip = ls[num];
        stlip = stlip.Replace("[", "");
        stlip = stlip.Replace("]", "");
        float a = float.Parse(stlip);
        return a;
    }
    private string Stars(float num)
    {
        string star = "";
        if (num < 0)
        {
            star = "★";

        }
        else if (num >= 0 && num < 0.5)
        {
            star = "★★";
        }
        else if (num >= 0.5 && num < 0.7)
        {
            star = "★★★";
        }
        else if (num >= 0.7 && num < 1)
        {
            star = "★★★★";
        }
        else
        {
            star = "★★★★★";
        }
           ;
        return star;
    }
    //データ格納
    //0accuracy: 0.44418689997785665
    //1score: 0.1056902853415819
    //2Nrmse: -1.0092337211745905
    //3('intercept', 3.4771820574054364)
    //4('audSpec_Rfilt_sma[5]_quartile2', ':', -0.1031723554558253)
    //5('pcm_fftMag_mfcc_sma[13]_lpc0', ':', 0.23959643125102)
    //6('audSpec_Rfilt_sma_de[23]_quartile3', ':', 0.1867573637478578)
    //7('audSpec_Rfilt_sma_de[23]_iqr2-3', ':', -0.15642007815309916)
    //8('pcm_fftMag_mfcc_sma_de[6]_lpc0', ':', 0.017922913526581843)
    //9('pcm_fftMag_mfcc_sma_de[12]_skewness', ':', 0.09426959415098514)
    //10('pcm_fftMag_mfcc_sma_de[12]_upleveltime75', ':', -15261.62215249782)
    //11('pcm_fftMag_mfcc_sma_de[12]_downleveltime75', ':', 15261.51140736174)
    //12('pcm_fftMag_mfcc_sma_de[13]_lpc0', ':', 0.036611185026310375)
    //13('F0final_sma_upleveltime25', ':', 0.010101393924536513)
    //14('F0final_sma_upleveltime50', ':', -0.1375921332868324)
    //15('F0final_sma_upleveltime75', ':', -0.12088583262001279)
    //16('audSpec_Rfilt_sma[20]_minRangeRel', ':', 0.9490814703021494)
    //17('pcm_fftMag_mfcc_sma[7]_stddevRisingSlope', ':', -0.5364081550886947)
    //18('pcm_fftMag_mfcc_sma[12]_qregc1', ':', -0.35690051385154403)
    //19('sum', 0.012216147394117638)
    //20('intercept', 3.4771820574054364)
    //21[3.4893982]

    //1:accuracy: 0.4441868999776609
    //score: 0.10569028537565779
    //Nrmse: -1.0092337211571023
    //('intercept', 3.4515014039454415)
    //('audSpec_Rfilt_sma[5]_quartile2', ':', -0.4100510250865649)
    //('pcm_fftMag_mfcc_sma[13]_lpc0', ':', 0.18096060661550709)
    //('audSpec_Rfilt_sma_de[23]_quartile3', ':', -0.5222688053690191)
    //('audSpec_Rfilt_sma_de[23]_iqr2-3', ':', 0.2681145237295383)
    //('pcm_fftMag_mfcc_sma_de[6]_lpc0', ':', -0.11067693611094859)
    //('pcm_fftMag_mfcc_sma_de[12]_skewness', ':', -0.02728291777497504)
    //('pcm_fftMag_mfcc_sma_de[12]_upleveltime75', ':', -280153.81899223296)
    //('pcm_fftMag_mfcc_sma_de[12]_downleveltime75', ':', 280153.5473495645)
    //('pcm_fftMag_mfcc_sma_de[13]_lpc0', ':', 0.043313249068598035)
    //('F0final_sma_upleveltime25', ':', -0.0025119211675783764)
    //('F0final_sma_upleveltime50', ':', -0.08790408045698048)
    //('F0final_sma_upleveltime75', ':', -0.16296421742068606)
    //('audSpec_Rfilt_sma[20]_minRangeRel', ':', -0.12131095954804892)
    //('pcm_fftMag_mfcc_sma[7]_stddevRisingSlope', ':', -0.30509089500057174)
    //('pcm_fftMag_mfcc_sma[12]_qregc1', ':', -2.1564819440857486)
    //('sum', -3.685797991061671)
    //('intercept', 3.4515014039454415)
    //[-0.23429659]
}
