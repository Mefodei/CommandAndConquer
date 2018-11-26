using System.Collections;
using Assets.Conquer.Scripts.Models;
using Assets.Tools.UnityTools.Interfaces;
using UniStateMachine;

namespace Conquer.States
{
    public class SelectFieldCellState : UniNode 
    {
        protected override IEnumerator ExecuteState(IContext context)
        {
            var playerModel = context.Get<ConquerPlayerModel>();
            var gameData = context.Get<ConquerGameData>();

            var map = gameData.GameFieldInfo.CellsMap;
            var turn = playerModel.TurnModel.Value;
            var size = turn.ItemSize.Value;
            var area = size.x * size.y;
            
            var view = map.c
            
            return base.ExecuteState(context);
        }
    }
}
