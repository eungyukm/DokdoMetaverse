using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NGS.AdvancedRenderSystem.Examples
{
    public class FPSCounter : MonoBehaviour
    {
        [SerializeField]
        private Text _textField;

        private float _passed;
        private int _frames;

        private void Start()
        {
            Application.targetFrameRate = 60;
        }

        private void Update()
        {
            _passed += Time.deltaTime;
            _frames++;

            if (_passed > 1)
            {
                if(_textField) _textField.text = _frames.ToString();

                _passed = 0;
                _frames = 0;
            }
        }
    }
}
