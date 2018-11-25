using System;
using Assets.Conquer.Scripts.Field;
using Assets.Conquer.Scripts.Info;
using Assets.Tools.UnityTools.ActorEntityModel;
using Assets.Tools.UnityTools.Interfaces;
using UniRx;
using UniStateMachine.Nodes;
using UnityEngine;

namespace Assets.Scripts
{
    public class BootLoader : MonoBehaviour {

        private IDisposable _gameDisposable;
        private IContext _context;

        [SerializeField]
        private ConquerGameField _conquerGameField;

        [SerializeField]
        private ConquerGameConfiguration _configuration;

        [SerializeField]
        private Camera _gameCamera;

        public UniStatesGraph GameStateBehaviour;

        // Use this for initialization
        private void Start()
        {
            _context = new EntityObject();

            _context.Add(_configuration);
            _context.Add(_conquerGameField);
            _context.Add(_gameCamera);

            DontDestroyOnLoad(gameObject);

            StartGameBehaviour();
        }

        private void StartGameBehaviour()
        {
            GameStateBehaviour.Execute(_context);
        }

        private void OnDisable()
        {
            GameStateBehaviour.Stop();
        }

        private void OnDestroy()
        {
            _gameDisposable?.Dispose();
        }

    }
}
