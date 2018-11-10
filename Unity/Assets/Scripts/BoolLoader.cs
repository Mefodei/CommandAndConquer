using System;
using Assets.Conquer.Scripts.Field;
using Assets.Conquer.Scripts.Info;
using Assets.Tools.UnityTools.ActorEntityModel;
using Assets.Tools.UnityTools.Interfaces;
using Assets.Tools.UnityTools.StateMachine.UniStateMachine;
using UniRx;
using UnityEngine;

namespace Assets.Scripts
{
    public class BoolLoader : MonoBehaviour {

        private IDisposable _gameDisposable;
        private IContext _context;

        [SerializeField]
        private ConquerGameField _conquerGameField;

        [SerializeField]
        private ConquerGameConfiguration _configuration;

        [SerializeField]
        private Camera _gameCamera;

        public UniStateBehaviour GameStateBehaviour;

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

            _gameDisposable = Observable.
                FromCoroutine(x => GameStateBehaviour.Execute(_context)).
                Subscribe();

        }

        private void OnDestroy()
        {
            _gameDisposable?.Dispose();
        }

    }
}
