using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

    private float secondslefttillSpawn = 0;
    public float SpawnSpeed = 30;

    public float SpawnChance;
    public GameObject obstPrefab;

    public Character c;

    void Start()
    {
        if (c.isPlaying)
        {
            secondslefttillSpawn -= Time.deltaTime;
            int temp = Random.Range(0, 100);

            if (temp <= SpawnChance && secondslefttillSpawn <= 0)
            {

                Instantiate(obstPrefab, new Vector3(15f, Random.Range(transform.position.y + 2f, transform.position.y - 2f), 0), Quaternion.identity, transform);

                secondslefttillSpawn = SpawnChance;


            }
        }
        else if (transform.childCount > 0)
        {
            foreach (Transform t in transform)
            {
                Destroy(t.gameObject);
            }
        }


    }
} 
