using System;
using System.Collections;
using System.Collections.Generic;
using Interactable_Objects.Scripts;
using UnityEngine;

namespace Characters.Scripts
{
    public class GatheringState : CharacterState
    {
        private Coroutine _gatheringCoroutine;
        private InteractableObject _interactable;
        private readonly InteractingState _parentState;

        public GatheringState(InteractingState parent) : base(parent.StateMachine)
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
                _gatheringCoroutine = StateMachine.StartCoroutine(GatheringCoroutine());
                StateMachine.StartCoroutine(_interactable.BuildProgress());
            }
        }

        public override void ExitState()
        {
            if (_gatheringCoroutine != null) StateMachine.StopCoroutine(_gatheringCoroutine);
        }

        private IEnumerator GatheringCoroutine()
        {
            yield return new WaitForSeconds(5f);
          //Inventory.instance.AddItem();
            _parentState.OnSubStateCompleted();
        }
    }
}