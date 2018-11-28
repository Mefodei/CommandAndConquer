using System.Collections;
using Assets.Conquer.Scripts.Models;
using Assets.Tools.UnityTools.Interfaces;
using Conquer.Scripts.Field;
using Conquer.Scripts.Models;
using UniStateMachine;

namespace Conquer.States.CellActor
{
	public class GameFieldPlacementState : UniNode 
	{
		protected override IEnumerator ExecuteState(IContext context)
		{
			var playerModel = context.Get<ConquerPlayerModel>();
			var cellView = context.Get<CellItemView>();
			var mode = context.Get<CellItemModel>();

			var turn = playerModel.TurnModel.Value;
			
			while (playerModel.IsTurnActive.Value)
			{
				cellView.transform.position = turn.SelectedCell.Value;
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
