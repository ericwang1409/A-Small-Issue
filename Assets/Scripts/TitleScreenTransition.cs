using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TitleScreenManager : MonoBehaviour
{
    public string mainGameSceneName = "PlayerHouse"; 
    public TitleCrawl titleCrawl;
    public float crawlDuration = 5f;

   
    public void OnNewGameClicked()
    {
       
        if (titleCrawl != null)
        {
            titleCrawl.StartCrawl(); 
        }
        else
        {
            Debug.LogError("TitleCrawl script not set on TitleScreenManager.");
        }
    }
}
