using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void MainMenu() {
        SceneManager.LoadScene("StartScreen");
    }

    public void Restart() {
        SceneManager.LoadScene("GameScreen");
    }
}
