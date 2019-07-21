using UnityEngine;
using System;

namespace MissileBehaviours.Triggers
{
    /// <summary>
    /// Triggers after a specified amount of time.
    /// </summary>
    public class OnLevelFlight : TriggerBase
    {
        #region Properties
        /// <summary>
        /// Margin of error in degrees.
        /// </summary>
        public float MarginOfError
        {
            get { return marginOfError; }
            set { marginOfError = value; }
        }
        #endregion

        #region Serialized Fields
        [SerializeField, Tooltip("The margin of error in degrees.")]
        float marginOfError = 1;
        #endregion

        override internal void Update()
        {
            base.Update();
            float angle = transform.rotation.eulerAngles.x;
            if ((angle < marginOfError && angle > -marginOfError) || (angle > 360 - marginOfError && angle < 360 + marginOfError))
                FireTrigger(this, EventArgs.Empty);
        }
    }
}
