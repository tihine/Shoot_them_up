using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private Engines engine;
    [SerializeField] private BulletGun bullet;
    private float x;
    private float y;

    // Update is called once per frame
    void Update()
    {
        y = Input.GetAxis("Vertical");
        x = Input.GetAxis("Horizontal");
        engine.SetSpeed(new Vector2(x,y));
        if(Input.GetKey(KeyCode.Space))
        {
            bullet.Fire();
        }
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            GameManager.instance.ChangeShootMode();
        }
    }
}
