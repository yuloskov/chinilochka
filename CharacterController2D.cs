using UnityEngine;
public abstract class CharacterController2D : MonoBehaviour
{ 
    private CharacterController _controller;

    protected virtual void Start()
    {
        _controller = GetComponent<CharacterController>();
    }
    
    protected void Move(float h, float v, float speed)
    {
        Vector2 move = new Vector2(h, v);
        _controller.Move(move * Time.deltaTime * speed);
    }
    
}