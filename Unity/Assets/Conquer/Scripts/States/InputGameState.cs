using System.Collections;
using Assets.Tools.UnityTools.Interfaces;
using Assets.Tools.UnityTools.StateMachine.UniStateMachine;
using UnityEngine;

namespace Assets.Conquer.Scripts.States
{
    [CreateAssetMenu(fileName = "InputGameState", menuName = "Conquer/States/InputGameState")]
    public class InputGameState : UniStateBehaviour
    {
        protected override IEnumerator ExecuteState(IContext context)
        {
            while (true)
            {

                yield return null;

            }
        }
    }
}
