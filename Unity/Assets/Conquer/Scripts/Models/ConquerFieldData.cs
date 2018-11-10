using System.Collections.Generic;
using Assets.Tools.UnityTools.Math;
using UnityEngine;

namespace Assets.Conquer.Scripts.Models
{

    public class ConquerFieldData
    {

        [SerializeField]
        private Vector2 _cellSize = Vector2.one;

        private List<CellData> _cells;

        public static CellData DefaultCell = new CellData()
        {
            Owner = -1,
            Cost = -1,
            Position = new Vector2Int(),
        };

        public ConquerFieldData(Vector2Int size)
        {
            _cells = new List<CellData>();
            Size = size;
            CreateCells();
        }

        public Vector2 CellSize => _cellSize;

        public Vector2Int Size { get; protected set; }

        public CellData this[int row, int column]
        {
            get
            {
                if (Size == Vector2Int.zero)
                    return DefaultCell;

                if (!column.IsInRange(0,Size.x) || !row.IsInRange(0,Size.y))
                    return DefaultCell;

                var index = Size.x * row + column;
                return _cells[index];

            }
        }

        private void CreateCells()
        {
            for (var i = 0; i < Size.y; i++)
            {
                for (var j = 0; j < Size.x; j++)
                {
                    var cell = new CellData() {
                        Position = new Vector2Int(j,i),
                        Cost = 0,
                        Owner = 0,
                    };
                    _cells.Add(cell);
                }
            }
        }
    }

}
