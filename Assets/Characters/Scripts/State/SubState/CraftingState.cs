using System.Collections;
using System.Collections.Generic;
using Interactable_Objects.Scripts;
using UnityEngine;

namespace Characters.Scripts
{
    public class CraftingState : CharacterState
    {
        private Coroutine _craftingCoroutine;
        private InteractableObject _interactable;
        private readonly InteractingState _parentState;
        private readonly Dictionary<string, int> _requiredMaterials = new();

        public CraftingState(InteractingState parent) : base(parent.StateMachine)
        {
            _parentState = parent;
        }

        public void SetInteractable(InteractableObject interactable)
        {
            _interactable = interactable;
        }

        public override void EnterState()
        {
            if (_interactable != null)
            {
                StateMachine.SetAnimationState("Gathering");
                _craftingCoroutine = StateMachine.StartCoroutine(CraftingCoroutine());
                StateMachine.StartCoroutine(_interactable.BuildProgress());
            }
        }

        public override void ExitState()
        {
            if (_craftingCoroutine != null) StateMachine.StopCoroutine(_craftingCoroutine);
        }

        private IEnumerator CraftingCoroutine()
        {
            yield return new WaitForSeconds(5f); // Example: Wait for 5 second
            if (InventoryManager.instance.HasMaterials(_requiredMaterials))
            {
                Debug.Log($"Building materials for {_requiredMaterials.Count} materials");
            }
            else
            {
                Debug.Log("Not enough materials materials");
            }

            _parentState.OnSubStateCompleted();
        }
    }
}