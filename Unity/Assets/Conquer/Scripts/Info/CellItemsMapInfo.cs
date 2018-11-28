using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Conquer.Scripts.Info
{
    [CreateAssetMenu(menuName = "Conquer/Info/CellItemsMap",fileName = "CellItemsMapInfo")]
	public class CellItemsMapInfo : ScriptableObject
	{
        [NonSerialized]
		private Dictionary<int, CellSkinsInfo> _cellInfos;
			
		#region inspector 
		
		[SerializeField]
		private List<CellSkinsInfo> _cellItemInfos = new List<CellSkinsInfo>();

        [SerializeField]
        private List<string> _skinNames = new List<string>();

        #endregion

        public IReadOnlyList<string> SkinNames => _skinNames;
		
		public IReadOnlyList<CellSkinsInfo> CellItemInfos => _cellItemInfos;

	    public void Add(CellSkinsInfo cellItems)
	    {
	        _cellItemInfos.Add(cellItems);
            _skinNames.Add(cellItems.Name);
        }

	    public void Clear()
	    {
	        _skinNames.Clear();
            _cellItemInfos.Clear();

        }

		public CellItemInfo GetCellInfo(int type, int width, int height)
		{
			if(_cellInfos == null)
				Initialize();
			var cell = _cellInfos[type].CellItemInfos.
				FirstOrDefault(x => x.Width == width && x.Height == height || 
				                    x.Width == height && x.Height == width);
			return cell;
		}
		
		public ActorModel Create(int type, int width, int height)
		{
			var cell = GetCellInfo(type, width, height);
		    var model = cell.Create();
		    return model;
		}
        
		private void Initialize()
		{
			_cellInfos = new Dictionary<int, CellSkinsInfo>();
		    var index = 0;
			foreach (var cellItemInfo in _cellItemInfos)
			{
				_cellInfos[index] = cellItemInfo;
			    index++;

			}
		}
	}
}
