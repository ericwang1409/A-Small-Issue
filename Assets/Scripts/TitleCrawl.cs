using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class TitleCrawl : MonoBehaviour
{
    public GameObject titleImage;        
    public GameObject crawlBackground;   
    public TextMeshProUGUI crawlText;   
    public string fullText = "A long time ago, in a galaxy far, far away...";
    public float letterPause = 0.2f;
    public string mainGameSceneName = "PlayerHouse";


    public void StartCrawl()
    {
        titleImage.SetActive(false);            
        crawlBackground.SetActive(true);        
        crawlText.gameObject.SetActive(true);   
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        crawlText.text = ""; 
        foreach (char letter in fullText.ToCharArray())
        {
            crawlText.text += letter; 
            yield return new WaitForSeconds(letterPause);
        }
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(mainGameSceneName); 
    }
}
