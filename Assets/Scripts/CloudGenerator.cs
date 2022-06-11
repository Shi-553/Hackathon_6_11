using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour
{
    // プレハブ格納用
    public GameObject Prefab1; // プレハブ格納用
    public GameObject Prefab2; // プレハブ格納用
    public GameObject Prefab3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(1.0f, 100.0f) < 3)
        {
            // 生成位置
            Vector3 pos = new Vector3(20.0f, Random.Range(-5.0f,5.0f), 0.8f);
            int number = Random.Range(0, 2);


            switch (number)
            {
                case 0:
                    // プレハブを指定位置に生成
                    Instantiate(Prefab1, pos, Quaternion.identity);
                    break;
                case 1:
                    // プレハブを指定位置に生成
                    Instantiate(Prefab2, pos, Quaternion.identity);
                    break;
                case 2:
                    // プレハブを指定位置に生成
                    Instantiate(Prefab3, pos, Quaternion.identity);
                    break;
                default:
                    break;
            }
        }
    }
}
