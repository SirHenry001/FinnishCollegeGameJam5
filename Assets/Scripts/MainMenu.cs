using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject StartButton;
    public GameObject settingsButton;
    // Start is called before the first frame update

    private void Start()
    {
        AudioManager.instance.PlayMusicFX(0);
    }

    public void StartGame(int index)
    {
        
        StartCoroutine(StartGameDelay(index));
    }

    IEnumerator StartGameDelay(int index)
    {
        //��ni
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(index);
        StateManager.instance.levelActive = true;
    }

    public void Quit()
    {
        Application.Quit();
    }

}
