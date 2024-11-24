using UnityEngine;

[System.Serializable]  // Позволяет сериализировать класс для отображения в инспекторе Unity
public class MovementController
{
    [SerializeField] private float _walkSpeed = 4f;       // Скорость ходьбы
    [SerializeField] private float _runSpeed = 8f;        // Скорость бега
    [SerializeField] private float _airControlMultiplier = 0.5f;  // Множитель контроля в воздухе

    private CharacterController _characterController;     // Ссылка на компонент CharacterController
    private Transform _head;                               // Трансформ головы (камеры)

    public void Initialize(CharacterController characterController)
    {
        // Сохраняем ссылку на CharacterController
        _characterController = characterController;

        // Находим трансформацию основной камеры
        _head = Camera.main.transform;
    }

    public void Move(bool isGrounded)
    {
        // Получаем горизонтальный и вертикальный ввод от пользователя
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Вычисляем направление движения на основе положения камеры
        Vector3 moveDirection = _head.right * horizontal + _head.forward * vertical;

        // Определяем текущую скорость передвижения
        float speed = Input.GetKey(KeyCode.LeftShift) ? _runSpeed : _walkSpeed;

        // Если персонаж не стоит на земле, уменьшаем скорость движения
        if (!isGrounded)
        {
            speed *= _airControlMultiplier;
        }

        // Перемещаем персонажа в заданном направлении со скоростью
        _characterController.Move(moveDirection * speed * Time.deltaTime);
    }
}