using UnityEngine;
using MissileBehaviours.Actions;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public GameObject missileExplosion;

    private GameController gameController;

    [SerializeField]
    private int astreoidScore;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        // checks if the gamecontroller exists in the scene
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        else
        {
            Debug.Log("Cannot find game controller in script DestroyByContact");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
        {
            return;
        }
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }

        //Debug.Log(other.tag);

        if (explosion != null && !other.CompareTag("Missile"))
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }

        // This script takes the prefab from each missile ** no need to set it publically in this script ** 
        // Allows multiple explosions for missiles
        if (other.CompareTag("Missile"))
        {
            Debug.Log("Missile HIT");
            //GameObject prefab = other.GetComponent<GameObject>().GetComponent<Explode>().explosionPrefab;
            Instantiate(missileExplosion, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        gameController.AddScore(astreoidScore);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}