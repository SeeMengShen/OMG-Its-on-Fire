using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public string levelName;

    public void SwitchScene()
    {
        SceneManager.LoadScene(levelName);
    }
}
