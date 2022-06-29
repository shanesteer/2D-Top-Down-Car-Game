using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car2DController : MonoBehaviour
{
    float speedforce = 40f;
    float tourqueforce = -80f;
    float driftfactorStick = 0.5f;
    float driftfactorSlip = 0.9f;
    float maxstickVelocity = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        float driftFactor = driftfactorStick;

        //When the turning velocity is more than the tire stciking velocity, the car starts to skid
        if(RightVelocity().magnitude > maxstickVelocity)
        {
            driftFactor = driftfactorSlip;
        }

        rb.velocity = ForwardVelocity() + RightVelocity() * driftfactorSlip;

        if (Input.GetButton("Accelerate"))
        {
            rb.AddForce(transform.up * speedforce);
        }

        if (Input.GetButton("Brakes"))
        {
            rb.AddForce(transform.up * -speedforce / 2f);
        }

        //Ensures that the car is not able to move left and right when it is still
        float tF = Mathf.Lerp(0, tourqueforce, rb.velocity.magnitude / 2);

        rb.angularVelocity = Input.GetAxis("Horizontal") * tF;
 

    }

    //velocity for moving forward
    Vector2 ForwardVelocity() {
        return transform.up * Vector2.Dot(GetComponent<Rigidbody2D>().velocity, transform.up);
    }

    //velocity for turning
    Vector2 RightVelocity()
    {
        return transform.right * Vector2.Dot(GetComponent<Rigidbody2D>().velocity, transform.right);
    }

}
