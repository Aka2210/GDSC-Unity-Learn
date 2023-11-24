using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    [SerializeField] Transform Player;
    public float mouseSensitivity = 100f;
    public Object player;

    float xRotation = 0f;
    public float YRotation = 0f;

    void Start()
    {
        //�N�ƹ���b�ù������������áC
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //����ƹ����ʫe��ۮt���ȡA����-1��1�����C
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //������Z�b��V�ݹL�h�A�Hx�b�������u�A���ਤ�פj��s�hZ�b�V�U�ݡA�Ϥ��A�]�����B�ϥ� "-="�C
        xRotation -= mouseY;

        //����x�b����u��b-90��90����
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //������Z�b��V�ݹL�h�A�Hy�b�������u�A���ਤ�פj��s�hZ�b�V�k�ݡA�Ϥ��A�]�����B�ϥ� "+="�C
        YRotation += mouseX;

        //�קKYRotation�L���W�j�δ�p�C
        if (YRotation >= 180)
            YRotation -= 360;
        else if (YRotation <= -180)
            YRotation += 360;

        //�q�L�کԨ��ӧ��ܷ�e����ȡC
        transform.rotation = Quaternion.Euler(xRotation, YRotation, 0f);
        Player.rotation = Quaternion.Euler(0f, YRotation, 0f);

        //���n�g��:localrotation�|�ɭP����@�۹������󪺬۹����Arotation�Ϫ���@�۹���ӥ@�ɪ�����C
    }
}
