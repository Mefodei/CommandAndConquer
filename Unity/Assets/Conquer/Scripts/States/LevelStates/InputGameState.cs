using System.Collections;
using Assets.Conquer.Scripts.Field;
using Assets.Conquer.Scripts.Models;
using Assets.Tools.UnityTools.Interfaces;
using Conquer.Scripts.Field;
using UniStateMachine;
using UnityEngine;

namespace Conquer.States.Game
{
    [CreateAssetMenu(fileName = "InputGameState", menuName = "Conquer/States/InputGameState")]
    public class InputGameState : UniNode
    {
        [SerializeField]
        private LayerMask _layerMask;

        protected override IEnumerator ExecuteState(IContext context)
        {

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

                    UpdateSelectedCell(camera, gameField, playerModel);
                }
                else
                {
                    playerModel.IsTurnActive.Value = false;
                }

                
            }
        }

        private void UpdateSelectedCell(Camera camera,ConquerGameField gameField,ConquerPlayerModel playerModel)
        {
            var mousePosition = Input.mousePosition;
            var ray = camera.ScreenPointToRay(mousePosition);
            var hitResult = Physics.Raycast(ray, out var hit, _layerMask);

            if (!hitResult || gameField.transform != hit.transform)
            {
                return;
            }

            var turn = playerModel.TurnModel.Value;
            var cellPosition = gameField.GetCellPosition(hit.point);
            turn.SelectedCell.Value = cellPosition;
            turn.GameFieldHit.Value = hit;
            
        }

    }
}
