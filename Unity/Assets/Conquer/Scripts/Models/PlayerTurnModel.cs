using Assets.Tools.UnityTools.ActorEntityModel;
using UniRx;
using UnityEngine;

namespace Conquer.Scripts.Models
{
    public class PlayerTurnModel
    {

        
        public ReactiveProperty<Vector2Int> ItemSize = new ReactiveProperty<Vector2Int>(Vector2Int.zero);
    
        public ReactiveProperty<float> TimeLeft = new ReactiveProperty<float>();
        
        public ReactiveProperty<Vector3> SelectedCell = new ReactiveProperty<Vector3>();
        
    }
}
