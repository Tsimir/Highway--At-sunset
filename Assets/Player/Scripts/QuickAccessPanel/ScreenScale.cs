using UnityEngine;
using UnityEngine.UI;

public class DynamicUIScaler : MonoBehaviour
{
    private CanvasScaler canvasScaler;

    void Start()
    {
        // �������� ������ �� Canvas Scaler
        canvasScaler = GetComponent<CanvasScaler>();

        // ������������� ������� � ����������� �� �������� ���������� ������
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        if (screenWidth / screenHeight >= 1.7777f)
        {
            // �������������� �����
            canvasScaler.matchWidthOrHeight = 0.5f; // ������������ �� ������
        }
        else
        {
            // ����������� �����
            canvasScaler.matchWidthOrHeight = 1f; // ������������ �� ������
        }
    }
}