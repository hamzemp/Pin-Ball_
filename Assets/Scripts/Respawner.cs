using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    public GameManager gameManager;


    [SerializeField]
    Transform startPos;

    private void Start()
    {
        
    }
   void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            gameManager.CreateBall();
        }
    }
}
