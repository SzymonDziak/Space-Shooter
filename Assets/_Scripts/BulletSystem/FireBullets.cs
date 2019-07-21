using UnityEngine;
using UnityEditor;

public class FireBullets : MonoBehaviour
{
    [SerializeField]
    private int bulletsAmount = 10;

    [SerializeField]
    private float startAngle = 90f, endAngle = 270f;

    private Vector2 bulletMoveDirection;

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Fire();
        }
    }
    
    private void Fire()
    {
        var shot = BulletPool.Instance.Get();
        shot.transform.rotation = transform.rotation;
        shot.transform.position = transform.position;
        shot.gameObject.SetActive(true);
        /*
         
        float angleStep = (endAngle - startAngle) / bulletsAmount; // distance between all bullets
        float angle = startAngle;

        for (int i = 0; i < bulletsAmount + 1; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI));
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI));

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0.0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstanse.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<Bullet>().SetMoveDirection(bulDir);

            angle += angleStep;
            */
        }
    }