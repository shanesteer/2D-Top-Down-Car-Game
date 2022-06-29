using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Public or private reference
    // Data type (int, float,bool, string)
    // Every value has a name (Add underscores to private names so its easier to identify privates)
    // Optional value assign (if you want to keep private but make public)
    /*public float speed = 3.5f; (Speed value adjustable in inspector)*/
    /*private float speed = 3.5f; (Speed value not adjustable in inspector)*/
    [SerializeField] // Allows values of private to be adjustable in inspector
    private float _speed = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        //take the current position = new position (0, 0, 0)
        transform.position = new Vector3(0, 0, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // new Vector3(1, 0, 0) * 0 * 3.5 * real time
        // Left right
        transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
        // Forward back
        transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);

        /*// Optimal way of moving^^^
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(direction * _speed * Time.deltaTime);*/
    }
}
