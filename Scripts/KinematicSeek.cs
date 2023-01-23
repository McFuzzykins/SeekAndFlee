using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicSeek : MonoBehaviour
{
    public Transform character;
    public Transform target;

    public float maxSpeed;

    public KinematicSteeringOutput getSteering()
    {
        KinematicSteeringOutput result = new KinematicSteeringOutput();

        if (character.tag == "Seek")
        {
            result.velocity = target.position - character.position;
        }
        else if (character.tag == "Flee")
        {
            result.velocity = character.position - target.position;
        }
        

        result.velocity.Normalize();
        result.velocity *= maxSpeed;

        float targetAngle = newOrientation(character.rotation.eulerAngles.y, result.velocity);
        character.eulerAngles = new Vector3(0, targetAngle, 0);
        result.rotation = 0;

        return result;
    }

    private float newOrientation(float current, Vector3 velocity)
    {
        if (velocity.magnitude > 0)
        {
            float targetAngle = Mathf.Atan2(velocity.x, velocity.z);
            targetAngle *= Mathf.Rad2Deg;

            return targetAngle;
        }
        else
        {
            return current;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        getSteering();
    }
}
