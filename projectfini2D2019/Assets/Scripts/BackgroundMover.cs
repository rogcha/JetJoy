using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{

    public Transform t;
    public float speed;
    public int difficulty;
    public Character c;

    // Update is called once per frame
    void Update()
    {

        if (c.isPlaying) {
            t.Translate(-speed * Time.deltaTime, 0, 0);
            Time.timeScale += Time.deltaTime * difficulty * 0.002f;
            if (t.transform.position.x < -19.2f)
            {
                t.transform.position = new Vector3(0f, 0, 10f);
            }
        } else
        {
            t.Translate(-speed * Time.deltaTime * 0.5f, 0, 0);
           // Time.timeScale += Time.deltaTime * difficulty * 0.002f;
            if (t.transform.position.x < -19.2f)
            {
                t.transform.position = new Vector3(0f, 0, 10f);
            }
        }
    }
}
