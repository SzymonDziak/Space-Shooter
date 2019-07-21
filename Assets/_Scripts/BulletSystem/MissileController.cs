using UnityEngine;
using System.Collections;
using System;

public class MissileController : MonoBehaviour
{
    public float missileVelocity = 300, turn = 30, fuseDelay;
    public Rigidbody homingMissile;
    public GameObject missileModel;
    public ParticleSystem particlePrefab;
    //public AudioClip missileSound;
    private Transform target;

    // Use this for initialization
    void Start()
    {
        homingMissile = GetComponent<Rigidbody>();
        Fire();
    }

    void Fire()
    {
        //AudioSource.PlayClipAtPoint(missileSound, transform.position);

        var distance = Mathf.Infinity;
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Enemy");
        homingMissile.velocity = transform.forward * missileVelocity;
        if(objects == null)
        {
            Debug.Log("target objects missing");
        }
        // The for loop looks for the closet enemy object and sets target location.
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Enemy")) {
            var diff = (go.transform.position - transform.position).sqrMagnitude;
            Debug.Log("diff" + diff);
            if (diff < distance && diff > 200)
            {
                distance = diff;
                target = go.transform;
            }
        }
    }
    private void FixedUpdate()
    {
        if (target == null || homingMissile == null)
        {
            return;
        }
        homingMissile.velocity = transform.forward * missileVelocity;

        var targetRotation = Quaternion.LookRotation(target.position - transform.position); //  cross product betweent target position and missile position.

        homingMissile.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, turn));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            particlePrefab.loop = false;
            particlePrefab.emissionRate = 0.0f;
            particlePrefab.gameObject.transform.parent = null;
            //Destroy(particlePrefab.gameObject, 1f);
            Destroy(missileModel.gameObject);
            //WaitForSeconds(5f);
            Destroy(gameObject);
        }
    }

    private IEnumerator WaitForSeconds(float v)
    {
        yield return new WaitForSeconds(v);
    }
}
