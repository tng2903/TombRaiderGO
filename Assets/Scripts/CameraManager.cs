using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CameraManager : MonoBehaviour
{
    public GameObject[] cameras;

    public void AddToCameras(GameObject newCamera)
    {
        List<GameObject> temp = new List<GameObject>(cameras);
        temp.Add(newCamera);
        cameras = temp.ToArray();
    }

    public IEnumerator CameraLerp(Vector3 destinationLocation, Quaternion destinationRotation, float time)
    {
        print("Camera lerp called");
        float elapsedTime = 0;
        Vector3 startingPos = Camera.main.transform.position;
        Quaternion startingRotation = Camera.main.transform.rotation;
        while (elapsedTime < time)
        {
            Camera.main.transform.position = Vector3.Lerp(startingPos, destinationLocation, elapsedTime / time);
            Camera.main.transform.rotation = Quaternion.Lerp(startingRotation, destinationRotation, elapsedTime / time);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        yield return null;
    }

}
