using System;
using Assets.Conquer.Scripts.Field;
using Assets.Conquer.Scripts.Info;
using UnityTools.ActorEntityModel;
using Assets.Tools.UnityTools.Interfaces;
using Assets.Tools.UnityTools.UniRoutine;
using UniRx;
using UniStateMachine.Nodes;
using UnityEngine;

namespace Assets.Scripts
{
    public class BootLoader : MonoBehaviour 
    {

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
            _context.LifeTime.AddDispose(_graphDisposableItem);
        }

        private void OnDisable()
        {
            _context.Release();
            _graphDisposableItem = null;
            GameStateBehaviour.Dispose();
        }

    }
}
