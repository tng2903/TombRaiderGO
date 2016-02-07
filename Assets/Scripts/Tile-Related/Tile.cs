using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour
{
    public GameObject occupiedBy = null;
    public Direction direction;

    public void Start()
    {
        if(occupiedBy!=null)
        {
            Vector3 spawnPoint = getTileLocation();
            spawnPoint.y += transform.GetComponent<MeshRenderer>().bounds.extents.y;
            GameObject spawned = (GameObject) Instantiate(occupiedBy, spawnPoint, occupiedBy.transform.rotation);
            spawned.GetComponent<Character>().SetCharacterDirection(direction);
            spawned.GetComponent<Character>().facingDirection = direction;
        }
    }

    public Vector3 getTileLocation()
    {
        NavMeshHit hit;
        bool found = NavMesh.SamplePosition(this.transform.position, out hit, 2,1);
        if (found)
        {
            return hit.position;
        }
        else
        {
            return new Vector3();
        }
    }

}
