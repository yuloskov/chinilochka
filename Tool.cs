using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.AddToolToList(this);
    }

    public Vector3 getPosition()
    {
        return transform.position;
    }
    
}