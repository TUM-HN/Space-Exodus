using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused;

    public GameObject pauseMenuUI;

    public GameObject player;


    private void Start()
    {
        GameIsPaused = false;
    }
    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();

        if (OVRInput.GetDown(OVRInput.Button.One)) {
            if (GameIsPaused) { Resume(); }
            else { Pause(); }
        }
    }

    public void Resume() {

        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        AudioListener.pause = false;
        GameIsPaused = false;
        
    }

    public void Pause()
    {
        //Set Canvas position always in front of the player
        gameObject.transform.position = (player.transform.forward * 1.5f) + player.transform.position;
        //transform.LookAt(player.transform);
        gameObject.transform.rotation = player.transform.rotation;

        //Show the Pause Menu and stop the time
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        AudioListener.pause = true;
        GameIsPaused = true;

        PlayerPrefs.Save();

    }

    public async void QuitGame()
    {
        GameIsPaused = false;
        AudioListener.pause = false;


        AudioManager.instance.Play("EndGame");
        await Task.Delay(500);
        PlayerPrefs.Save();
        Application.Quit();
    }

    public void LoadMenu(int sceneID) {
        GameIsPaused = false;
        AudioListener.pause = false;
        Time.timeScale = 1f;
        PlayerPrefs.Save();

        SceneManager.LoadScene(sceneID);
    }
}
