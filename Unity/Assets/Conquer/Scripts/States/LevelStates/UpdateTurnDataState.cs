using System.Collections;
using Assets.Conquer.Scripts.Models;
using Assets.Tools.UnityTools.Interfaces;
using Conquer.Messages;
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
            var turnData = playerModel.TurnModel.Value;

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
