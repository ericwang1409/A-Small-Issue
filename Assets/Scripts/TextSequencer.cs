using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextSequencer : MonoBehaviour
{
    public Text displayText; 
    public string[] lines;  
    public float displayTime = 12.0f; 
    public float fadeTime = 3.5f; 

    public void StartTextSequence()
    {
        StartCoroutine(SequenceText());
    }

    public IEnumerator SequenceText()
    {
        foreach (string line in lines)
        {
            displayText.text = line; 
            displayText.color = new Color(displayText.color.r, displayText.color.g, displayText.color.b, 1);

            yield return new WaitForSeconds(displayTime);


            float elapsedTime = 0;
            while (elapsedTime < fadeTime)
            {
                elapsedTime += Time.deltaTime;
                float alpha = Mathf.Lerp(1, 0, elapsedTime / fadeTime);
                displayText.color = new Color(displayText.color.r, displayText.color.g, displayText.color.b, alpha);
                yield return null;
            }

            displayText.text = ""; 

            yield return new WaitForSeconds(1.5f);
        }

        // can do after all text displayed maybe back to main menu
    }
}

