using UnityEngine;
using UnityEditor;
using System.Collections;


/// <summary>
/// Simple extension to the unity editor, allowing you to spawn camera markers which the camera can lerp to easily.
/// Also has a shortcut for grouping objects under a single parent. They can still be treated as global since the parent sits at origin.
/// </summary>
public class CameraMarker : MonoBehaviour
{

    [MenuItem("Tools/Camera/Create Camera Marker %#c")]
    private static void createCameraMarker()
    {
        Transform editorCamera = SceneView.lastActiveSceneView.camera.transform;
        GameObject GO = new GameObject("CameraTarget");
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
