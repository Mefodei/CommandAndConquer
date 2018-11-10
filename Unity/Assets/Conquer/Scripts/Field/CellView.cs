using Assets.Conquer.Scripts.Models;
using UnityEngine;

namespace Assets.Conquer.Scripts.Field
{
    public class CellView : MonoBehaviour
    {
        private CellData _cellData;

        public void Initialize(CellData cellData)
        {
            _cellData = cellData;
        }

    }
}
