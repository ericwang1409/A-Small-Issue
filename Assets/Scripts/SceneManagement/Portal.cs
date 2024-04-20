using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour, IPlayerTriggerable
{
    [SerializeField] int sceneToLoad = -1;
    public void OnPlayerTriggered(PlayerController player)
    {
        StartCoroutine(SwitchScene());
    }
    IEnumerator SwitchScene() {
        yield return SceneManager.LoadSceneAsync(sceneToLoad);
    }
}
