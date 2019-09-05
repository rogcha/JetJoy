using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private float secondsleftTillSpawn = 0;
    public float spawnSpeed = 30;


    public float spawnChance;
    public GameObject obstPrefab;

    public Character c;
    void Update()
    {
        if (c.isPlaying)
        {
        secondsleftTillSpawn -= Time.deltaTime;
        int temp = Random.Range(0, 100);


        if (temp <= spawnChance && secondsleftTillSpawn <= 0)
        {
            Instantiate(obstPrefab, new Vector3(15f, Random.Range(transform.position.y + 2f, transform.position.y - 2f), 0), Quaternion.identity, transform);

            secondsleftTillSpawn = spawnSpeed;


        }
    } else if (transform.childCount > 0)
        {
            foreach(Transform t in transform)
            {
                Destroy(t.gameObject);
            }
        }
   


    }
}
