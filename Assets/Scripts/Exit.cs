using UnityEngine;
using System.Collections;


/// <summary>
/// Attach script to end of level. Needs to be updated to support 
/// 1. Next level
/// 2. Level select
/// </summary>
public class Exit : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        Application.LoadLevel("LaunchScreen");
    }
}
