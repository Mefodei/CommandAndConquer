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

		protected override void OnExit(IContext context)
		{
			base.OnExit(context);
		}


		private void OnMakeRoll(IContext context)
		{
			var gameData = context.Get<ConquerGameData>();
			var field = gameData.GameFieldInfo;
			
			var widthSize = Random.Range(field.CellWidthLimit.x,field.CellWidthLimit.y);
			var heightSize = Random.Range(field.CellHeightLimit.x,field.CellHeightLimit.y);

			var rollResult = new RollTheCubeResultMessage()
			{
				Width = widthSize,
				Height = heightSize,
			};

			context.Publish(rollResult);
		}
	}
}
