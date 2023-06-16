using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerDMG : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager gameManager;
    public Text time;
    public static float countdown =9999;
    float timer = 0;
    void Start()
    {
        //time.text = "10";
    }


    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        if (timer > 1f)
           {
           timer = 0;
           if (countdown > -1)
           {
           countdown--;
                time.text =  countdown.ToString();
                }
            else
                {
                if (EnemyController.isDead)
                {
                    Data.isComplete = true;
                    Data.isGameOver = true;
                    //gameManager.GameOver();
                    gameManager.board.enabled = false;
                }
                else
                {
                    gameManager.NewGame();
                }
               
            }
            }
    }
 
}
