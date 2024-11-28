using Core.Camera;
using DI;
using Reflex.Attributes;
using Skills;
using UI.Game.FMS;
using UI.Game.FMS.States;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enviroment.Levels
{
    public class LevelLocation : MonoBehaviour
    {
        private const float MinPositionX = -50;
        private const float MaxPositionX = 50;

        [SerializeField] private Transform _playerStartPosition;
        [SerializeField] private Transform _priseSkillPosition;
        [SerializeField] private bool _isRandomX = true;
        [SerializeField] private Vector3 _offsetCamera = new Vector3(.0f, 3f, -3.0f);

        public Transform PlayerStartPosition => _playerStartPosition;

        [Inject] private StateMashineUI _stateMashineUI;
        [Inject] private GameLevelCamera _camera;

        private void Awake()
        {
            if(_isRandomX)
                ChangeRandomPositionX();

            DIGameConteiner.Instance.InjectRecursive(gameObject);
        }

        private void Start()
        {
            _stateMashineUI.EnterIn<LevelInitUIState>();
            _camera.SetDistance(_offsetCamera);
        }

        public void SetPriseSkill(Skill skill)
        {
            if (skill == null)
                return;

            SkillItem skillItem = Instantiate(skill.Item, _priseSkillPosition);
            skillItem.Buinding(skill);
        }

        private void ChangeRandomPositionX()
        {
            float x = Random.Range(MinPositionX, MaxPositionX);
            transform.position = new Vector3(x, 0, 0);
        }
    }
}