using UnityEngine;

public class InputManager : MonoBehaviour
{

    private Vector2 startPos;
    private Vector2 endPos;
    private InputType touchInput;

    /// <summary>
    /// TouchListener: Use method in the update loop to listen for touch events.
    /// </summary>
    /// <param name="direction">out parameter for swipe direction</param>
    /// <param name="touchPoint">out parameter for initial point</param>
    /// <param name="input">out parameter for kind of touch</param>
    /// <returns>boolean for whether a valid touch event was fired.</returns>
    public bool TouchListener(out TouchCommand command)
    {
        bool output = false;

        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);

            switch (t.phase)
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
                        if (lengthOfSwipe.magnitude > 40)
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

        switch (touchInput)
        {
            default:
            case InputType.IDLE:
                {
                    command = new TouchCommand(Direction.INVALID, Vector2.zero, InputType.IDLE);
                    output = false;
                    break;
                }
            case InputType.SWIPE:
                {
                    command = new TouchCommand(DirectionFromVector(endPos - startPos), startPos, InputType.SWIPE);
                    output = true;
                    break;
                }
            case InputType.TOUCH:
                {
                    command = new TouchCommand(Direction.INVALID, startPos, InputType.TOUCH);
                    output = true;
                    break;
                }
        }
        touchInput = InputType.IDLE;
        return output;
    }

    /// <summary>
    /// Converts Vector2 into direction for raycast
    /// </summary>
    /// <param name="direction"></param>
    /// <returns></returns>
    private Direction DirectionFromVector(Vector2 direction)
    {
        Direction d = Direction.INVALID;
        if (direction.x > 0 && direction.y > 0)
        {
            d = Direction.FORWARD;
        }
        if (direction.x < 0 && direction.y < 0)
        {
            d = Direction.BACKWARD;
        }
        if (direction.x > 0 && direction.y < 0)
        {
            d = Direction.RIGHT;
        }
        if (direction.x < 0 && direction.y > 0)
        {
            d = Direction.LEFT;
        }
        return d;
    }
}

/// <summary>
/// Encapsulates the touch behavior into a command object that is passed into the character classes
/// </summary>
public class TouchCommand
{
    public Direction direction
    {
        get; set;
    }
    public Vector2 touchPoint
    {
        get; set;
    }
    public InputType inputType
    {
        get; set;
    }

    /// <summary>
    /// Create the touch command you desire with this constructor.
    /// </summary>
    /// <param name="direction"></param>
    /// <param name="touchPoint"></param>
    /// <param name="touchInput"></param>
    public TouchCommand(Direction direction, Vector2 touchPoint, InputType touchInput)
    {
        this.direction = direction;
        this.touchPoint = touchPoint;
        this.inputType = touchInput;
    }
}
