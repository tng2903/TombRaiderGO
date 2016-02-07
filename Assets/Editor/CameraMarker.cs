using UnityEngine;
using UnityEditor;
using System.Collections;

public class CameraMarker : MonoBehaviour
{
    private static int count = 1;

    [MenuItem("Tools/Camera/Create Camera Marker %#c")]
    private static void createCameraMarker()
    {
        Transform editorCamera = SceneView.lastActiveSceneView.camera.transform;
        GameObject GO = new GameObject("CameraTarget " + (count++));
        GO.transform.position = editorCamera.position;
        GO.transform.rotation = editorCamera.rotation;
        GameObject.Find("Managers").GetComponent<CameraManager>().AddToCameras(GO);
    }
    [MenuItem("Tools/GameObjects/Group Objects %#g")]
    private static void groupUnderParent()
    {
        GameObject newParent = new GameObject("Tile Group");
        foreach (GameObject GO in Selection.gameObjects)
        {
            GO.transform.parent = newParent.transform;
        }
    }
}
