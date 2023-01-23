using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kinematic : MonoBehaviour
{
    Vector3 velocity;
    float rotation;

    private KinematicSeek mySteering;
    public Transform myTarget;
    public float myMaxSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        mySteering = new KinematicSeek();
        mySteering.target = myTarget;
        mySteering.character = this.transform;
        mySteering.maxSpeed = myMaxSpeed;
    }

    public void KinematicUpdate(KinematicSteeringOutput steering, float time)
    {
        velocity += steering.velocity * time;
        transform.position += velocity * time;
    }

    // Update is called once per frame
    void Update()
    {
        KinematicSteeringOutput steering = mySteering.getSteering();
        KinematicUpdate(steering, Time.deltaTime);
    }
}
