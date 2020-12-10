using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float timeToLose = 30.0f;
    private float currentGameTime;

    private CharacterController character;
    
    private bool itsOverPal;

    private void Update()
    {
        currentGameTime += Time.deltaTime;

        if (currentGameTime >= timeToLose && !itsOverPal)
        {
            GameOver();
        }

        /*if (!character.isAlive())
        {
            GameOver();
        }
        */
    }

    public void GameOver()
    {
        itsOverPal = true;
        
        Debug.Log("perdi");
    }

    public void Victory()
    {
        itsOverPal = false;
        Debug.Log("gane");
    }
}
