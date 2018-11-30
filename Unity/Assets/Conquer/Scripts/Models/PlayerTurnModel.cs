using Assets.Conquer.Scripts.Models;
using UnityTools.ActorEntityModel;
using UniRx;
using UnityEngine;

namespace Conquer.Models
{
    public class PlayerTurnModel
    {

        
        public ReactiveProperty<Vector2Int> ItemSize = new ReactiveProperty<Vector2Int>(Vector2Int.zero);
    
        public ReactiveProperty<float> TimeLeft = new ReactiveProperty<float>();
        
        public ReactiveProperty<CellData> SelectedCell = new ReactiveProperty<CellData>();
        
        public ReactiveProperty<RaycastHit> GameFieldHit = new ReactiveProperty<RaycastHit>();
        
    }
}
