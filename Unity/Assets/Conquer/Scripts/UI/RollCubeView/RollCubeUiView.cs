using System;
using System.Collections.Generic;
using Assets.SubModules.UnityTools.UiViews;
using Assets.Tools.UnityTools.Interfaces;
using Conquer.Messages;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.Events;
using UnityTools.UiViews;

namespace Assets.Conquer.Scripts.UI
{
    class RollCubeUiModel
    {

        public IntReactiveProperty Width = new IntReactiveProperty();
        public IntReactiveProperty Height = new IntReactiveProperty();

    }

    public class RollCubeUiView : UiViewBehaviour
    {

        private List<string> _numbers = new List<string>();

        private RollCubeUiModel _model = new RollCubeUiModel();

        #region inspector

        private int _maxNumber = 20;

        [SerializeField]
        private TextMeshProUGUI _width;

        [SerializeField]
        private TextMeshProUGUI _height;

        #endregion

        public void MakeRoll()
        {
            Context.Publish(new MakeTheRollCubesMessage());
        }

        public void Commit()
        {
            Context.Publish(new CommitCellSelectionMessage());
        }
        
        #region protected
        
        protected override void Activate()
        {
            InitializeModel();

            var item = Context.Receive<RollTheCubeResultMessage>().Subscribe(OnCubeResultChanged);
            Context.LifeTime.AddDispose(item);
        }

        protected override void Deactivate(){}

        protected override void OnUpdateView()
        {
            _width.SetText(_numbers[_model.Width.Value]);
            _height.SetText(_numbers[_model.Height.Value]);
            base.OnUpdateView();
        }

        protected override void OnInitialize()
        {
            _numbers.Clear();
            for (int i = 0; i < _maxNumber; i++)
            {
                _numbers.Add(i.ToString());
            }
        }

        protected void OnCubeResultChanged(RollTheCubeResultMessage cubeResult)
        {
            _model.Width.Value = cubeResult.Width;
            _model.Height.Value = cubeResult.Height;
        }

        protected void InitializeModel()
        {
            var item = _model.Width.Subscribe(x => UpdateView());
            Context.LifeTime.AddDispose(item);

            item = _model.Width.Subscribe(x => UpdateView());
            Context.LifeTime.AddDispose(item);
        }

        #endregion
    }
}
