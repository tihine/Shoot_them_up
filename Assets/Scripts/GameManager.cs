using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public enum ShootMode
{
    Simple,
    Diagonal,
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public ShootMode mode;
    [SerializeField] private GameObject prefabEnemy;
    [SerializeField] private GameObject prefabPlayer;
    [SerializeField] public HealthBar healthBar;
    [SerializeField] public EnergyBar energyBar;
    [SerializeField] public float energy;
    public Vector2 shootDirection;
    public bool malusEnergy=false;
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    

    void Start()
    {
        var player = Instantiate(prefabPlayer,new Vector3(-9,0,0),Quaternion.identity);
        mode = ShootMode.Simple;
        shootDirection = new Vector2(4, 0);
        //Start the coroutine we define below named EnemiesCoroutine.
        StartCoroutine(EnemiesCoroutine());
        StartCoroutine(RestoreEnergyCoroutine());

    }

    IEnumerator EnemiesCoroutine()
    {
        float high = Random.Range(-4f, 4f);
        GameObject enemy = Instantiate(prefabEnemy, new Vector3(9,high,0),Quaternion.identity);

        //yield on a new YieldInstruction that waits for CoolDown seconds.
        yield return new WaitForSeconds(4);
        StartCoroutine(EnemiesCoroutine());
        

    }
    IEnumerator RestoreEnergyCoroutine()
    {
        if (energy<20)
        {
            if(malusEnergy)
            {
                for(int i = 0; i < 19; i++)
                {
                    energy += 1;
                    energyBar.SetEnergy(energy);
                    yield return new WaitForSeconds(0.7f);
                }
                malusEnergy = false;
            }
            energy += 1;
            energyBar.SetEnergy(energy);
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(RestoreEnergyCoroutine());

    }

    public void ChangeShootMode()
    {
        switch (GameManager.instance.mode)
        {
            case ShootMode.Simple:
                GameManager.instance.mode = ShootMode.Diagonal;
                shootDirection = new Vector2(4, 4);
                break;
            case ShootMode.Diagonal:
                GameManager.instance.mode = ShootMode.Simple;
                shootDirection = new Vector2(4, 0);
                break;
        }
    }
}
