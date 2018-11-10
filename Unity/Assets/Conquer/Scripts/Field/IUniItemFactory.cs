using UnityEngine;

namespace Assets.Conquer.Scripts.Field
{

    public interface IUniItemFactory<out TResult>
    {
        TResult Create(Vector3 position, Quaternion rotation, Transform parent = null, bool stayAtWorld = false);
    }
}