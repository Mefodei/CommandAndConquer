using Assets.Conquer.Scripts.Models;
using Assets.Tools.UnityTools.Interfaces;
using UniStateMachine;
using UnityEngine;

namespace Conquer.Validators
{
    [CreateAssetMenu(fileName = "StateValidator", menuName = "Conquer/Validator/StateValidator")]
    public class ConquerGameStateValidator : UniStateTransition {

        [SerializeField]
        private ConquerState _state;

        public override bool Validate(IContext context)
        {
            var conquerData = context.Get<ConquerGameData>();
            return conquerData.State.Value == _state;
        }

    }
}
