using UnityTools.ActorEntityModel;
using Conquer.Field;

namespace Assets.Conquer.Scripts.Field
{
    public interface IGameFieldCellFactory
    {
        Actor Create(int type,int width, int height);
    }
}