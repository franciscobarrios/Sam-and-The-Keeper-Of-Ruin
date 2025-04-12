using System;
using System.Collections;
using System.Collections.Generic;
using Characters.Scripts;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Interactable_Objects.Scripts
{
    public class InteractableObject : MonoBehaviour
    {
        [Serialize] public float animationTime = 10f;
        [Serialize] public GameObject glowingRing;
        [Serialize] public Slider progressBar;
        [Serialize] public InteractableObjectType objectType;
        private bool _isPerformingAction = false;
        private readonly Dictionary<string, int> _requiredMaterials = new();
        private Action<float, PlayerState> _playPlayerAnimationCallback;

        public void ShowInteractPrompt(bool show)
        {
            if (glowingRing != null)
            {
                glowingRing.SetActive(show);
            }
        }

        public InteractableObjectType GetObjectType() => objectType;

        public void Interact(Action<float, PlayerState> playAnimationCallback)
        {
            if (_isPerformingAction) return;

            _playPlayerAnimationCallback = playAnimationCallback;
            // Store the callback

            if (InventoryManager.instance.HasMaterials(_requiredMaterials))
            {
                InventoryManager.instance.UseMaterials(_requiredMaterials);
                StartCoroutine(BuildProgress());
            }
            else
            {
                Debug.Log("Not enough materials!");
            }
        }

        public IEnumerator BuildProgress()
        {
            _isPerformingAction = true;
            progressBar.gameObject.SetActive(true);
            progressBar.value = 0;

            float elapsedTime = 0;
            while (elapsedTime < animationTime)
            {
                progressBar.value = elapsedTime / animationTime;
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            progressBar.value = 1;
            progressBar.gameObject.SetActive(false);
            _isPerformingAction = false;
        }
    }
}