using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        Application.LoadLevel("LaunchScreen");
    }
}
