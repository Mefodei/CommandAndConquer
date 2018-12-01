using System.Collections;
using Assets.Conquer.Scripts.Models;
using Assets.Tools.UnityTools.Interfaces;
using Conquer.Messages;
using UniStateMachine;
using UnityEngine;
using UniRx;

namespace Conquer.States.Game
{
	public class UpdateTurnDataState : UniNode 
	{
		
		protected override IEnumerator ExecuteState(IContext context)
		{
			var playerModel = context.Get<ConquerPlayerModel>();
			var lifeTime = GetLifeTime(context);
			
			var disposable = context.Receive<EndOfTurnMessage>().
				Subscribe(x => playerModel.IsTurnActive.Value = false);

			lifeTime.AddDispose(disposable);
			
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
