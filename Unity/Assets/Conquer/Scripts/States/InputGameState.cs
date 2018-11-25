using System.Collections;
using Assets.Conquer.Scripts.Field;
using Assets.Conquer.Scripts.Models;
using Assets.Tools.UnityTools.Interfaces;
using Assets.Tools.UnityTools.ObjectPool.Scripts;
using UniStateMachine;
using UnityEngine;

namespace Conquer.States
{
    [CreateAssetMenu(fileName = "InputGameState", menuName = "Conquer/States/InputGameState")]
    public class InputGameState : UniNode
    {
        [SerializeField]
        private LayerMask _layerMask;

        private CellItemView _cellItem;

        protected override IEnumerator ExecuteState(IContext context)
        {

            var itemFactory = context.Get<IUniItemFactory<CellItemView>>();
            var camera = context.Get<Camera>();
            var gameField = context.Get<ConquerGameField>();
            var gameData = context.Get<ConquerGameData>();
            UpdateStepData(gameData);

            while (true)
            {
                yield return null;

                if(Input.GetMouseButtonDown(1))
                    UpdateStepData(gameData);

                if (Input.GetMouseButton(0))
                {

                    var mousePosition = Input.mousePosition;
                    var ray = camera.ScreenPointToRay(mousePosition);
                    var hitResult = Physics.Raycast(ray, out var hit, _layerMask);

                    if (!hitResult || gameField.transform != hit.transform)
                        continue;

                    UpdateCellItem(hit.point, itemFactory, gameField);

                    ApplyView(_cellItem, gameData);

                }
                else
                {
                    ReleaseView();
                }


            }
        }

        private void ApplyView(CellItemView view,ConquerGameData gameData)
        {
            var size = gameData.ActiveStep.ItemSize.Value;
            var scale = view.transform.localScale;
            view.transform.localScale = new Vector3(size.x, scale.y, size.y);
        }

        private void UpdateStepData(ConquerGameData gameData) {

            var x = Random.Range(1, 7);
            var y = Random.Range(1, 7);
            gameData.ActiveStep.ItemSize.Value = new Vector2(x,y);

        }

        private void UpdateCellItem(Vector3 position,
            IUniItemFactory<CellItemView> factory,
            ConquerGameField gameField )
        {
            var cellPosition = gameField.GetCellPosition(position);

            if (_cellItem == null)
            {
                _cellItem = factory.Create(cellPosition, Quaternion.identity);
                _cellItem.gameObject.SetActive(true);
            }

            _cellItem.transform.position = cellPosition;

        }

        protected override void OnExit(IContext context)
        {
            ReleaseView();
        }

        private void ReleaseView()
        {
            _cellItem?.Despawn();
            _cellItem = null;
        }
    }
}
