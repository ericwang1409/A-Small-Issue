using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewspaperText : MonoBehaviour
{
    public Text title1;
    public Text title2;
    public Text title3;
    public Text headline;
    
    public event Action OnNewspaperFinished;
    // Start is called before the first frame update
    void Start()
    {
        if (GameController.Instance.day == 1)
        {
            title1.text = GameController.Instance.playerName + " 1";
            title2.text = "1";
            title3.text = "1";
            headline.text = "1";
        }
        else if (GameController.Instance.day == 2)
        {
            title1.text = "2";
            title2.text = "2";
            title3.text = "2";
            headline.text = "2";
        }
        else if (GameController.Instance.day == 3)
        {
            title1.text = "3";
            title2.text = "3";
            title3.text = "3";
            headline.text = "3";
        }
        else if (GameController.Instance.day == 4)
        {
            title1.text = "4";
            title2.text = "4";
            title3.text = "4";
            headline.text = "4";
        }
        else if (GameController.Instance.day == 5)
        {
            title1.text = "5";
            title2.text = "5";
            title3.text = "5";
            headline.text = "5";
        }
        else if (GameController.Instance.day == 6)
        {
            title1.text = "6";
            title2.text = "6";
            title3.text = "6";
            headline.text = "6";
        }
        else if (GameController.Instance.day == 7)
        {
            title1.text = "7";
            title2.text = "7";
            title3.text = "7";
            headline.text = "7";
        }
        else if (GameController.Instance.day == 8)
        {
            title1.text = "8";
            title2.text = "8";
            title3.text = "8";
            headline.text = "8";
        }
        else if (GameController.Instance.day == 9)
        {
            title1.text = "9";
            title2.text = "9";
            title3.text = "9";
            headline.text = "9";
        }
        else 
        {
            title1.text = "10";
            title2.text = "10";
            title3.text = "10";
            headline.text = "10";
        }
    }

    // Update is called once per frame
    public void HandleUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            OnNewspaperFinished?.Invoke();
        }
    }
}
