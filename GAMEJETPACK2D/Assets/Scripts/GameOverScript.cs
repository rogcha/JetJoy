using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class GameOverScript : MonoBehaviour{

    public float TimeToLoadMenu = 5f;

    private void Start()
    {
        StartCoroutine(LoadMenu());
    }
 
            IEnumerator LoadMenu()
            {
        yield return new WaitForSeconds(TimeToLoadMenu);
        SceneManager.LoadScene("menu");
            
    }
}
