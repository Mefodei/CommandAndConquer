using Conquer.Scripts.Info;
using UnityEngine;

namespace Assets.Conquer.Scripts.Info
{
    [CreateAssetMenu(fileName = "ConquerGameConfiguration", menuName = "Conquer/GameConfiguration")]
    public class GameFieldInfo : ScriptableObject
    {
        [SerializeField]
        private Vector2Int _fieldSize = new Vector2Int(10,10);

        [SerializeField]
        private Vector2Int _cellWidthLimit = new Vector2Int(1,7);
        
        [SerializeField]
        private Vector2Int _cellHeightLimit = new Vector2Int(1,7);
        
        [SerializeField]
        private CellItemsMapInfo _cellsMap;

        public Vector2Int FieldSize => _fieldSize;

        public Vector2Int CellHeightLimit => _cellHeightLimit;

        public Vector2Int CellWidthLimit => _cellWidthLimit;
        
        public CellItemsMapInfo CellsMap => _cellsMap;
    }
}
