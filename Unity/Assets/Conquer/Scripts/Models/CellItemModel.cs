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
		    Behaviour.Value = _info.Behaviour;
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
		    context.Add(this);
		    context.Add(_info);
            context.Add(View.Value);

	    }

	    public CellItemInfo CellInfo => _info;

		public IntReactiveProperty Column { get; } = new IntReactiveProperty();

		public IntReactiveProperty Row { get; } = new IntReactiveProperty();

		public BoolReactiveProperty Fixed { get; } = new BoolReactiveProperty(false);

        public ReactiveProperty<CellItemView> View { get; } = new ReactiveProperty<CellItemView>();
	}
}
