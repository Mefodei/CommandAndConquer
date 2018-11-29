using UnityTools.ActorEntityModel;
using Assets.Tools.UnityTools.ObjectPool.Scripts;
using Conquer.Field;
using Conquer.Models;
using UniStateMachine.Nodes;
using UnityEngine;

namespace Conquer.Info
{
	[CreateAssetMenu(fileName = "CellItemInfo",menuName = "Conquer/Info/CellItemInfo")]
	public class CellItemInfo : ActorInfo
	{
	    [SerializeField]
        private string _skinType;

		[SerializeField]
		private int _type;

	    [SerializeField]
        private int _width;

        [SerializeField]
        private int _height;

		[SerializeField]
		private CellItemView _view;

	    public string SkinType => _skinType;

		public int Type => _type;

	    public int Height => _height;

	    public int Width => _width;

		public int Area => _height * _width;

		public CellItemView View => _view;

	    public void Initialize(string skinType, UniStatesGraph graph, CellItemView view)
	    {

	        _skinType = skinType;
	        _statesGraph = graph;

            _width = view.Width;
	        _height = view.Height;
	        _view = view;

	    }

        public override ActorModel Create()
		{
			var cellModel = ClassPool.Spawn<CellItemModel>();
			cellModel.Initialize(this);
			return cellModel;
		}
	}
}
