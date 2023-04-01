using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//场景
public class change : MonoBehaviour
{
    public void Parkour()
    {
        SceneManager.LoadScene("Parkour");
    }
    public void Home()
    {
        SceneManager.LoadScene("Home");
    }
    public void Drugstore()
    {
        SceneManager.LoadScene("Drugstore");
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}

