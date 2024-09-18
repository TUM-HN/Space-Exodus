using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * The pause menu script functions as the core controller for the pause menu, 
 * dictating the behaviors triggered by various button inputs.
 * 
 * This document primarily references the following video: 
 * https://www.youtube.com/watch?v=ROwsdftEGF0
 * https://www.youtube.com/watch?v=JivuXdrIHK0
 * 
 */

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

    // When Quit is called, bool name is set to false in case the error after reopen.
    // Playerprofs need to be saved before the application is quit!!
    public async void QuitGame()
    {
        GameIsPaused = false;
        AudioListener.pause = false;


        AudioManager.instance.Play("EndGame");
        await Task.Delay(500);
        PlayerPrefs.Save();
        Application.Quit();
    }

    // When Menu is called, bool names is set to false and time scale is recovered in case the error after reenter the game.
    public void LoadMenu(int sceneID) {
        GameIsPaused = false;
        AudioListener.pause = false;
        Time.timeScale = 1f;
        PlayerPrefs.Save();

        SceneManager.LoadScene(sceneID);
    }
}
