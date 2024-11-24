using UnityEngine;

[RequireComponent(typeof(CharacterController))]  // Требует наличия компонента CharacterController
public class PlayerController : MonoBehaviour
{
    [SerializeField] private MovementController _movementController;  // Контроллер движений
    [SerializeField] private JumpController _jumpController;          // Контроллер прыжков
    [SerializeField] private CrouchController _crouchController;      // Контроллер приседаний

    private CharacterController _characterController;                 // Ссылка на компонент CharacterController
    private Vector3 _velocity;                                         // Текущая скорость персонажа
    private bool _isGrounded;                                          // Флаг, стоящий ли персонаж на земле

    private void Start()
    {
        // Получаем ссылку на компонент CharacterController
        _characterController = GetComponent<CharacterController>();

        // Инициализируем контроллеры движений и приседаний
        _movementController.Initialize(_characterController);
        _crouchController.Initialize(_characterController);
    }

    private void Update()
    {
        // Определяем, стоит ли персонаж на земле
        _isGrounded = _characterController.isGrounded;

        // Обрабатываем перемещение персонажа
        _movementController.Move(_isGrounded);

        // Обрабатываем прыжок
        _jumpController.HandleJump(ref _velocity, _isGrounded);

        // Обрабатываем приседание
        _crouchController.HandleCrouch();

        // Применяем гравитацию
        ApplyGravity();
    }

    private void ApplyGravity()
    {
        // Если персонаж стоит на земле и его вертикальная скорость отрицательна,
        // устанавливаем минимально допустимую скорость падения
        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }

        // Учитываем силу тяжести
        _velocity.y += _jumpController.Gravity * Time.deltaTime;

        // Перемещаем персонажа с учётом текущей скорости
        _characterController.Move(_velocity * Time.deltaTime);
    }
}