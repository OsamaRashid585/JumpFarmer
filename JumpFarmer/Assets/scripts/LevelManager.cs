using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
   public void RestartGame()
    {
        SceneManager.LoadScene(0);
        Physics.gravity = new Vector3(0f, -9.8f, 0f);
    }
}
