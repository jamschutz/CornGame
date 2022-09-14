using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle3 : MonoBehaviour
{
    public float restPosition = 0;
    public float pressedPosition = 45f;
    public float hitStrength = 10000;
    public float flipperDamper = 150;

    HingeJoint2D hinge;


    void Start()
    {
        hinge = GetComponent<HingeJoint2D>();
    }


    void Update()
    {
        float targetForce = hinge.referenceAngle - hinge.jointAngle;

        if(Input.GetKey(KeyCode.Space)) {

        }
    }
}
