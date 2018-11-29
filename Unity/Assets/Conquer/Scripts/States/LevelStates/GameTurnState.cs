using System.Collections;
using Assets.Tools.UnityTools.Interfaces;
using UniStateMachine;

namespace Conquer.States.Game
{
	public class GameTurnState : UniNode 
	{
		protected override IEnumerator ExecuteState(IContext context)
		{

			while (IsActive(context))
			{
				

				yield return null;
			}
			
		}
	}
}
