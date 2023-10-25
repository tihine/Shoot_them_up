using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engines : MonoBehaviour
{
    [SerializeField] float MaxSpeed;
    public Vector2 Speed;
    Transform transform;
    
    void Start()
    {
        transform = GetComponent<Transform>();
        Speed = new Vector2(0, 0);
    }
    void Update()
    {
        Vector3 newSpeed = Speed;
        transform.position += newSpeed* Time.deltaTime*MaxSpeed;
    }

    public void SetSpeed(Vector2 speed)
    {
        Speed = speed;
    }
}
