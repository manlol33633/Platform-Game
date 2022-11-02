using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsBtn : MonoBehaviour
{
    public void GoToOptions() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("OptionsScreen");
    }
}
