using System.Collections.Generic;
using UnityEngine;

namespace Conquer.Info
{
    [CreateAssetMenu(menuName = "Conquer/Info/CellSkinsInfo", fileName = "CellSkinsInfo")]
    public class CellSkinsInfo : ScriptableObject
    {
        public string Name;
        public List<CellItemInfo> CellItemInfos;
    }
}