using System.Collections;
using Assets.Conquer.Scripts.Models;
using Assets.Tools.UnityTools.Interfaces;
using Conquer.Messages;
using UniStateMachine;
using UnityEngine;
using UniRx;

namespace Conquer.States.Game
{
	public class GameCommandsState : UniNode 
	{
		
		protected override IEnumerator ExecuteState(IContext context)
		{

			var lifeTime = GetLifeTime(context);
			var disposable = context.Receive<MakeTheRollCubesMessage>().Subscribe(x => OnMakeRoll(context));
			lifeTime.AddDispose(disposable);
			
			return base.ExecuteState(context);
		}


		private void OnMakeRoll(IContext context)
		{
			var gameData = context.Get<ConquerGameData>();
			var playerModel = context.Get<ConquerPlayerModel>();
			
			var field = gameData.GameFieldInfo;
			
			var widthSize = Random.Range(field.CellWidthLimit.x,field.CellWidthLimit.y);
			var heightSize = Random.Range(field.CellHeightLimit.x,field.CellHeightLimit.y);

			var rollResult = new RollTheCubeResultMessage()
			{
				Width = widthSize,
				Height = heightSize,
			};

			context.Publish(rollResult);
			
			var turn = playerModel.TurnModel.Value;
			playerModel.Turn.Value++;
			playerModel.IsTurnActive.Value = true;
			turn.ItemSize.Value = new Vector2Int(widthSize,heightSize);
			
		}
	}
}
