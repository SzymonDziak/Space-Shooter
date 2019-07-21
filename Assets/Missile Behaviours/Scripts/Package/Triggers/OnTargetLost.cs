using UnityEngine;
using System;
using MissileBehaviours.Triggers;

namespace MissileBehaviours.Controller
{
    /// <summary>
    /// Triggers if the target, specified in the attached missile controller, becomes null.
    /// </summary>
    [RequireComponent(typeof(MissileController))]
    public class OnTargetLost : TriggerBase
    {
        MissileController controller;

        void Awake()
        {
            controller = GetComponent<MissileController>();
        }

        override internal void Update()
        {
            base.Update();
            if (!controller.Target)
            {
                FireTrigger(this, EventArgs.Empty);
            }
        }
    }
}
