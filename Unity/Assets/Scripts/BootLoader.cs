using System;
using Assets.Conquer.Scripts.Field;
using Assets.Conquer.Scripts.Info;
using Assets.Tools.UnityTools.ActorEntityModel;
using Assets.Tools.UnityTools.Interfaces;
using Assets.Tools.UnityTools.UniRoutine;
using UniRx;
using UniStateMachine.Nodes;
using UnityEngine;

namespace Assets.Scripts
{
    public class BootLoader : MonoBehaviour {

        private IDisposable _gameDisposable;
        private IContext _context;
        private IDisposableItem _graphDisposableItem;

        [SerializeField]
        private ConquerGameField _conquerGameField;

        [SerializeField]
        private Camera _gameCamera;

        public UniStatesGraph GameStateBehaviour;

        // Use this for initialization
        private void Start()
        {
            _context = new EntityObject();

            _context.Add(_conquerGameField);
            _context.Add(_gameCamera);

            DontDestroyOnLoad(gameObject);

            StartGameBehaviour();
        }

        private void StartGameBehaviour()
        {
            _graphDisposableItem = GameStateBehaviour.Execute(_context).RunWithSubRoutines();
        }

        private void OnDisable()
        {
            _graphDisposableItem?.Dispose();
            _graphDisposableItem = null;
            GameStateBehaviour.Dispose();
        }

        private void OnDestroy()
        {
            _gameDisposable?.Dispose();
        }

    }
}
