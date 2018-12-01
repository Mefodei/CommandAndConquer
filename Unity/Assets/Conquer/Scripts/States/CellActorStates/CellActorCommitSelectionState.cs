using System.Collections;
using Assets.Conquer.Scripts.Field;
using Assets.Conquer.Scripts.Models;
using Assets.Tools.UnityTools.Interfaces;
using Conquer.Messages;
using Conquer.Messages.InputMessages;
using Conquer.Models;
using UniStateMachine;
using UniRx;
using UnityEngine;

namespace Conquer.States.CellActor
{
	public class CellActorCommitSelectionState : UniNode
	{
		protected override IEnumerator ExecuteState(IContext context)
		{
			var model = context.Get<CellItemModel>();

			var disposable = context.Receive<CommitCellSelectionMessage>().
				Subscribe(x => CommitPosition(context,x));
			GetLifeTime(context).AddDispose(disposable);

			while (!model.Fixed.Value )
			{
				yield return null;
			}
			
			yield return base.ExecuteState(context);
		}

		private void CommitPosition(IContext context,CommitCellSelectionMessage message)
		{
			var gameField = context.Get<ConquerGameField>();
			var model = context.Get<CellItemModel>();
			var player = context.Get<ConquerPlayerModel>();

			var turn = player.TurnModel.Value;
			var cellInfo = model.CellInfo;
			
			var size = new Vector2Int(cellInfo.Width, cellInfo.Height);
			var result = gameField.Validate(new RectInt(turn.SelectedCell.Value.Position, size));

			if (result.valid)
			{
				gameField.UpdateCellData(result.rect,player.Id.Value);
				model.Fixed.Value = true;
				model.Column.Value = result.rect.x;
				model.Row.Value = result.rect.y;
				
				var cellPlaced = new CellActorPlacedMessage()
				{
					Cell = result.rect.min,
					ActorId = model.CellId.Value,
				};
				context.Publish(cellPlaced);
			}
			
		}
	}
}
