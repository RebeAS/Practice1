using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalTrigger : MonoBehaviour
{
    public float TimeToReload;
    private Collider GoalCollider;

    public AudioSource Audio;

    private void Start()
    {
        GoalCollider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerHP playerHP = other.gameObject.GetComponent<PlayerHP>();
        if (playerHP != null)
        {
            GoalCollider.enabled = false;
            Audio.Play();
            StartCoroutine(ReloadSceneCoroutine());
        }
    }

    public IEnumerator ReloadSceneCoroutine()
    {
        yield return new WaitForSeconds(TimeToReload);
        ReloadScene();
    }

    public void ReloadScene()
    {
        Debug.Log("You won!");
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextScene >= SceneManager.sceneCountInBuildSettings)
        {
            nextScene = 0;
        }

        SceneManager.LoadScene(nextScene);
    }
}
