using UnityEngine;
using UnityEngine.UI;

public class DynamicUIScaler : MonoBehaviour
{
    private CanvasScaler canvasScaler;

    void Start()
    {
        // Получаем ссылку на Canvas Scaler
        canvasScaler = GetComponent<CanvasScaler>();

        // Устанавливаем масштаб в зависимости от текущего разрешения экрана
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        if (screenWidth / screenHeight >= 1.7777f)
        {
            // Широкоэкранный режим
            canvasScaler.matchWidthOrHeight = 0.5f; // Масштабируем по ширине
        }
        else
        {
            // Стандартный режим
            canvasScaler.matchWidthOrHeight = 1f; // Масштабируем по высоте
        }
    }
}