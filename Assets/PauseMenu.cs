using System.Collections;
using System.Collections.Generic;
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
        GameIsPaused = true;

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadMenu(int sceneID) {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
    }

    private IEnumerator coroutine()
    {
        yield return new WaitForSeconds(0.5f);
     }

}
