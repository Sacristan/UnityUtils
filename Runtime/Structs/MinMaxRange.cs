using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sacristan.Utils
{
    [System.Serializable]
    public class MinMaxRange
    {
        [SerializeField] float min;
        [SerializeField] float max;

        public float Min => min;
        public float Max => max;

        public MinMaxRange(float min = default(float), float max = default(float))
        {
            this.min = min;
            this.max = max;
        }

        public float GetRandomValue()
        {
            return Random.Range((float)this.min, (float)this.max);
        }

        public float GetValueFromPerc(float perc)
        {
            return Mathf.Lerp((float)this.min, (float)this.max, perc);
        }

        public float GetPercFromValue(float value)
        {
            return Mathf.InverseLerp((float)this.min, (float)this.max, value);
        }
    }

}