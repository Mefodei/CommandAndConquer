
using Assets.Tools.UnityTools.ObjectPool.Scripts;
using Conquer.Scripts.Field;
using UnityEngine;

namespace Assets.Conquer.Scripts.Field
{
    public class FieldItemFactory : IUniItemFactory<CellItemView>
    {
        private readonly CellItemView _view;

        public FieldItemFactory(CellItemView view) {
            _view = view;
        }

        public CellItemView Create(Vector3 position, Quaternion rotation, Transform parent = null, bool stayAtWorld = false)
        {

            return _view.Spawn(position, rotation,parent,stayAtWorld);

        }

    }
}
