using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsBtn : MonoBehaviour
{
    public void GoToInstructions() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("InstructionsScreen");
    }
}
