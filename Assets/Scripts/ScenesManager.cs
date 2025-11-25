using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    AudioManager audioManager;
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
    }

    public void Play()
    {
        StartCoroutine(PlayAndLoad());
    }

    public void BackToMainMenu()
    {
        StartCoroutine(BackAndLoad());
    }

    IEnumerator BackAndLoad()
    {        
        audioManager.PlaySfx(audioManager.click);
        yield return new WaitForSeconds(audioManager.click.length);
        SceneManager.LoadScene(0);
    }
    IEnumerator PlayAndLoad()
    {        
        audioManager.PlaySfx(audioManager.click);
        yield return new WaitForSeconds(audioManager.click.length);
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

}
