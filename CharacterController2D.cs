using UnityEngine;
public abstract class CharacterController2D : MonoBehaviour
{ 
    private CharacterController _controller;
    
    protected Transform pos;
    [SerializeField]
    public float speed;

    protected virtual void Start()
    {
        _controller = GetComponent<CharacterController>();
        pos = GetComponent<Transform>();
    }
    
    protected void Move(float h, float v, float speed)
    {
        Vector2 move = new Vector2(h, v);
        _controller.Move(move * Time.deltaTime * speed);
    }

    public bool MoveTo(Transform to, float r)
    {
        var thisPosition = pos.position;
        var xCur = thisPosition.x;
        var yCur = thisPosition.y;

        var toPosition = to.position;
        var xTo = toPosition.x;
        var yTo = toPosition.y;

        var moveVector = new Vector2(-xCur + xTo, -yCur + yTo).normalized;

        Move(moveVector.x, moveVector.y, speed);

        var dist = Vector3.Distance(thisPosition, toPosition);

        return (dist < r);
    }
    
}