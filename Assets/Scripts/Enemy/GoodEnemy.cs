using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodEnemy : MonoBehaviour
{

    private bool EnemyState;

    // Start is called before the first frame update
    void Start()
    {
        EnemyState = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyState) transform.Translate(0.0f, 1.0f * Time.deltaTime, 0.0f);
        else
        {
            transform.position = new Vector3(0,-2.0f * Time.deltaTime, 0)+ transform.position;
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Cloud"))
        {
            ScoreManager.Add(1);
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Hell") && !EnemyState)
        {
            Destroy(gameObject);

        }

    }

    public void FallDown()
    {
        EnemyState = false;
        transform.Rotate(0.0f, 0.0f, 30.0f);

    }
}
