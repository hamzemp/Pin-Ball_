using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperHandler : MonoBehaviour
{

    public float torqueForce;
    [SerializeField]
    private Rigidbody2D leftFlipperRigid;
    [SerializeField]
    private Rigidbody2D rightFlipperRigid;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
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
    void AddTorque(Rigidbody2D rigid, float force)
    {
        rigid.AddTorque(force);
    }
  
}
