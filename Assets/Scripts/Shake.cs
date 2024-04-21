using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraShaker : MonoBehaviour
{
    public AnimationCurve curve;
    public float duration = 1f;
    public Image fadeImage;
    private bool isShaking = false;

    public GameObject dialogueText;

    public TextSequencer textSequencer;
    public void StartShaking()
    {
        if (!isShaking)
        {
            StartCoroutine(Shaking());

        }
    }

    IEnumerator Shaking()
    {
        Vector3 startPosition = transform.localPosition;
        float elapsedTime = 0f;

        isShaking = true;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime / duration);
            transform.localPosition = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }

        transform.localPosition = startPosition;
        isShaking = false;
        StartCoroutine(FadeToBlack());
        dialogueText.SetActive(false);
    }
    IEnumerator FadeToBlack()
    {
        float fadeTime = 3f;  
        float startAlpha = 0f;
        float endAlpha = 1f;
        float elapsedTime = 0f;

        AudioManager.i.PlayDailyMusic();

        //Debug.Log("Starting Fade to Black");

        if (!fadeImage.gameObject.activeInHierarchy)
    {
        fadeImage.gameObject.SetActive(true);
    }

        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeTime);
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, newAlpha);
            yield return null;
        }
        yield return new WaitForSeconds(1.0f);

        textSequencer.StartTextSequence();
        
    }
}

