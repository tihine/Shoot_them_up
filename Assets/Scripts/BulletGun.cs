using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletGun : MonoBehaviour
{
    float Damage;
    Vector2 Speed;
    float CooldownBullet=0.3f;
    [SerializeField] private GameObject prefabBullet;
    private float lastFunctionTime;
    private EnergyBar energyBar;

    // Start is called before the first frame update
    private void Start()
    {
        energyBar = GameManager.instance.energyBar;
        GameManager.instance.energy = 20f;
        energyBar.SetEnergy(GameManager.instance.energy);
    }
    public void Fire()
    {
        if (Time.time - lastFunctionTime >= CooldownBullet && GameManager.instance.energy >= 5f && GameManager.instance.malusEnergy==false)
        {
            //GameObject bullet = Instantiate(prefabBullet);
            //bullet.GetComponent<Bullet>().Init(2, GameManager.instance.shootDirection, this.transform.position);
            BulletsFactory.instance.GetBullet(this.transform.position, BulletType.playerBullet);
            GameManager.instance.energy -= 5f;
            energyBar.SetEnergy(GameManager.instance.energy);
            if (GameManager.instance.energy <=0)
            {
                GameManager.instance.malusEnergy = true;
            }
            lastFunctionTime = Time.time;
        }
    }

    
}
