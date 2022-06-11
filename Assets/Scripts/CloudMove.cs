using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour
{
    // Start is called before the first frame update
    private float MoveSpeed;
    void Start()
    {
        MoveSpeed = Random.Range(1.0f, 4.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            -MoveSpeed * Time.deltaTime,0.0f, 0.0f) + transform.position;


        if (transform.position.x<-10)
        {
            Destroy(gameObject);
        }

    }
}
