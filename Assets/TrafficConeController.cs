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
        //Unity�����̃I�u�W�F�N�g���擾
        GameObject unitychan = GameObject.Find("unitychan");
        //Unity�����ƃR�C���̍������߂�
        if (unitychan.transform.position.z - this.transform.position.z > 0)
        {
            Destroy(this.gameObject, 1.0f);
        }
    }
}
