using Assets.Conquer.Scripts.Info;
using UniRx;

namespace Assets.Conquer.Scripts.Models
{
    public enum ConquerState {

        Initialize,
        Input,
        Finish,

    }

    public class ConquerGameData
    {
        private ConquerFieldModel _fieldModel;

        public ConquerGameData(GameFieldInfo fieldInfo)
        {
            GameFieldInfo = fieldInfo;
            _fieldModel = new ConquerFieldModel(fieldInfo.FieldSize);
        }

        public GameFieldInfo GameFieldInfo { get; protected set; }
        
        public ConquerFieldModel FieldModel => _fieldModel;

    }
}
