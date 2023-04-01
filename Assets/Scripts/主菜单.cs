using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class 主菜单 : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Home");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
