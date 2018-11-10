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
        private ReactiveProperty<ConquerState> _state = new ReactiveProperty<ConquerState>(ConquerState.Initialize);
        private ConquerStepData _activeStep = new ConquerStepData();
        private ConquerFieldData _fieldData;

        public ConquerGameData(ConquerGameConfiguration configuration)
        {
            _fieldData = new ConquerFieldData(configuration.FieldSize);
        }

        public ConquerStepData ActiveStep => _activeStep;

        public ReactiveProperty<ConquerState> State => _state;

        public ConquerFieldData FieldData => _fieldData;

    }
}
