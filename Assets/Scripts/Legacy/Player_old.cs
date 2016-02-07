using UnityEngine;
using System.Collections;

public class Player_old: MonoBehaviour
{

    private NavMeshAgent agent;
    private Vector2 startPos = Vector2.zero;
    private Vector2 endPos = Vector2.zero;

    public bool HasJustTeleported { get; set; }

    private InputType touchInput; 

    // Use this for initialization
    void Start()
    {
        HasJustTeleported = false;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
        swipeCalculator();
        switch (touchInput)
        {
            case InputType.IDLE:
                {
                    print("Listening for touch");
                    break;
                }
            case InputType.TOUCH:
                {
                    print("You touched");
                    break;
                }
            case InputType.SWIPE:
                {
                    print("You swiped");
                    Vector3 rayCastDirection = getRayCastDirection(endPos - startPos);
                    movePlayerToLocation(rayCastDirection);
                    break;
                }
        }
        touchInput = InputType.IDLE;
    }

    /// <summary>
    /// Calculates whether input is swipe or not.
    /// </summary>
    private void swipeCalculator()
    {
        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);

            switch(t.phase)
            {
                case TouchPhase.Began:
                    {
                        startPos = t.position;
                        break;
                    }
                case TouchPhase.Ended:
                    {
                        endPos = t.position;
                        Vector2 lengthOfSwipe = endPos - startPos;
                        if(lengthOfSwipe.magnitude > 90)
                        {
                            touchInput = InputType.SWIPE;
                        }
                        else
                        {
                            touchInput = InputType.TOUCH;
                        }
                        break;
                    }
            }
        }

    }

    private void movePlayerToLocation(Vector3 direction)
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, direction);
        bool hasHit = Physics.Raycast(transform.position, direction, out hit, 900);
        if(hasHit)
        {
            agent.SetDestination(hit.transform.gameObject.GetComponent<Tile>().getTileLocation());
        }
    }

    private Vector3 getRayCastDirection(Vector2 direction)
    {
        float angle = Vector2.Angle(Vector2.left, direction);
        Vector3 cross = Vector3.Cross(Vector2.left, direction);
        if(cross.z>0)
        {
            angle = -angle;
        }
        if (angle>80 && angle<100)
        {
            return new Vector3(0, 1, 0);
        }
        if (angle<-80 && angle>-100)
        {
            return new Vector3(0, -1, 0);
        }
        if (direction.x>0 && direction.y>0)
        {
            return new Vector3(1, 0, 0);
        }
        if(direction.x<0 && direction.y<0)
        {
            return new Vector3(-1, 0, 0);
        }
        if(direction.x>0 && direction.y<0)
        {
            return new Vector3(0, 0, -1);
        }
        if(direction.x<0 && direction.y > 0)
        {
            return new Vector3(0, 0, 1);
        }

        return new Vector3(0, 0, 0);
    }

    private void lerp(Vector3 start, Vector3 end, GameObject target, Time startTime, float speed)
    {

    }
}