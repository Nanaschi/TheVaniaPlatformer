using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] float slowMoFactor = 0.2f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Touched the exit!");
        StartCoroutine(LoadNextScene());
    }

    IEnumerator LoadNextScene()
    {
        Time.timeScale = slowMoFactor;
        yield return new WaitForSeconds(levelLoadDelay);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
