using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AchievementButton : MonoBehaviour
{
    public Character.Achievement stats;

    public Text achTitle;
    public Text achDescription;
    public Image achIcon;
    public Button b;

    public void Update()
    {
        gameObject.GetComponent<Image>().sprite = stats.icon;
        if (stats.reached)
        {
            b.interactable = true;
        }else
        {
            b.interactable = false;
        }
    }

   

    public void IGotClicked()
    {
        achTitle.text = stats.title;
        achDescription.text = stats.description;
        achIcon.sprite = stats.icon;
    }


}
