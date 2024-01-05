using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficConePrefabController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Unityちゃんのオブジェクトを取得
        GameObject unitychan = GameObject.Find("unitychan");
        //Unityちゃんとコインの差を求める
        if (unitychan.transform.position.z - this.transform.position.z > 0)
        {
            Destroy(this.gameObject, 1.0f);
        }
    }
}
