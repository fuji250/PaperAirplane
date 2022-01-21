using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchOperation : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool _isPushed = false; // �}�E�X��������Ă��邩������Ă��Ȃ���
    private Vector3 _nowMousePosi; // ���݂̃}�E�X�̃��[���h���W

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerController.gameState == "playing")
        {
            Vector3 nowmouseposi;
            Vector3 diffposi;

            // �}�E�X����������Ă��鎞�A�I�u�W�F�N�g�𓮂���
            if (_isPushed) {
                // ���݂̃}�E�X�̃��[���h���W���擾
                nowmouseposi = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                // ��O�̃}�E�X���W�Ƃ̍������v�Z���ĕω��ʂ��擾
                diffposi = nowmouseposi - _nowMousePosi;
                //�@Y�����̂ݕω�������
                diffposi.z = 0;
                // �J�n���̃I�u�W�F�N�g�̍��W�Ƀ}�E�X�̕ω��ʂ𑫂��ĐV�������W��ݒ�
                GetComponent<Transform>().position += diffposi;
                // ���݂̃}�E�X�̃��[���h���W���X�V
                _nowMousePosi = nowmouseposi;
           }
        }

        
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        // �����J�n�@�t���O�𗧂Ă�
        _isPushed = true;
        // �}�E�X�̃��[���h���W��ۑ�
        _nowMousePosi = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // �����I���@�t���O�𗎂Ƃ�
        _isPushed = false;
        _nowMousePosi = Vector3.zero;
    }
}
