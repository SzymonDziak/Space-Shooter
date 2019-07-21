using UnityEngine;
using System.Collections.Generic;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance { get; private set; } // instantiation of its own class to remove bullets from other classes

    [SerializeField] private PBullet pooledBulletPrefab;

    private bool notEnoughBulletsInPool = true;

    private Queue<PBullet> bullets = new Queue<PBullet>();

    public int preWarmCount;

    private void Awake()
    {
        Instance = this;
    }
    private void OnEnable()
    {
        AddShots(preWarmCount); // pre warm bullets into the scene
    }
    public PBullet Get()
    {
        if(bullets.Count == 0)
        {
            AddShots(1);
        }
        return bullets.Dequeue();
    }

    private void AddShots(int count)
    {
        if (bullets.Count < 11)
        {
            for (int i = 0; i < count; i++)
            {
                PBullet pBullet = Instantiate(pooledBulletPrefab);
                pBullet.gameObject.SetActive(false);
                bullets.Enqueue(pBullet);
            }
        }
    }
    public void ReturnToPool(PBullet pBullet)
    {
        pBullet.gameObject.SetActive(false);
        bullets.Enqueue(pBullet);
    }
}
