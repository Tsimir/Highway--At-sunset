using UnityEngine;

[System.Serializable]  // Позволяет сериализацию класса для отображения в инспекторе Unity
public class JumpController
{
    [SerializeField] private float _jumpHeight = 1.5f;  // Высота прыжка
    [SerializeField] private float _gravity = -9.81f;   // Гравитация

    public float Gravity => _gravity;                   // Свойство для доступа к значению гравитации

    public void HandleJump(ref Vector3 velocity, bool isGrounded)
    {
        // Если персонаж стоит на земле и нажата кнопка прыжка
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            // Рассчитываем начальную скорость прыжка
            velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
        }
    }
}