using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0.0f, 1.0f * Time.deltaTime, 0.0f);

    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Cloud"))
        {
            ScoreManager.Add(1);
            Destroy(gameObject);
        }
    }
}
