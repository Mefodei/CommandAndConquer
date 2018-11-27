using Assets.Tools.UnityTools.Interfaces;
using Assets.Tools.UnityTools.ObjectPool.Scripts;
using Conquer.Scripts.Field;
using Conquer.Scripts.Info;
using UniRx;

namespace Conquer.Scripts.Models
{
	public class CellItemModel : ActorModel, IPoolable
	{
		
		private CellItemInfo _info;

		public void Initialize(CellItemInfo info)
		{
			_info = info;
			View.Value = _info.View.Spawn();
		}

	    public override void Release()
	    {

            _info = null;
            Column.Value = 0;
	        Row.Value = 0;
	        Fixed.Value = false;
	        View.Value?.Despawn();
	        View.Value = null;

	        base.Release();

	    }

	    public override void AddContextData(IContext context)
	    {
	        base.AddContextData(context);
            context.Add(View.Value);

	    }

	    public CellItemInfo CellInfo => _info;

		public IntReactiveProperty Column = new IntReactiveProperty();

		public IntReactiveProperty Row = new IntReactiveProperty();

		public BoolReactiveProperty Fixed = new BoolReactiveProperty(false);

        public ReactiveProperty<CellItemView> View => new ReactiveProperty<CellItemView>();
	}
}
