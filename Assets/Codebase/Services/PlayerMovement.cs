using UnityEngine;

namespace Core
{
    public class PlayerMovement : IUpdatable
    {
        private GameObject _playerRepresentation;
        private IJ _currentPosition;
        private MapCreationBehaviour _mapCreationBehaviour;

        public void Move(EMoveDirection direction)
        {
            InitializeIfNeeded();
            var newStep = _currentPosition;

            switch (direction)
            {
                case EMoveDirection.Down:
                    {
                        newStep.y--;
                        break;
                    }
                case EMoveDirection.Up:
                    {
                        newStep.y++;
                        break;
                    }
                case EMoveDirection.Left:
                    {
                        newStep.x--;
                        break;
                    }
                case EMoveDirection.Right:
                    {
                        newStep.x++;
                        break;
                    }
            }
            var node = _mapCreationBehaviour.GetNode(newStep);

            if (node != null)
            {
                node.interaction.PerformInteraction(new Vector3(newStep.x, 0f, newStep.y));
                if (!node.isObstacle)
                {
                    _currentPosition = newStep;
                    MoveRepresetnation();
                }
            }
        }

        private void InitializeIfNeeded()
        {
            if (_mapCreationBehaviour == null)
            {
                _mapCreationBehaviour = GameObject.FindObjectOfType<MapCreationBehaviour>();
            }

            if (_playerRepresentation == null)
            {
                _playerRepresentation = new GameObject("Player");
                _playerRepresentation.AddComponent<AudioListener>();
                _currentPosition = _mapCreationBehaviour.startPositionIJ;
                MoveRepresetnation();
            }
        }

        public void Dispose()
        {
            GameObject.Destroy(_playerRepresentation);
            _mapCreationBehaviour = null;
        }

        public void PerformUpdate()
        {
            //Nothing currently needed here.
        }

        private void MoveRepresetnation()
        {
            var position = new Vector3(_currentPosition.x, 0f, _currentPosition.y);
            _playerRepresentation.transform.LookAt(position);
            _playerRepresentation.transform.position = position;
        }
    }
}

