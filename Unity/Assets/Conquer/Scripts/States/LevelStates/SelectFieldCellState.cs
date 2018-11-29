using System.Collections;
using Assets.Conquer.Scripts.Field;
using Assets.Conquer.Scripts.Models;
using UnityTools.ActorEntityModel;
using Assets.Tools.UnityTools.Interfaces;
using Assets.Tools.UnityTools.ObjectPool.Scripts;
using UniStateMachine;

namespace Conquer.States.Game
{
    public class SelectFieldCellState : UniNode 
    {
        protected override IEnumerator ExecuteState(IContext context)
        {
            var playerModel = context.Get<ConquerPlayerModel>();
            var gameField = context.Get<ConquerGameField>();
            var cellItemFactory = context.Get<IGameFieldCellFactory>();

            var turn = playerModel.TurnModel.Value;
            var size = turn.ItemSize.Value;

            var actor = cellItemFactory.Create(0, size.x,size.y);
            
            _context.AddValue(context,actor);
            
            actor.Context.Add(playerModel);
            actor.Context.Add(gameField);
            actor.SetEnabled(true);

            while (IsActive(context))
            {

                yield return null;

            }
            
            yield return base.ExecuteState(context);
        }

        protected override void OnExit(IContext context)
        {
            var actor = _context.Get<Actor>(context);
            actor?.Despawn();

            base.OnExit(context);
        }
    }
}
