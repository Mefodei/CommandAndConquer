using System.Collections;
using Assets.Conquer.Scripts.Field;
using Assets.Conquer.Scripts.Models;
using Assets.Tools.UnityTools.Interfaces;
using Conquer.Field;
using Conquer.Messages;
using Conquer.Messages.InputMessages;
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
            
            var turn = playerModel.TurnModel.Value;
            
            yield return base.ExecuteState(context);
            
            while (IsActive(context))
            {
                yield return null;

                if (Input.GetMouseButton(0))
                {
                    UpdateSelectedCell(context,camera, gameField, playerModel);
                }
                else if(Input.GetMouseButtonUp(0))
                {
                    var message = new InputFieldCellSelectedMessage()
                    {
                        Cell = turn.SelectedCell.Value
                    };
                    context.Publish(message);
                }
            }
        }

        private void UpdateSelectedCell(IContext context, Camera camera,
            ConquerGameField gameField,ConquerPlayerModel playerModel)
        {
            
            var mousePosition = Input.mousePosition;
            var ray = camera.ScreenPointToRay(mousePosition);
            var hitResult = Physics.Raycast(ray, out var hit, _layerMask);

            if (!hitResult || gameField.transform != hit.transform)
            {
                return;
            }

            var turn = playerModel.TurnModel.Value;
            var cell = gameField.GetCell(hit.point);

            if (cell == null)
                return;
            
            turn.SelectedCell.Value = cell;
            turn.GameFieldHit.Value = hit;

            var message = new InputUnderCellSelectedMessage()
            {
                Hit = hit,
                Cell = cell,
            };
            
            context.Publish(message);
        }

    }
}
