using System.Collections;
using Assets.Conquer.Scripts.Models;
using Assets.Tools.UnityTools.Interfaces;
using Conquer.Scripts.Models;
using UniStateMachine;

namespace Conquer.States.CellActor
{
	public class CellActorInitialize : UniNode 
	{
		
		protected override IEnumerator ExecuteState(IContext context)
		{
			var cellModel = context.Get<CellItemModel>();

			//activate view
			var view = cellModel.View.Value;
			view.gameObject.SetActive(true);
			view.transform.SetParent(null);
			
			yield return base.ExecuteState(context);
			
		}

		public override bool Validate(IContext context)
		{
			var cellModel = context.Get<CellItemModel>();
			return cellModel != null;
		}
	}
}
