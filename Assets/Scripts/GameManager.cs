using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class GameManager : MonoBehaviour
{




    [Header("Gameplay References")]
    public UIManager uIManager;
    public GameObject ballPrefab;
    public GameObject ballPoint;
    public GameObject leftFlipper;
    public GameObject rightFlipper;

    public bool gameOver;

    [Header("Gameplay Config")]
    public float torqueForce;
    public int scoreToIncreaseDifficulty = 10;
    public float targetAliveTime = 20;
    public float targetAliveTimeDecreaseValue = 2;
    public int minTargetAliveTime = 3;
    public int scoreToAddedBall = 15;

    private List<GameObject> listBall = new List<GameObject>();
    private Rigidbody2D leftFlipperRigid;
    private Rigidbody2D rightFlipperRigid;

    // Use this for initialization
    void Start()
    {
        leftFlipperRigid = leftFlipper.GetComponent<Rigidbody2D>();
        rightFlipperRigid = rightFlipper.GetComponent<Rigidbody2D>();
        if (!UIManager.firstLoad)
        {
            CreateBall();
        }
    }
	
    // Update is called once per frame
    void Update()
    {
        if (!gameOver && !UIManager.firstLoad)
        {
            if (Input.GetMouseButtonDown(0))
            {
               // SoundManager.Instance.PlaySound(SoundManager.Instance.flipping);
                Vector3 mouseInput = Input.mousePosition;
                //Flipping right
                if (mouseInput.x >= Screen.width / 2f)
                {
                    AddTorque(rightFlipperRigid, -torqueForce);
                }

                //Flipping left
                if (mouseInput.x < Screen.width / 2f)
                {
                    AddTorque(leftFlipperRigid, torqueForce);
                }
            }
            else if (Input.GetMouseButton(0))
            {
                Vector3 mouseHolding = Input.mousePosition;

                //Holding right
                if (mouseHolding.x >= Screen.width / 2f)
                {
                    AddTorque(rightFlipperRigid, -torqueForce);
                }

                //Holdding left
                if (mouseHolding.x < Screen.width / 2f)
                {
                    AddTorque(leftFlipperRigid, torqueForce);
                }
            }
        }
    }


    void AddTorque(Rigidbody2D rigid, float force)
    {
        rigid.AddTorque(force);
    }

    /// <summary>
    /// Create a ball
    /// </summary>
    public void CreateBall()
    {
        GameObject ball = Instantiate(ballPrefab, ballPoint.transform.position, Quaternion.identity) as GameObject;
        listBall.Add(ball);
    }
}
