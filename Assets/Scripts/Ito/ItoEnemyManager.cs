using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItoEnemyManager : MonoBehaviour
{
    List<GameObject> enemyList;
    Ito itoCom;
    // Start is called before the first frame update
    void Start()
    {
        itoCom = GetComponent<Ito>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddEnemy(GameObject enemy)
    {
        enemyList.Add(enemy);
    }

    public void Cut()
    {
        float yPos = itoCom.StartPos.y - itoCom.MaxLength * itoCom.LengthPercent;
        for(int i=0;i<enemyList.Count;i++)
        {
            if(enemyList[i].transform.position.y<yPos)
            {
                if(enemyList[i].GetComponent<BadEnemy>())
                {
                    enemyList[i].GetComponent<BadEnemy>().FallDown();
                }
                else if(enemyList[i].GetComponent<GoodEnemy>())
                {
                    enemyList[i].GetComponent<GoodEnemy>().FallDown();
                }
            }
        }
    }
}
