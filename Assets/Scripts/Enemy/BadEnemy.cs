using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadEnemy : MonoBehaviour
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
        else transform.Translate(0.0f, -1.0f * Time.deltaTime, 0.0f);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Cloud"))
        {
            ScoreManager.Add(-1);
            Destroy(gameObject);
        }

    }

    public void FallDown()
    {
        EnemyState = false;
        transform.Rotate(0.0f, 0.0f, 30.0f);

    }

}
