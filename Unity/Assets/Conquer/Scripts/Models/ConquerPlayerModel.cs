using Conquer.Models;
using UniRx;

namespace Assets.Conquer.Scripts.Models
{
    public class ConquerPlayerModel
    {

        public ReactiveProperty<int> Turn = new ReactiveProperty<int>();
        
        public ReactiveProperty<string> Name = new ReactiveProperty<string>();
        
        public ReactiveProperty<bool> IsTurnActive = new ReactiveProperty<bool>(false);

        public ReactiveProperty<PlayerTurnModel> TurnModel = new ReactiveProperty<PlayerTurnModel>(new PlayerTurnModel());
        
    }
}
