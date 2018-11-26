using Conquer.Scripts.Info;
using UniRx;

namespace Conquer.Scripts.Models
{
	public class CellItemModel : ActorModel
	{
		
		private readonly CellItemInfo _info;

		public CellItemModel(CellItemInfo info)
		{
			_info = info;
		}

		public CellItemInfo CellInfo => _info;

		public IntReactiveProperty Column = new IntReactiveProperty();

		public IntReactiveProperty Row = new IntReactiveProperty();

		public BoolReactiveProperty Fixed = new BoolReactiveProperty(false);

	}
}
