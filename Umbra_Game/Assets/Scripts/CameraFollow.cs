using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //variables to adjust speed at which camera follows player
    public float followSpeed = 2f;
    public Transform target;
    //adjust 
    public float xOffset;
    //adjust camera height
    public float yOffset;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x + xOffset, target.position.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);    
    }
}
