using UnityEngine;

[System.Serializable]  // ��������� ������������ ������ ��� ����������� � ���������� Unity
public class CrouchController
{
    [SerializeField] private float _crouchHeight = 1f;           // ������ ��������� � �������
    [SerializeField] private float _standingHeight = 2f;         // ������ ��������� � ������� ���������
    [SerializeField] private float _crouchTransitionSpeed = 5f;  // �������� �������� ����� �����������
    [SerializeField] private float _typeOfCrunch = 0;

    private CharacterController _characterController;            // ������ �� ��������� CharacterController
    private bool _isCrouching;                                    // ����, ������������, ��������� �� �������� � �������

    public void Initialize(CharacterController characterController)
    {
        // ��������� ������ �� CharacterController
        _characterController = characterController;
    }

    public void HandleCrouch()
    {
        switch (_typeOfCrunch) // ����� ���� ����������
            { case 0:
                // ���� ������ ������� Left Control, �������� ���������
                if (Input.GetKeyDown(KeyCode.LeftControl))
                {
                    _isCrouching = true;
                }
                // ���� �������� ������� Left Control, ������
                else if (Input.GetKeyUp(KeyCode.LeftControl))
                {
                    _isCrouching = false;
                }
                break;
                case 1:
                // ���� ������ ������� Left Control, ������ ���������
                if (Input.GetKeyDown(KeyCode.LeftControl))
                {
                    _isCrouching = !_isCrouching;
                }
                break;


        }





        // ������������� ������� ������ � ����������� �� ��������� ���������
        float targetHeight = _isCrouching ? _crouchHeight : _standingHeight;

        // ������� ������� ������ ��������� � ������� ������
        _characterController.height = Mathf.Lerp(
            _characterController.height,
            targetHeight,
            Time.deltaTime * _crouchTransitionSpeed
        );
    }
}