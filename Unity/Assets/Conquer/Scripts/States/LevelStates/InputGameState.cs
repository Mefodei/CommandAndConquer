using System.Collections;
using Assets.Conquer.Scripts.Field;
using Assets.Conquer.Scripts.Models;
using Assets.Tools.UnityTools.Interfaces;
using Assets.Tools.UnityTools.ObjectPool.Scripts;
using Conquer.Scripts.Field;
using UniStateMachine;
using UnityEngine;

namespace Conquer.States
{
    [CreateAssetMenu(fileName = "InputGameState", menuName = "Conquer/States/InputGameState")]
    public class InputGameState : UniNode
    {
        [SerializeField]
        private LayerMask _layerMask;

        protected override IEnumerator ExecuteState(IContext context)
        {

            var itemFactory = context.Get<IUniItemFactory<CellItemView>>();
            var camera = context.Get<Camera>();
            var gameField = context.Get<ConquerGameField>();
            var playerModel = context.Get<ConquerPlayerModel>();

            yield return base.ExecuteState(context);
            
            while (IsActive(context))
            {
                yield return null;

                if (Input.GetMouseButton(0))
                {
                    playerModel.IsTurnActive.Value = true;
                    var mousePosition = Input.mousePosition;
                    var ray = camera.ScreenPointToRay(mousePosition);
                    var hitResult = Physics.Raycast(ray, out var hit, _layerMask);

                    if (!hitResult || gameField.transform != hit.transform)
                        continue;

                    var turn = playerModel.TurnModel.Value;
                    turn.SelectedCell.Value = gameField.GetCellPosition(hit.point);

                }
                else
                {
                    playerModel.IsTurnActive.Value = false;
                }

                
            }
        }

    }
}
