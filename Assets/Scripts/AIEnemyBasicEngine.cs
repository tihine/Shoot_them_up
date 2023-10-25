using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemyBasicEngine : MonoBehaviour
{
    [SerializeField] private float MaxSpeed;
    [SerializeField] private GameObject gameObject;
    Transform transform;

    void Start()
    {
        transform = GetComponent<Transform>();
    }
    void Update()
    {
        transform.position += new Vector3(-1,0,0) * Time.deltaTime * MaxSpeed;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
