using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackBtn : MonoBehaviour
{
    public void GoBack() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartScreen");
    }
}
