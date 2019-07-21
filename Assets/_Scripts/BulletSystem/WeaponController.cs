using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    // projectiles
    public GameObject projectile;

    public Transform[] shotSpawns;

    public float fireDelta = 0.25f;
    private float nextFire = 0.05f, myTime = 0.0f, nextMissileFire, missileTime;
    
    private AudioSource audiosource;

    // Update is called once per frame6f 
    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }
    void Update()
    {
        myTime = myTime + Time.deltaTime;
        if (Input.GetButton("Fire1") && myTime > nextFire)
        {
            Fire();
        }

        // shotSpawns[0].eulerAngles = new Vector3(0.0f, shotSpawns[0].eulerAngles.y, 0.0f); // fixes bullets falling through the ground
    }
    public void Fire()
    {
        nextFire = myTime + fireDelta;

        foreach (var shotSpawn in shotSpawns)
        {
            shotSpawn.rotation = Quaternion.Euler(shotSpawn.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0.0f);
            shotSpawn.eulerAngles = new Vector3(0.0f, shotSpawn.eulerAngles.y, 0.0f); // fixes bullet falling through ground
            var shot = BulletPool.Instance.Get();
            shot.transform.rotation = shotSpawn.transform.rotation;
            shot.transform.position = shotSpawn.transform.position;
            shot.gameObject.SetActive(true);

            //Instantiate(projectile, shotSpawn.position, shotSpawn.rotation);
        }
        audiosource.Play();
        
        // create code here that animates the newProjectile

        nextFire = nextFire - myTime;
        myTime = 0.0F;
    }
}

