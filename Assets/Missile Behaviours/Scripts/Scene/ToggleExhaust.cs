using MissileBehaviours.Scene;
using UnityEngine;

namespace MissileBehaviours.Controller
{
    /// <summary>
    /// Disables the particle system on this gameobject if the missile controller of the parent isn't accelerating. Otherwise its emission rate is set to the throttle of the missile controller.
    /// </summary>
    [RequireComponent(typeof(ParticleSystem))]
    public class ToggleExhaust : MonoBehaviour
    {
        ParticleSystem exhaust;
        MissileController controller;

        ParticleSystem.EmissionModule emission;
        ParticleSystem.MinMaxCurve rate;

        void Awake ()
        {
            emission = GetComponent<ParticleSystem>().emission;
            rate = new ParticleSystem.MinMaxCurve(0);
            controller = GetComponentInParent<MissileController>();
        }
         
        void Update()
        {
            if (controller)
            {
                if (controller.IsAccelerating)
                    rate.constantMax = controller.Throttle;
                else
                    rate.constantMax = 0;
            }
            emission.rateOverDistance = rate;
        }
    }
}
