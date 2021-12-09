using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderScript : MonoBehaviour
{
    public void LoadNextScene(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadControll(){
        SceneManager.LoadScene(3);
    }

    public void LoadMainMenu(){
        SceneManager.LoadScene(0);
    }

    

    public void QuitGame(){
        Application.Quit();
    }
}
