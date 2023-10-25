using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletType
{
    enemyBullet,
    playerBullet,
}

public abstract class Bullet : MonoBehaviour
{
    float Damage;
    [SerializeField] Vector2 Speed;
    Vector2 Position;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] protected BulletType type;
    

    public virtual void Init(float damage, Vector2 speed, Vector2 position)
    {
        Damage = damage;
        Speed = speed;
        Position = position;
        this.transform.position = position;
    }
    public virtual void UpdatePosition() 
    {
        Vector3 newSpeed = new Vector3(Speed.x, Speed.y,0);
        bulletPrefab.transform.position += newSpeed* Time.deltaTime;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (type == BulletType.playerBullet && collision.tag=="Enemy")
        {
            collision.GetComponent<BaseAvatar>().TakeDamage(Damage);
            Destroy(bulletPrefab);
            collision.GetComponent<BaseAvatar>().Die();
        }
        else if (type == BulletType.enemyBullet && collision.tag == "Player")
        {
            collision.GetComponent<PlayerAvatar>().TakeDamage(Damage);
            Destroy(bulletPrefab);
            collision.GetComponent<BaseAvatar>().Die();
        }

    }
    private void OnBecameInvisible()
    {
        Destroy(bulletPrefab);
    }

}
