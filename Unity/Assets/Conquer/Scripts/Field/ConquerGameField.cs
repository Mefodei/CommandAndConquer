using System.Collections.Generic;
using Assets.Conquer.Scripts.Models;
using UnityEngine;

namespace Assets.Conquer.Scripts.Field
{

    public class ConquerGameField : MonoBehaviour
    {

        private ConquerFieldData _fieldData;
        private List<CellView> _cellViews = new List<CellView>();

        #region inspector data

        [SerializeField]
        private Vector3 _cellItemsOffset = new Vector3(0f,1f, 0f);
        [SerializeField]
        private Vector3 _pivotOffset = new Vector3(0.5f,0, 0.5f);
        [SerializeField]
        private Vector2 _defaultSize = new Vector2(0.1f, 0.1f);
        [SerializeField]
        private Transform _fieldObject;
        [SerializeField]
        private Transform _pivot;
        [SerializeField]
        private CellView _cellObject;

        #endregion

        public void Initialize(ConquerFieldData fieldData)
        {
            _fieldData = fieldData;
            UpdateGameField();
        }

        public Vector3 GetCellPosition(Vector3 position)
        {

            var cellData = GetCell(position);
            if (cellData == ConquerFieldData.DefaultCell)
                return Vector3.zero;

            var cellPosition = cellData.Position;

            var index = cellPosition.y * _fieldData.Size.x + cellPosition.x;
            return _cellViews[index].transform.position + _cellItemsOffset;

        }

        public CellData GetCell(Vector3 position)
        {
            var cellPosition = position - _pivot.position;

            if (cellPosition.x < 0 || cellPosition.z < 0)
                return ConquerFieldData.DefaultCell;

            var y = cellPosition.z / _fieldData.CellSize.y;
            var x = cellPosition.x / _fieldData.CellSize.x;

            var row = Mathf.RoundToInt(y);
            var column = Mathf.RoundToInt(x);

            var cell = _fieldData[row, column];
            return cell;

        }

        private void UpdateGameField()
        {

            var size = _fieldData.Size * _defaultSize;
            _fieldObject.localScale = new Vector3(size.x,_fieldObject.transform.localScale.y, size.y);

            for (var i = 0; i < _fieldData.Size.x; i++)
            {

                for (var j = 0; j < _fieldData.Size.y; j++) {
                    var cell = CreateCell(j, i);
                    _cellViews.Add(cell);
                }

            }
        }

        private CellView CreateCell(int row, int column)
        {
            var position = _fieldObject.transform.position;
            var pivotPosition = _pivot.position;
            var size = _fieldData.CellSize;

            var cellPosition =  new Vector3(pivotPosition.x + size.x * column, position.y, pivotPosition.z + size.y * row);
            cellPosition += _pivotOffset;
            var cell = Instantiate(_cellObject, cellPosition, Quaternion.identity, transform);
            cell.gameObject.SetActive(true);

            return cell;
        }

    }
}
