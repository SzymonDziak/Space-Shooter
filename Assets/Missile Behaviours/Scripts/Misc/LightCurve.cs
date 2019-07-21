using UnityEngine;
using System.Collections;
namespace MissileBehaviours.Misc
{
    // A simple script to adjust the emission levels of a light over time via an animation curve.
    [RequireComponent(typeof(Light))]
    public class LightCurve : MonoBehaviour
    {
        [Tooltip("The curve which defines the intensity of the light over time.")]
        public AnimationCurve lightCurve;
         
        float elapsedTime;

        void Update()
        {
            elapsedTime += Time.deltaTime;
            GetComponent<Light>().intensity = lightCurve.Evaluate(elapsedTime);
        }
    }
}
