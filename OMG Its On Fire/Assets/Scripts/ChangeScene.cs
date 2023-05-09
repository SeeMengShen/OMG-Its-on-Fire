using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string levelName;

   public void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
