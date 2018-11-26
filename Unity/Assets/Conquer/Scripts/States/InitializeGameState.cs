using System.Collections;
using Assets.Conquer.Scripts.Field;
using Assets.Conquer.Scripts.Info;
using Assets.Conquer.Scripts.Models;
using Assets.Tools.UnityTools.Interfaces;
using UniStateMachine;
using UnityEngine;
using UnityEngine.Serialization;

namespace Conquer.States
{
    [CreateAssetMenu(fileName = "InitializeGameState", menuName = "Conquer/States/InitializeGameState")]
    public class InitializeGameState :  UniNode
    {
        
        [FormerlySerializedAs("_info")] [FormerlySerializedAs("_configuration")] [SerializeField]
        private GameFieldInfo _fieldInfo;

        
        protected override IEnumerator ExecuteState(IContext context) {


            var gameField = context.Get<ConquerGameField>();

            var gameModel = new ConquerGameData(_fieldInfo);
  
            gameField.Initialize(gameModel.FieldModel);

            var playerModel = new ConquerPlayerModel();
            
            context.Add(_fieldInfo);
            context.Add(playerModel);
            context.Add(gameModel);

            OutputContext.Data.SetValue(context);

            yield break;
        }
    }
}
