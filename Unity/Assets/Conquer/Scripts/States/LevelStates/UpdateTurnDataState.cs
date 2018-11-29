using System.Collections;
using Assets.Conquer.Scripts.Models;
using Assets.Tools.UnityTools.Interfaces;
using Conquer.Scripts.Messages;
using UniStateMachine;
using UnityEngine;

namespace Conquer.States.Game
{
	public class UpdateTurnDataState : UniNode 
	{
		
		protected override IEnumerator ExecuteState(IContext context)
		{
			var gameModel = context.Get<ConquerGameData>();
			var playerModel = context.Get<ConquerPlayerModel>();
			var gameInfo = gameModel.GameFieldInfo;
			
			var widthSize = Random.Range(gameInfo.CellWidthLimit.x,gameInfo.CellWidthLimit.y);
			var heightSize = Random.Range(gameInfo.CellHeightLimit.x,gameInfo.CellHeightLimit.y);


		    var rollResult = new RollTheCubeResultMessage()
		    {
		        Width = widthSize,
		        Height = heightSize,
		    };

		    context.Publish(rollResult);

            var turnData = playerModel.TurnModel.Value;
			turnData.ItemSize.Value = new Vector2Int(widthSize,heightSize);
			
			return base.ExecuteState(context);
		}


		public override bool Validate(IContext context)
		{
			var playerModel = context.Get<ConquerPlayerModel>();
			var isActive = playerModel.IsTurnActive.Value;
			var turnDataCreated = playerModel.TurnModel.Value != null;
			return isActive && turnDataCreated;
		}
	}
}
