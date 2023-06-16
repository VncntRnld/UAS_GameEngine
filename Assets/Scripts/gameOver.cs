using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class gameOver : MonoBehaviour
{

    public void startGame(int SceneID)
    {
        SceneManager.LoadScene(SceneID);
    }
}
