using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BottoneRestart : MonoBehaviour
{
     public void OnButtonPress()
        {
            RestartGame();
        }
public void RestartGame() 
            {
             SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
}
