using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBasicBulletGun : MonoBehaviour
{
    [SerializeField] private GameObject prefabBullet;
    [SerializeField] private float CoolDown;

    void Start()
    {
        //Start the coroutine we define below named ExampleCoroutine.
        StartCoroutine(FireCoroutine());
        Debug.Log("test");
    }

    IEnumerator FireCoroutine()
    {
        while (true)
        {
            Debug.Log("test2");
            GameObject bullet = Instantiate(prefabBullet);
            bullet.GetComponent<Bullet>().Init(2, new Vector2(-5, 0), this.transform.position);

            //yield on a new YieldInstruction that waits for CoolDown seconds.
            yield return new WaitForSeconds(CoolDown);
        }

    }

}
