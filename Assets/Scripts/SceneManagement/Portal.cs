using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour, IPlayerTriggerable
{
    [SerializeField] int sceneToLoad = -1;
    [SerializeField] DestinationID destinationPortal;
    [SerializeField] Transform spawnPoint;
    private PlayerController player;
    public void OnPlayerTriggered(PlayerController player)
    {
        this.player = player;
        StartCoroutine(SwitchScene());
    }
    IEnumerator SwitchScene() {
        transform.SetParent(null);
        DontDestroyOnLoad(gameObject);

        GameController.Instance.PauseGame(true);

        yield return SceneManager.LoadSceneAsync(sceneToLoad);

        var destPortal = FindObjectsOfType<Portal>().First(x => x != this && x.destinationPortal == this.destinationPortal);
        player.Character.SetPositionAndSnapToTile(destPortal.SpawnPoint.position);
        player.transform.position = destPortal.SpawnPoint.position;

        GameController.Instance.PauseGame(false);
        DayTracker.Instance.InstantiateAgain();

        Destroy(gameObject);
    }

    public Transform SpawnPoint => spawnPoint;
}

public enum DestinationID {A, B, C, D, E, F, G}
