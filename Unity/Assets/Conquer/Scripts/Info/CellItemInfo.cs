using Assets.Tools.UnityTools.ActorEntityModel;
using Assets.Tools.UnityTools.ObjectPool.Scripts;
using Conquer.Scripts.Field;
using Conquer.Scripts.Models;
using UnityEngine;

namespace Conquer.Scripts.Info
{
	[CreateAssetMenu(fileName = "CellItemInfo",menuName = "Conquer/Info/CellItemInfo")]
	public class CellItemInfo : ActorInfo
	{
		[SerializeField]
		private int _type;

	    [SerializeField]
		private int _size;

		[SerializeField]
		private CellItemView _view;

		public int Type => _type;

		public int Size => _size;

		public CellItemView View => _view;
        
        public override ActorModel Create()
		{
			var cellModel = ClassPool.Spawn<CellItemModel>();
            cellModel.Initialize(this);
			return cellModel;
		}
	}
}
