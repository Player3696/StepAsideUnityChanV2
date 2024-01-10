using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using System;


public class ItemGenerator : MonoBehaviour
{
    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //conePrefabを入れる
    public GameObject conePrefab;
    //スタート地点
    private int startPos = 80;
    //ゴール地点
    private int goalPos = 360;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;
    //アイテム生成レンジ
    private int createInterval = 15;
    //private float createInterval = 40.0f;

    //前回生成位置
    private int savePoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        /**
        //一定の距離ごとにアイテムを生成
        for (int i = startPos; i < goalPos; i += 15)
        {
            //どのアイテムを出すのかをランダムに設定
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                }
            }
            else
            {

                //レーンごとにアイテムを生成
                for (int j = -1; j <= 1; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムを置くZ座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    //60%コイン配置:30%車配置:10%何もなし
                    if (1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
                    }
                }
            }
        }
        **/
    }

    // Update is called once per frame
    void Update()
    {
        //Unityちゃんのオブジェクトを取得
        GameObject unitychan = GameObject.Find("unitychan");
        int unitychanPos = (int)(Math.Truncate(unitychan.transform.position.z));
        //float unitychanPos = unitychan.transform.position.z;
        //Debug.Log("＊＊＊＊＊＊＊＊＊＊" + "[" + unitychanPos + "]");
        //一定の距離ごとにアイテムを生成
        if (unitychanPos % createInterval == 0 && savePoint < unitychanPos && unitychanPos < goalPos - 4*createInterval)
        {
            Debug.Log("＊＊＊＊＊アイテム配置＊＊＊＊＊" + "[" + unitychanPos + "]");
            savePoint = unitychanPos;
            //どのアイテムを出すのかをランダムに設定
            int num = UnityEngine.Random.Range(1, 11);
            if (num <= 2)
            {
                //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, unitychanPos + 3 * createInterval);
                    Debug.Log("Corn配置:" + 4 * j　+"," +  cone.transform.position.y + "," + unitychanPos + 3 * createInterval);

                }
            }
            else
            {

                //レーンごとにアイテムを生成
                for (int j = -1; j <= 1; j++)
                {

                    //アイテムの種類を決める
                    int item = UnityEngine.Random.Range(1, 11);
                    //アイテムを置くZ座標のオフセットをランダムに設定
                    //int offsetZ = Random.Range(-5, 6);
                    int offsetZ = UnityEngine.Random.Range(-5, 6);
                    //60%コイン配置:30%車配置:10%何もなし
                    Debug.Log("★★★★★" + (j + 2) + "レーン生成★★★★★");
                    if (1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, unitychanPos + offsetZ + 3 * createInterval);
                        //int temp = unitychanPos + offsetZ + createInterval;
                        Debug.Log("Coin配置:(" + posRange * j + "," + coin.transform.position.y + "," + (unitychanPos + offsetZ + 3 * createInterval) + ")");
                        //Debug.Log("Coin unitychanPos + offsetZ + createInterval:" + temp);

                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, unitychanPos + offsetZ + 3 * createInterval);
                        //int temp = unitychanPos + offsetZ + createInterval;
                        Debug.Log("Car配置:(" + posRange * j + "," + car.transform.position.y + "," + (unitychanPos + offsetZ + 3 * createInterval) + ")");
                        //Debug.Log("Car unitychanPos + offsetZ + createInterval:" + temp);

                    }
                }
            }
        }
    }
}