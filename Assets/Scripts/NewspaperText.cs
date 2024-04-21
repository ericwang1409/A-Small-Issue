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

    void Start()
    {
        print("started");
        RefreshNewspaper();
    }

    public static NewspaperText Instance { get; private set; }

    private void Awake() 
    {
        Instance = this;
    }
    // Start is called before the first frame update
    public void RefreshNewspaper()
    {
        Debug.Log("refreshing newspaper");
        if (DayTracker.Instance.Day == 0)
        {
            title1.text = "NEW AI DEVELOPMENTS @ LAB";
            title2.text = "HACKATHON @ DARTMOUTH";
            title3.text = "CONSIDER A COFFEE";
            headline.text = "HELP WANTED: AI LAB, APPLY ON YOUR COMPUTER AT HOME";
        }
        else if (DayTracker.Instance.Day == 1 | DayTracker.Instance.Day == 2)
        {
            title1.text ="WHISPERS OF ROGUE AI @ LAB";
            title2.text = "CODED BY ERIC, COLE, RYAN";
            title3.text = "SUPPORT YOUR LOCAL LIBRARY";
            headline.text = "NEW HIRE: AI LABS PICK NEWBIE";
        }
        else if (DayTracker.Instance.Day == 3)
        {
            title1.text = "LEAKS OF UNSAFE AI REPORTED BY CIA";
            title2.text = "DEVELOPED IN UNITY";
            title3.text = "DOWNLOAD A VPN";
            headline.text = "MYSTERIOUS MAN SPOTTED IN TOWN: WHO DOES HE WORK FOR?";
        }
        else if (DayTracker.Instance.Day == 4)
        {
            title1.text = "THE END IS NIGH";
            title2.text = "04/20/2024";
            title3.text = "SUPPORT AI SAFETY MEASURES";
            headline.text = "ROGUE AI ENDS WORLD?";
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

