using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using System;


public class ItemGenerator : MonoBehaviour
{
    //carPrefab������
    public GameObject carPrefab;
    //coinPrefab������
    public GameObject coinPrefab;
    //conePrefab������
    public GameObject conePrefab;
    //�X�^�[�g�n�_
    private int startPos = 80;
    //�S�[���n�_
    private int goalPos = 360;
    //�A�C�e�����o��x�����͈̔�
    private float posRange = 3.4f;
    //�A�C�e�����������W
    private int createInterval = 15;
    //private float createInterval = 40.0f;

    //�O�񐶐��ʒu
    private int savePoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        /**
        //���̋������ƂɃA�C�e���𐶐�
        for (int i = startPos; i < goalPos; i += 15)
        {
            //�ǂ̃A�C�e�����o���̂��������_���ɐݒ�
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                //�R�[����x�������Ɉ꒼���ɐ���
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                }
            }
            else
            {

                //���[�����ƂɃA�C�e���𐶐�
                for (int j = -1; j <= 1; j++)
                {
                    //�A�C�e���̎�ނ����߂�
                    int item = Random.Range(1, 11);
                    //�A�C�e����u��Z���W�̃I�t�Z�b�g�������_���ɐݒ�
                    int offsetZ = Random.Range(-5, 6);
                    //60%�R�C���z�u:30%�Ԕz�u:10%�����Ȃ�
                    if (1 <= item && item <= 6)
                    {
                        //�R�C���𐶐�
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //�Ԃ𐶐�
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
        //Unity�����̃I�u�W�F�N�g���擾
        GameObject unitychan = GameObject.Find("unitychan");
        int unitychanPos = (int)(Math.Truncate(unitychan.transform.position.z));
        //float unitychanPos = unitychan.transform.position.z;
        //Debug.Log("��������������������" + "[" + unitychanPos + "]");
        //���̋������ƂɃA�C�e���𐶐�
        if (unitychanPos % createInterval == 0 && savePoint < unitychanPos && unitychanPos < goalPos - 4*createInterval)
        {
            Debug.Log("�����������A�C�e���z�u����������" + "[" + unitychanPos + "]");
            savePoint = unitychanPos;
            //�ǂ̃A�C�e�����o���̂��������_���ɐݒ�
            int num = UnityEngine.Random.Range(1, 11);
            if (num <= 2)
            {
                //�R�[����x�������Ɉ꒼���ɐ���
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, unitychanPos + 3 * createInterval);
                    Debug.Log("Corn�z�u:" + 4 * j�@+"," +  cone.transform.position.y + "," + unitychanPos + 3 * createInterval);

                }
            }
            else
            {

                //���[�����ƂɃA�C�e���𐶐�
                for (int j = -1; j <= 1; j++)
                {

                    //�A�C�e���̎�ނ����߂�
                    int item = UnityEngine.Random.Range(1, 11);
                    //�A�C�e����u��Z���W�̃I�t�Z�b�g�������_���ɐݒ�
                    //int offsetZ = Random.Range(-5, 6);
                    int offsetZ = UnityEngine.Random.Range(-5, 6);
                    //60%�R�C���z�u:30%�Ԕz�u:10%�����Ȃ�
                    Debug.Log("����������" + (j + 2) + "���[����������������");
                    if (1 <= item && item <= 6)
                    {
                        //�R�C���𐶐�
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, unitychanPos + offsetZ + 3 * createInterval);
                        //int temp = unitychanPos + offsetZ + createInterval;
                        Debug.Log("Coin�z�u:(" + posRange * j + "," + coin.transform.position.y + "," + (unitychanPos + offsetZ + 3 * createInterval) + ")");
                        //Debug.Log("Coin unitychanPos + offsetZ + createInterval:" + temp);

                    }
                    else if (7 <= item && item <= 9)
                    {
                        //�Ԃ𐶐�
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, unitychanPos + offsetZ + 3 * createInterval);
                        //int temp = unitychanPos + offsetZ + createInterval;
                        Debug.Log("Car�z�u:(" + posRange * j + "," + car.transform.position.y + "," + (unitychanPos + offsetZ + 3 * createInterval) + ")");
                        //Debug.Log("Car unitychanPos + offsetZ + createInterval:" + temp);

                    }
                }
            }
        }
    }
}