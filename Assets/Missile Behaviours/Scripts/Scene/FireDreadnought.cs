using UnityEngine;
using System.Collections.Generic;
using MissileBehaviours.Scene;


namespace MissileBehaviours.Controller
{ 
    /// <summary>
    /// Spawns missiles, believe it or not.
    /// </summary>
    public class FireDreadnought : MonoBehaviour
    {
        public GameObject missilePrefab;
        public List<Transform> silos;
        public Transform target;
        public KeyCode fireKey;
        void Update()
        {
            if (Input.GetKeyDown(fireKey))
            {
                foreach (var item in silos)
                {
                    GameObject missile = Instantiate(missilePrefab, item.transform.position, item.transform.rotation) as GameObject;
                    missile.GetComponent<MissileController>().Target = target;
                } 
            }
        }
    }
}
