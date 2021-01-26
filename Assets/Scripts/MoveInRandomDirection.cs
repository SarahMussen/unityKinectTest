using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInRandomDirection : MonoBehaviour
{

    public float speed = 1.0f;


    private float targetRangeX = 6.0f; //6.0
    private float targetRangeMinY = 3.0f;
    private float targetRangeMaxY = 8.0f;
    private float targetPosZ = -4.0f;

    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = new Vector3(Random.Range(-targetRangeX, targetRangeX), Random.Range(targetRangeMinY, targetRangeMaxY), targetPosZ);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.forward*Time.deltaTime*speed);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
}
