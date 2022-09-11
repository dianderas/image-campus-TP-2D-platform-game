using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GD.Feedback
{
    public class FlashWhiteFeedback : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer spriteRenderer;
        [SerializeField]
        private float feedbackTime = 0.1f;

        public void PlayFeedback()
        {
            if (spriteRenderer == null || !spriteRenderer.material.HasProperty("_MakeSolidColor"))
            {
                return;
            }

            ToggleMaterial(1);
            StopAllCoroutines();
            StartCoroutine(ResetColor());
        }

        private void ToggleMaterial(int val)
        {
            val = Mathf.Clamp(val, 0, 1);
            spriteRenderer.material.SetInt("_MakeSolidColor", val);
        }

        IEnumerator ResetColor()
        {
            yield return new WaitForSeconds(feedbackTime);
            ToggleMaterial(0);
        }
    }
}


