using UnityEngine;

namespace Assets.Conquer.Scripts.Info
{
    [CreateAssetMenu(fileName = "ConquerGameConfiguration", menuName = "Conquer/GameConfiguration")]
    public class ConquerGameConfiguration : ScriptableObject
    {

        public Vector2Int FieldSize = new Vector2Int(10,10);

        public GameObject CellObject;

    }
}
