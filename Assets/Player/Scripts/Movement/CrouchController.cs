using UnityEngine;

[System.Serializable]  // Позволяет сериализацию класса для отображения в инспекторе Unity
public class CrouchController
{
    [SerializeField] private float _crouchHeight = 1f;           // Высота персонажа в приседе
    [SerializeField] private float _standingHeight = 2f;         // Высота персонажа в стоячем положении
    [SerializeField] private float _crouchTransitionSpeed = 5f;  // Скорость перехода между положениями
    [SerializeField] private float _typeOfCrunch = 0;

    private CharacterController _characterController;            // Ссылка на компонент CharacterController
    private bool _isCrouching;                                    // Флаг, определяющий, находится ли персонаж в приседе

    public void Initialize(CharacterController characterController)
    {
        // Сохраняем ссылку на CharacterController
        _characterController = characterController;
    }

    public void HandleCrouch()
    {
        switch (_typeOfCrunch) // Выбор типа приседаний
            { case 0:
                // Если нажата клавиша Left Control, начинаем приседать
                if (Input.GetKeyDown(KeyCode.LeftControl))
                {
                    _isCrouching = true;
                }
                // Если отпущена клавиша Left Control, встаем
                else if (Input.GetKeyUp(KeyCode.LeftControl))
                {
                    _isCrouching = false;
                }
                break;
                case 1:
                // Если нажата клавиша Left Control, меняем положение
                if (Input.GetKeyDown(KeyCode.LeftControl))
                {
                    _isCrouching = !_isCrouching;
                }
                break;


        }





        // Устанавливаем целевую высоту в зависимости от состояния персонажа
        float targetHeight = _isCrouching ? _crouchHeight : _standingHeight;

        // Плавный переход высоты персонажа к целевой высоте
        _characterController.height = Mathf.Lerp(
            _characterController.height,
            targetHeight,
            Time.deltaTime * _crouchTransitionSpeed
        );
    }
}