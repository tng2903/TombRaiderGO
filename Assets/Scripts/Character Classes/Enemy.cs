using UnityEngine;
using System.Collections;

public class Enemy : Character
{
    public override void PhaseBehavior(TouchCommand command)
    {
        ;
    }

    public void Update()
    {
        RaycastHit hit;
        if (base.RaycastInDirection(facingDirection, out hit))
        {
            //Debug.DrawRay(transform.position, hit.transform.parent.position, Color.red);
            if (hit.transform.tag == "Player")
            {
                Destroy(hit.transform.gameObject);
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

    public override void Attack(GameObject target)
    {
        Destroy(target);
    }
}
