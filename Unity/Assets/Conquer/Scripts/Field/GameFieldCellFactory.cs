
using Assets.Tools.UnityTools.ActorEntityModel;
using Assets.Tools.UnityTools.ObjectPool.Scripts;
using Conquer.Scripts.Info;

namespace Assets.Conquer.Scripts.Field
{
    public class GameFieldCellFactory : IGameFieldCellFactory
    {
        private readonly CellItemsMapInfo _info;

        public GameFieldCellFactory(CellItemsMapInfo info)
        {
            _info = info;
        }

        public Actor Create(int type, int area)
        {
            var actor = ClassPool.Spawn<Actor>();
            var model = _info.Create(type, area);
            actor.SetModel(model);
            return actor;
        }

    }
}
