using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Rigidbody2D rb;
    public ParticleSystem ps;
    public float upSpeed;

    private ParticleSystem.EmissionModule em;


    public bool isPlaying = false;

    //Start is called before the first frame update
    void Start()
    {
        em = ps.emission;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            if (Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(new Vector2(0, upSpeed * (Time.timeScale)));
                transform.localEulerAngles = new Vector3(0, 0, -15);
                em.enabled = true;
            }
            else
            {
                transform.localEulerAngles = new Vector3(0, 0, 0);
                em.enabled = false;
            }
        } else
        {
            gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            transform.localEulerAngles = new Vector3(0, 0, -5);
            transform.position = Vector3.zero;
        }  
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            isPlaying = false;
            playButton.SetActive(true);
            Time.timeScale = 1;
        }
    }
    public GameObject playButton;
    public void SetUpGame()
    {
        isPlaying = true;
        playButton.SetActive(false);
       
    }
}

