using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightObstacleScript : MonoBehaviour
{
    private float speed;
    private Rigidbody2D rb;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(3.0f, 5.0f);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -17)
        {
            Destroy(this.gameObject);
        }
    }
}
