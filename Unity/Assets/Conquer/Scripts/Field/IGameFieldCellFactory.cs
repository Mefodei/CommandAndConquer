using Assets.Tools.UnityTools.ActorEntityModel;
using Conquer.Scripts.Field;

namespace Assets.Conquer.Scripts.Field
{
    public interface IGameFieldCellFactory
    {
        Actor Create(int type,int width, int height);
    }
}