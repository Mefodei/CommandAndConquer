using System.Collections;
using Assets.Tools.UnityTools.Interfaces;
using UniStateMachine;
using UnityEngine;

namespace Tests.GraphTest
{
    public class InputTestNode : UniNode
    {
        [SerializeField]
        private bool _isMouseDown = false;

        protected override IEnumerator ExecuteState(IContext context)
        {

            while (true)
            {
                yield return null;

                _isMouseDown = Input.GetMouseButton(0);
                if (_isMouseDown)
                {
                    OutputContext.Add(context);
                }
                else
                {
                    OutputContext.Remove(context);
                }

            }

        }
    }
}
