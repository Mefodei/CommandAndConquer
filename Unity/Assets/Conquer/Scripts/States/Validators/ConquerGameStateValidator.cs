using Assets.Conquer.Scripts.Models;
using Assets.Tools.UnityTools.Interfaces;
using Assets.Tools.UnityTools.StateMachine.UniStateMachine;
using UnityEngine;

namespace Assets.Conquer.Scripts.States.Validators
{
    [CreateAssetMenu(fileName = "StateValidator", menuName = "Conquer/Validator/StateValidator")]
    public class ConquerGameStateValidator : UniTransitionValidator {

        [SerializeField]
        private ConquerState _state;

        protected override bool ValidateNode(IContext context)
        {
            var conquerData = context.Get<ConquerGameData>();
            return conquerData.State.Value == _state;
        }

    }
}
