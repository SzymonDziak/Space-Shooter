using UnityEngine;
using System.Collections;
using MissileBehaviours.Misc;

namespace MissileBehaviours.Controller
{
    // Simple script to adjust a missiles throttle over time via an animation curve.
    [RequireComponent(typeof(MissileController))]
    public class ThrottleCurve : MonoBehaviour
    {
        [SerializeField, Tooltip("A curve describing the throttle of a missile. Keep it between 0-1 on both axes and use the time multiplier for scaling.")]
        AnimationCurve curve;
        [SerializeField, Tooltip("The scale of the curve.")]
        float time = 10;

        MissileController controller;

        void Awake()
        {
            controller = GetComponent<MissileController>();
        }

        void Update()
        {
            controller.Throttle = curve.Evaluate(controller.LifeTime / time);
        } 
    }
}
