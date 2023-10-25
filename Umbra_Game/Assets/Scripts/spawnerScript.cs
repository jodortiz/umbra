using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private float spawnTime;
    [SerializeField] private GameObject playerRef;

    public bool gameStart;
    // Start is called before the first frame update
    void Start()
    {
        gameStart = true;

        StartCoroutine(LightWaves());
    }

    private void SpawnObstacle()
    {
        GameObject obstacle = Instantiate(obstaclePrefab) as GameObject;
        obstacle.transform.position = new Vector2(playerRef.GetComponent<Transform>().position.x + 15, 3.5f);
    }

    IEnumerator LightWaves()
    {
            while (gameStart == true)
            {
                yield return new WaitForSeconds(spawnTime);
                SpawnObstacle();
            }
    }

    // Update is called once per frame
    void Update()
    {
        /*if (gameStart == true)
        {
            StartCoroutine(LightWaves());
            gameStart = false;
        }*/
    }

    
}
