using UnityEngine;
using System.Collections;
namespace MissileBehaviours.Controller
{
    [RequireComponent(typeof(MissileController))]
    public class BallisticGuidance : MonoBehaviour
    {
        #region Serialized Fields 
        [SerializeField, Tooltip("The time, in seconds, after which the guidance is activated")]
        float guidanceDelay;
        [SerializeField, Tooltip("If true, the guidance will only activate if the missile is out of fuel.")]
        bool activeOnceFuelGone = true;
        #endregion

        MissileController controller;

        void Awake()
        {
            controller = GetComponent<MissileController>();
        }

        void FixedUpdate()
        {
            if (guidanceDelay < controller.LifeTime && controller.LifeTime > 0.1f)
            {
                if (activeOnceFuelGone)
                {
                    if (controller.FuelRemaining <= 0)
                    {
                        controller.Rotate(Quaternion.LookRotation(controller.Velocity.normalized));
                    }
     
                    else
                        return;
                }
                controller.Rotate(Quaternion.LookRotation(controller.Velocity.normalized));
            }
        }
    }
}