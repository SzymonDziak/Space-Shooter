using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    private GameController gameController;

    [SerializeField]
    private int astreoidScore;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameControllerObject == null)
        {
            Debug.Log("Cannot find game controller in script DestroyByContact");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        if (other.tag == "Player")
        {
            gameController.GameOver();
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
        }
        Instantiate(explosion, transform.position, transform.rotation);
        gameController.AddScore(astreoidScore);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
// testing