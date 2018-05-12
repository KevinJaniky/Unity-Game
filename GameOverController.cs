using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour {

    void OnGUI()
    {
        const int buttonWidth = 120;
        const int buttonHeight = 60;

        if (
          GUI.Button(
            // Centré en x, 1/3 en y
            new Rect(
              Screen.width / 2 - (buttonWidth / 2),
              (1 * Screen.height / 3) - (buttonHeight / 2),
              buttonWidth,
              buttonHeight
            ),
            "Retry!"
          )
        )
        {
            // Recharge le niveau
            SceneManager.LoadScene("SampleScene");
        }

        if (
          GUI.Button(
            // Centré en x, 2/3 en y
            new Rect(
              Screen.width / 2 - (buttonWidth / 2),
              (2 * Screen.height / 3) - (buttonHeight / 2),
              buttonWidth,
              buttonHeight
            ),
            "Back to menu"
          )
        )
        {
            // Retourne au menu
            SceneManager.LoadScene("Menu");
        }
    }
}
