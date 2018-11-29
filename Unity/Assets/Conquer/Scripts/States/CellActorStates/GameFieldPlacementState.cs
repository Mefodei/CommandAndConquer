using System.Collections;
using Assets.Conquer.Scripts.Field;
using Assets.Conquer.Scripts.Models;
using Assets.Tools.UnityTools.Interfaces;
using Conquer.Field;
using Conquer.Models;
using UniStateMachine;
using UnityEngine;

namespace Conquer.States.CellActor
{
	public class GameFieldPlacementState : UniNode 
	{
		protected override IEnumerator ExecuteState(IContext context)
		{
			var gameField = context.Get<ConquerGameField>();
			var playerModel = context.Get<ConquerPlayerModel>();
			var cellView = context.Get<CellItemView>();
			var model = context.Get<CellItemModel>();
			var cellInfo = model.CellInfo;
			
			var turn = playerModel.TurnModel.Value;
			var hit = turn.GameFieldHit.Value;
		
			while (playerModel.IsTurnActive.Value)
			{

				var cellPosition = turn.SelectedCell.Value;
				var cell = gameField.GetCell(cellPosition);
				var size = new Vector2Int(cellInfo.Width, cellInfo.Height);
			    var result = gameField.Validate(cell.Position, size);

			    var cellViewPosition = gameField.GetCellPosition(result.position);
			    cellView.transform.position = cellViewPosition;
				cellView.gameObject.SetActive(true);
				
                if (result.valid)
				{

				}
				
				yield return null;

			}
			
			yield return base.ExecuteState(context);
			
		}

		protected override void OnExit(IContext context)
		{
			base.OnExit(context);
		}
	}
}
