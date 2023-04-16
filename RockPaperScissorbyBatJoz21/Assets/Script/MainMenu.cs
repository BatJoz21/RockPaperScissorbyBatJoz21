using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject optionsMenu;

    public void Play()
    {
        SceneManager.LoadScene("Battle");
    }

    public void Option()
    {
        optionsMenu.SetActive(true);
    }

    public void exitOption()
    {
        optionsMenu.SetActive(false);
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
