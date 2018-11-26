using System.Collections.Generic;
using System.Linq;
using Conquer.Scripts.Field;
using UnityEngine;

namespace Conquer.Scripts.Info
{
	[CreateAssetMenu(menuName = "Conquer/Info/CellItemsMap",fileName = "CellItemsMapInfo")]
	public class CellItemsMapInfo : ScriptableObject
	{

		private Dictionary<int, List<CellItemInfo>> _cellInfos;
			
		#region inspector 
		
		[SerializeField]
		private List<CellItemInfo> _cellItemInfos = new List<CellItemInfo>();

		#endregion
		
		public IReadOnlyList<CellItemInfo> CellItemInfos => _cellItemInfos;


		public CellItemView Create(int type,int area)
		{
			if(_cellInfos == null)
				Initialize();

			var cell = _cellInfos[type].FirstOrDefault(x => x.Size == area);
			
			
		}


		private void Initialize()
		{
			_cellInfos = new Dictionary<int, List<CellItemInfo>>();
			foreach (var cellItemInfo in _cellItemInfos)
			{
				var type = cellItemInfo.Type;
				if (!_cellInfos.TryGetValue(type, out var list))
				{
					list = new List<CellItemInfo>();
					_cellInfos[type] = list;
				}
				_cellInfos[type].Add(cellItemInfo);
			}
		}
	}
}
