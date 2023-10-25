using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsFactory : MonoBehaviour
{
    public static BulletsFactory instance;
    [SerializeField] private Bullet bulletPlayerPrefab;
    [SerializeField] private Bullet bulletEnemyPrefab;
    [SerializeField] private int numberOfPlayerBulletToPreinstantiate;
    [SerializeField] private int numberOfEnemyBulletToPreinstantiate;
    private Dictionary<BulletType, Queue<Bullet>> availableBulletsType = new Dictionary<BulletType, Queue<Bullet>>();

    private void Awake()
    {
        // If there is aelete myself.
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
        foreach (object value in System.Enum.GetValues(typeof(BulletType)))
        {
            this.availableBulletsType.Add((BulletType)value, new Queue<Bullet>());
        }
    }

    private void Start()
    {
        Queue<Bullet> bulletsPlayer = availableBulletsType[BulletType.playerBullet];
        for (int index = 0; index < numberOfPlayerBulletToPreinstantiate; index++)
        {
            Bullet bullet = Instantiate(bulletPlayerPrefab);
            bullet.gameObject.SetActive(false);
            bulletsPlayer.Enqueue(bullet);
        }
        Queue<Bullet> bulletsEnemy = availableBulletsType[BulletType.enemyBullet];
        for (int index = 0; index < numberOfEnemyBulletToPreinstantiate; index++)
        {
            Bullet bulletE = Instantiate(bulletEnemyPrefab);
            bulletE.gameObject.SetActive(false);
            bulletsEnemy.Enqueue(bulletE);
        }
    }
    public Bullet GetBullet(Vector3 position,BulletType type)
    {
        Bullet bullet = null;
        Queue<Bullet> availableBullets = availableBulletsType[type];
        if (availableBullets.Count > 0)
        {
            bullet = availableBullets.Dequeue();
        }
        else
        {
            switch (type)
            {
                case BulletType.playerBullet:
                    bullet = Instantiate(bulletPlayerPrefab);
                    break;
                case BulletType.enemyBullet:
                    bullet = GameObject.Instantiate(bulletEnemyPrefab);
                    break;
            }
        }
        bullet.GetComponent<Bullet>().Init(2, GameManager.instance.shootDirection, position);
        bullet.gameObject.SetActive(true);
        return bullet;
    }
}
