using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LSD.Movement
{
    public class InputMovement : Movement
    {
        [SerializeField]
        private float _jumpVelocity = 10f;
        [SerializeField]
        private int _jumps = 2;
        [SerializeField]
        private UnityEvent _onJump = null;
        [SerializeField]
        private InputAxis _inputAxis = InputAxis.Horizontal;

        private int _jumpsLeft = 0;

        private int _directionMultiplier = 1;

        private float _input = 0f;
        private bool _isJumpButtonDown = false;
        private bool _isDropButtonDown = false;

        private Move _move = null;

        private void Awake()
        {
            _move = GetComponent<Move>();
        }

        private void Update()
        {
            if (Input.GetButtonDown("Jump"))
            {
                _isJumpButtonDown = true;
            }

            if (Input.GetButtonDown("Drop"))
            {
                _isDropButtonDown = true;
            }

            _input = Input.GetAxisRaw(_inputAxis.GetStringValue());
        }

        public override Vector2 GetVelocity()
        {
            float x = _input * Speed;
            float y = 0f;

            if (_isDropButtonDown)
            {
                y = _jumpVelocity * -_directionMultiplier;
                _isDropButtonDown = false;
            }

            if (_isJumpButtonDown)
            {
                y = TryJump();
                _isJumpButtonDown = false;
            }

            switch (_inputAxis)
            {
                case InputAxis.Horizontal:
                    return x * Vector2.right + y * Vector2.up;
                case InputAxis.Vertical:
                    return x * Vector2.up + y * Vector2.right;
                default:
                    Debug.Log("Invalid _inputAxis value;");
                    return Vector2.zero;
            }
        }

        private float TryJump()
        {
            if (_jumpsLeft > 0)
            {
                _onJump.Invoke();
                _jumpsLeft--;
                return _jumpVelocity * _directionMultiplier;
            }

            return 0f;
        }

        public void ResetJumps()
        {
            _jumpsLeft = _jumps;
        }

        public void ChangeInput(int gravityDirectionValue)
        {
            GravityDirection gravityDirection = (GravityDirection)gravityDirectionValue;
            switch (gravityDirection)
            {
                case GravityDirection.Up:
                    _inputAxis = InputAxis.Horizontal;
                    _directionMultiplier = -1;
                    break;
                case GravityDirection.Down:
                    _inputAxis = InputAxis.Horizontal;
                    _directionMultiplier = 1;
                    break;
                case GravityDirection.Right:
                    _inputAxis = InputAxis.Vertical;
                    _directionMultiplier = -1;
                    break;
                case GravityDirection.Left:
                    _inputAxis = InputAxis.Vertical;
                    _directionMultiplier = 1;
                    break;
                default:
                    break;
            }
        }
    }
}
