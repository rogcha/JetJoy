using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Character : MonoBehaviour {

    public Rigidbody2D rb;
    public ParticleSystem ps;
    public float upSpeeed;

    private ParticleSystem.EmissionModule em;
    public float score = 0;
    public Text scoreText;
    public bool isPlaying = false;

    
    public List<Achievement> achList = new List<Achievement>();

	void Start ()
    {
        em = ps.emission;
	}


    public GameObject achPanel;
	public Image sprRep;
    public Text achTitle;
    public Text achDescription;

	void Update ()
    {
        if (isPlaying)
        {

            foreach (Achievement ach in achList)
            {
                if (score > ach.threshold && ach.reached == false)
                {
                    achPanel.GetComponent<Image>().color = new Color(216, 255, 248, 245);
                    sprRep.sprite = ach.icon;
                    achTitle.text = ach.title;
                    achDescription.text = ach.description;

                }
            }

            if (achPanel.GetComponent<Image>().color.a > 0)
            {
                achPanel.GetComponent<Image>().color = new Color(216, 255, 248, achPanel.GetComponent<Image>().color.a - 100 * Time.deltaTime);
            }

            score += Time.deltaTime * 5f;
            scoreText.text = Mathf.RoundToInt(score).ToString();
            gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            if (Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(new Vector2(0, upSpeeed * (Time.timeScale)));
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
            score = 0;
            scoreText.text = "0";
        }
		
	}
    
   private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "obstacle")
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

    [System.Serializable]

    public class Achievement
    {
        public Sprite icon;
        public string title;
        public string description;
        public int threshold;
        public bool reached = false;

    }
}
