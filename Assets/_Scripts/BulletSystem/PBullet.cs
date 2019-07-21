using UnityEngine;
using System.Collections;

public class PBullet : MonoBehaviour
{
    public float moveSpeed;

    private float lifeTime;
    private float maxLifeTime = 3f;

    // Use this for initialization
    private void OnEnable()
    {
        lifeTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        lifeTime += Time.deltaTime;
        if (lifeTime > maxLifeTime)
        {
            BulletPool.Instance.ReturnToPool(this);
        }
    }
}
