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
    float gameTime = 0.0f;
    static bool maxDuration = false;
    static bool maxSpeed = false;
    float enemySpeed = 2.0f;
    float enemySpeedRange = 0.0f;
    void Start()
    {
        itoNum = itoArray.Length;
        time = Random.Range(createDurationMin, CreateDurationMax);
    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;
        time -= Time.deltaTime;
        if(time<=0)
        {
            time = Random.Range(createDurationMin, CreateDurationMax);
            int ito = (int)(Random.Range(0.0f, 1.0f) * itoNum);
            if (ito == itoNum)
                ito--;
            Ito itoCom = itoArray[ito].GetComponent<Ito>();

            Vector3 position = itoCom.EndPos - new Vector3(0, 0, 0.1f);
            GameObject obj = GameObject.Instantiate(Random.Range(0.0f, 1.0f) > goodEnemyProb ? badEnemyRef : goodEnemyRef);
            obj.transform.position = position;
            if(obj.transform.GetComponent<GoodEnemy>())
            {
                obj.transform.GetComponent<GoodEnemy>().speed = enemySpeed + Random.Range(0, enemySpeedRange);
            }
            else if(obj.transform.GetComponent<BadEnemy>())
            {
                obj.transform.GetComponent<BadEnemy>().speed = enemySpeed + Random.Range(0, enemySpeedRange * 1.5f);
            }
            itoCom.AddEnemy(obj);
        }
        if(gameTime>=6&&!maxDuration)
        {
            enemySpeed += 0.1f;
            enemySpeedRange += 0.3f;
            gameTime = 0;
            CreateDurationMax -= 0.1f;
            createDurationMin += 0.1f;
            goodEnemyProb -= 0.02f;
            if (CreateDurationMax-0.5<=createDurationMin)
            {
                maxDuration = true;
            }
        }
        else if (gameTime >= 5 && !maxSpeed)
        {
            enemySpeed += 0.15f;
            enemySpeedRange += 0.5f;
            gameTime = 0;
            CreateDurationMax -= 0.1f;
            createDurationMin -= 0.1f;
            if (createDurationMin<=0.1f)
            {
                maxSpeed = true;
            }
        }
    }
}
