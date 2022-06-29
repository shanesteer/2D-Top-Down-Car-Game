using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICarController : MonoBehaviour
{
    public Transform path;
    public float maxSteerAngle = 2f;

    private List<Transform> nodes;
    private int currentNode = 0;
    public float maxSpeed = 20f;
    public float maxBrackingSpeed = -10f;
    public bool isBracking = false;
    private float sensorLength = 3f;
    private float frontSensorPosition = 5f;
 


    // Start is called before the first frame update
    void Start()
    {
        Transform[] pathTransforms = path.GetComponentsInChildren<Transform>();

        nodes = new List<Transform>();

        for (int i = 0; i < pathTransforms.Length; i++)
        {
            if (pathTransforms[i] != path.transform)
            {
                nodes.Add(pathTransforms[i]);
            }
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Drive();
        Steering();
        carSensing();
        checkPathwayDistance();
        Bracking();

    }


    private void Drive()
    {
        //keeps adding force until the car reaches max speed
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        rb.AddForce(transform.up * maxSpeed);

    }

    private void Bracking()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        //if the isBracking variable is true, the car slows down
        if (isBracking == true)
        {
            rb.AddForce(transform.up * maxBrackingSpeed / 2);
        }
    }

    private void Steering()
    {
        /*Vector3 relativeVector = transform.InverseTransformPoint(nodes[currentNode].position);
        float newSteer = (relativeVector.x / relativeVector.magnitude) * maxSteerAngle;
        
        relativeVector = relativeVector / relativeVector.magnitude;*/


        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        Transform pathway = nodes[currentNode];
        //direction of the pathway
        Vector2 dir = pathway.position - transform.position;
        dir = dir.normalized;

        //targer angle is the angle you need to be facing the pathway
        float targetAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        rb.rotation = targetAngle - 90f;



    }

    private void carSensing()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        
        Vector3 sensorPositionStart = transform.position;
        sensorPositionStart.z += frontSensorPosition;

        //raycast is used to detect objects and barriers
        RaycastHit2D collide = Physics2D.Raycast(transform.position, transform.up, sensorLength);
        RaycastHit2D collide1 = Physics2D.Raycast(transform.position + new Vector3(0.7f, 0f, 0f), transform.up, sensorLength - 1f);

        //if the car collides witha barrier or object, it slows down
        if (collide.collider != null)
        {
            Debug.DrawLine(sensorPositionStart + transform.up * 1.5f, collide.point);
            isBracking = true;
        }

        if(collide1.collider != null)
        {
            print("right collision");
            Debug.DrawLine(sensorPositionStart + transform.up * 1.5f, collide.point);
            isBracking = true;
        }

        else
        {
            isBracking = false;
        }

    }


    private void checkPathwayDistance()
    {
        if(Vector3.Distance(transform.position, nodes[currentNode].position) < 5f)
        {
            if(currentNode == nodes.Count - 1)
            {
                currentNode = 0;
            }

            else
            {
                currentNode++;
            }
        }
    }

}
