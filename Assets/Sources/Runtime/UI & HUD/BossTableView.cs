﻿using UnityEngine;
using UnityEngine.UI;

namespace Sources.Runtime
{
    public class BossTableView : MonoBehaviour
    {
        [SerializeField]
        private Button _golemButton;
        [SerializeField]
        private Button _reaperButton;
        [SerializeField]
        private Button _closeButton;
        
        private SceneLoader _sceneLoader;
        
        public void Init(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
            _golemButton.onClick.AddListener(() => _sceneLoader.LoadGolemRoom());
            _reaperButton.onClick.AddListener(() => _sceneLoader.LoadReaperRoom());
            _closeButton.onClick.AddListener(() => gameObject.SetActive(false));
        }
    }
}