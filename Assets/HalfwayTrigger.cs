using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfwayTrigger : MonoBehaviour
{
    public GameObject halfwayTrig;
    public GameObject lapCompleteTrig;

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            lapCompleteTrig.SetActive(true);
            halfwayTrig.SetActive(false);
        }
    }
}
