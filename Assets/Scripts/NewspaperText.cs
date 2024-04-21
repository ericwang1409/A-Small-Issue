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
        if (GameController.Instance.day == 0)
        {
            title1.text = GameController.Instance.playerName + " NEW AI DEVELOPMENTS @ LAB";
            title2.text = "HACKATHON @ DARTMOUTH";
            title3.text = "CONSIDER A COFFEE";
            headline.text = "HELP WANTED: AI LAB, APPLY ON YOUR COMPUTER AT HOME";
        }
        else if (GameController.Instance.day == 1)
        {
            title1.text = GameController.Instance.playerName + " WHISPERS OF ROGUE AI @ LAB";
            title2.text = "CODED BY ERIC, COLE, RYAN";
            title3.text = "SUPPORT YOUR LOCAL LIBRARY";
            headline.text = "NEW HIRE: AI LABS PICK " + GameController.Instance.playerName;
        }
        else if (GameController.Instance.day == 2)
        {
            title1.text = "LEAKS OF UNSAFE AI REPORTED BY CIA";
            title2.text = "DEVELOPED IN UNITY";
            title3.text = "DOWNLOAD A VPN";
            headline.text = "MYSTERIOUS MAN SPOTTED IN TOWN: WHO DOES HE WORK FOR?";
        }
        else if (GameController.Instance.day == 3)
        {
            title1.text = "THE END IS HERE";
            title2.text = "04/20/2024";
            title3.text = "SUPPORT AI SAFETY MEASURES";
            headline.text = "ROGUE AI ENDS WORLD";
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

