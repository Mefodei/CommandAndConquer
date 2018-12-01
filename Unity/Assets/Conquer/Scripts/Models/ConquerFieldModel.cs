using System.Collections.Generic;
using Assets.Tools.UnityTools.Math;
using UnityEngine;

namespace Assets.Conquer.Scripts.Models
{

    public class ConquerFieldModel
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

        public ConquerFieldModel(Vector2Int size)
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

                row = Mathf.Clamp(row,0, Size.y - 1);
                column = Mathf.Clamp(column, 0, Size.x - 1);
                var index = Size.x * row + column;

                return _cells[index];

            }
            
        }

        public bool ValidateIndex(int x, int y)
        {
            var size = Size;
            return x.IsInRange(new Vector2Int(0, size.x)) &&
                   y.IsInRange(new Vector2Int(0, size.y));
        }

        public (RectInt position,bool canBePlaced) Validate(RectInt rect)
        {
            var maxPosition = rect.max;
            var min = new Vector2Int(0,0);
            var max = new Vector2Int(Size.x, Size.y);
            maxPosition.Clamp(min, max);
            var resultPosition = maxPosition - rect.size;
            resultPosition.Clamp(min, max);
            var itemRect = new RectInt(resultPosition,rect.size);
            
            for (var column = itemRect.x; column < itemRect.xMax; column++)
            {
                for (var row = itemRect.y; row < itemRect.yMax; row++)
                {
                    var cell = this[row, column];
                    if (cell.Owner != 0)
                        return (itemRect,false);
                }
            }

            return (itemRect, true);
        }


        public void UpdateOwnerAtRange(RectInt rect, int value)
        {
            var max = rect.max;
            for (var column = rect.x; column < max.x; column++)
            {
                for (var row = rect.y; row < max.y; row++)
                {
                    var cell = this[row, column];
                    cell.Owner = value;
                }
            }
        }

        public void SetOwner(int row, int column, int owner)
        {
            var cell = this[row, column];
            cell.Owner = owner;
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
