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
	public class CellItemSelectionState : UniNode 
	{
		protected override IEnumerator ExecuteState(IContext context)
		{
			yield return base.ExecuteState(context);
			
			var gameField = context.Get<ConquerGameField>();
			var playerModel = context.Get<ConquerPlayerModel>();
			var cellView = context.Get<CellItemView>();
			var model = context.Get<CellItemModel>();
			
			var cellInfo = model.CellInfo;
			var turn = playerModel.TurnModel.Value;
		
			while (model.Fixed.Value == false)
			{

				var cell = turn.SelectedCell.Value;
				var size = new Vector2Int(cellInfo.Width, cellInfo.Height);
				var rect = new RectInt(cell.Position, size);
			    var result = gameField.Validate(rect);

			    var cellViewPosition = gameField.GetCellPosition(result.rect.position);
			    cellView.transform.position = cellViewPosition;
				cellView.gameObject.SetActive(true);
				
				yield return null;

			}
			
		}

	}
}
