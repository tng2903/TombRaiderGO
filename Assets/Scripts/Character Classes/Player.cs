using UnityEngine;
using System.Collections;

public class Player : Character
{
    public override void PhaseBehavior(TouchCommand command)
    {
        switch (command.inputType)
        {
            case InputType.SWIPE:
                {
                    RaycastHit hit;
                    if (base.RaycastInDirection(command.direction, out hit))
                    {
                        print(hit.transform.tag);
                        switch (hit.transform.tag)
                        {
                            case "Tile":
                                {
                                    SetCharacterDirection(command.direction);
                                    Move(hit.transform.GetComponent<Tile>().getTileLocation());
                                    break;
                                }
                            case "Enemy":
                                {
                                    SetCharacterDirection(command.direction);
                                    Attack(hit.transform.gameObject);
                                    break;
                                }
                        }
                    }

                    break;
                }
            case InputType.TOUCH:
                {
                    break;
                }
        }
    }
    public override void Attack(GameObject target)
    {
        GameObject manager = GameObject.Find("Managers");
        manager.GetComponent<GameManager>().removeFromEnemies(target);
        Destroy(target);
    }

    public override void Move(Vector3 destination)
    {
        StartCoroutine(animCoroutine(destination));
    }

    public IEnumerator animCoroutine(Vector3 destination)
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        Animator anim = GetComponent<Animator>();
        agent.SetDestination(destination);
        while(true)
        {
            anim.SetBool("Move", true);
            if (Mathf.Abs(Vector3.Distance(transform.position, destination))<=0.2 || HasJustTeleported)
            {
                anim.SetBool("Move", false);
                break;
            }
            yield return null;
        }
       
        yield return null;
    }
}
