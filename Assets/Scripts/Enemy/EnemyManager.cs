using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] itoArray;
    public GameObject goodEnemyRef;
    public GameObject badEnemyRef;
    int itoNum;
    public float goodEnemyProb;
    public float createDurationMin;
    public float CreateDurationMax;
    float time = 0.0f;
    void Start()
    {
        itoNum = itoArray.Length - 1;
        time = Random.Range(createDurationMin, CreateDurationMax);
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if(time<=0)
        {
            time = Random.Range(createDurationMin, CreateDurationMax);
            int ito = Random.Range(0, itoNum);
            Ito itoCom = itoArray[ito].GetComponent<Ito>();

            Vector3 position = itoCom.EndPos;
            GameObject obj = GameObject.Instantiate(Random.Range(0.0f, 1.0f) > goodEnemyProb ? badEnemyRef : goodEnemyRef);
            obj.transform.position = position;
        }
    }
}
