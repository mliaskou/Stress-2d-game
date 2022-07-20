using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class HandleScenes : MonoBehaviour
{
  public void LoadMainScene()
    {

        SceneManager.LoadScene("SampleScene");
    }


    public void GameQuit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
