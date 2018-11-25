using System.Collections;
using Assets.Conquer.Scripts.Field;
using Assets.Conquer.Scripts.Info;
using Assets.Conquer.Scripts.Models;
using Assets.Tools.UnityTools.Interfaces;
using UniStateMachine;
using UnityEngine;

namespace Conquer.States
{
    [CreateAssetMenu(fileName = "InitializeGameState", menuName = "Conquer/States/InitializeGameState")]
    public class InitializeGameState :  UniNode
    {
        protected override IEnumerator ExecuteState(IContext context) {

            var config = context.Get<ConquerGameConfiguration>();
            var gameField = context.Get<ConquerGameField>();

            var gameModel = new ConquerGameData(config);
            gameModel.State.Value = ConquerState.Input;

            gameField.Initialize(gameModel.FieldData);

            var fieldItemFactory = new FieldItemFactory(config.CellObject);

            context.Add((IUniItemFactory<CellItemView>) fieldItemFactory);
            context.Add(gameModel);

            OutputContext.Data.SetValue(context);

            yield break;
        }
    }
}
