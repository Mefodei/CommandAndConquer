using System.Collections;
using Assets.Conquer.Scripts.Field;
using Assets.Tools.UnityTools.Interfaces;
using Assets.Tools.UnityTools.ObjectPool.Scripts;
using Assets.Tools.UnityTools.StateMachine.UniStateMachine;
using UnityEngine;

namespace Assets.Conquer.Scripts.States
{
    [CreateAssetMenu(fileName = "InputGameState", menuName = "Conquer/States/InputGameState")]
    public class InputGameState : UniStateBehaviour
    {
        [SerializeField]
        private LayerMask _layerMask;

        protected override IEnumerator ExecuteState(IContext context)
        {

            var itemFactory = context.Get<IUniItemFactory<CellItemView>>();
            var camera = context.Get<Camera>();
            var gameField = context.Get<ConquerGameField>();

            CellItemView cellView = null;

            while (true)
            {
                yield return null;

                if (Input.GetMouseButton(0))
                {
                    var mousePosition = Input.mousePosition;
                    var ray = camera.ScreenPointToRay(mousePosition);
                    var hitResult = Physics.Raycast(ray, out var hit, _layerMask);

                    if(!hitResult || gameField.transform != hit.transform)
                        continue;

                    var cellPosition = gameField.GetCellPosition(hit.point);

                    if (cellView == null){
                        cellView = itemFactory.Create(cellPosition,Quaternion.identity);
                        cellView.gameObject.SetActive(true);
                    }

                    cellView.transform.position = cellPosition;
                }
                else
                {
                    cellView?.Despawn();
                    cellView = null;
                }


            }
        }


    }
}
