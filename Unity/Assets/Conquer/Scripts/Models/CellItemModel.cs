using Assets.Tools.UnityTools.Interfaces;
using Assets.Tools.UnityTools.ObjectPool.Scripts;
using Conquer.Field;
using Conquer.Info;
using UniRx;
using UnityEngine;

namespace Conquer.Models
{
	public class CellItemModel : ActorModel
	{
		private static int _cellId;
		
		private CellItemInfo _info;

		public void Initialize(CellItemInfo info)
		{
			Initialize();
			
			_info = info;
			
			CellId.Value = ++_cellId;
			View.Value = _info.View.Spawn();
		    Behaviour.Value = _info.Behaviour;
		}

	    public override void Release()
	    {

            _info = null;
		    Id.Value = 0;
            Column.Value = 0;
	        Row.Value = 0;
	        Fixed.Value = false;
	        View.Value?.Despawn();
	        View.Value = null;
		    CellId.Value = 0;
		    
	        base.Release();

	    }

	    public override void AddContextData(IContext context)
	    {
		    
	        base.AddContextData(context);
		    context.Add(this);
		    context.Add(_info);
            context.Add(View.Value);

	    }

		
	    public CellItemInfo CellInfo => _info;

		public IntReactiveProperty CellId  = new IntReactiveProperty();
		
		public IntReactiveProperty Column = new IntReactiveProperty();

		public IntReactiveProperty Row = new IntReactiveProperty();

		public BoolReactiveProperty Fixed = new BoolReactiveProperty(false);
		
        public ReactiveProperty<CellItemView> View = new ReactiveProperty<CellItemView>();
	}
}
