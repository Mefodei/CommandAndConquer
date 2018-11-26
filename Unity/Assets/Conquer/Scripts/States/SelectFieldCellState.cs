using System.Collections;
using Assets.Conquer.Scripts.Field;
using Assets.Conquer.Scripts.Models;
using Assets.Tools.UnityTools.ActorEntityModel;
using Assets.Tools.UnityTools.Interfaces;
using Assets.Tools.UnityTools.ObjectPool.Scripts;
using UniStateMachine;

namespace Conquer.States
{
    public class SelectFieldCellState : UniNode 
    {
        protected override IEnumerator ExecuteState(IContext context)
        {
            var playerModel = context.Get<ConquerPlayerModel>();
            var gameData = context.Get<ConquerGameData>();
            var cellItemFactory = context.Get<IGameFieldCellFactory>();

            var turn = playerModel.TurnModel.Value;
            var size = turn.ItemSize.Value;
            var area = size.x * size.y;

            var view = cellItemFactory.Create(0, area);

            while (IsActive(context))
            {

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
