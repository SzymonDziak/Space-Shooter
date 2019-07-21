using UnityEngine;
using MissileBehaviours.Scene;

namespace MissileBehaviours.Controller
{
    /// <summary>
    /// Toggles the trail renderer.
    /// </summary>
    public class ToggleTrails : MonoBehaviour
    {
        TrailRenderer trailRenderer;

        void Start()
        {
            trailRenderer = GetComponent<TrailRenderer>();
        }


        void Update()
        {
            if (trailRenderer)
                trailRenderer.enabled = SpawnMissiles.trailsVisible;
            
        }
    }
}
