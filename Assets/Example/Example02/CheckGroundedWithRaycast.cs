using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGroundedWithRaycast : MonoBehaviour
{

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private CharacterController _characterController;
    private Vector3 _moveDirection = Vector3.zero;
    private int _fieldLayer;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _fieldLayer = 1 << LayerMask.NameToLayer("Field");
    }

    private void Update()
    {
        bool isGrounded = IsCheckGrounded();
        Debug.Log($"isGrounded: {isGrounded}");

        if (isGrounded)
        {
            _moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            _moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                _moveDirection.y = jumpSpeed;
            }
        }

        _moveDirection.y -= gravity * Time.deltaTime;

        _characterController.Move(_moveDirection * Time.deltaTime);
    }

    /// <summary>
    /// 땅에 접지되어 있는지 여부를 확인
    /// </summary>
    /// <returns></returns>
    private bool IsCheckGrounded()
    {
        // CharacterController.IsGrounded가 true라면 Raycast를 사용하지 않고 판정 종료
        if (_characterController.isGrounded) return true;
        // 발사하는 광선의 초기 위치와 방향
        // 약간 신체에 박혀 있는 위치로부터 발사하지 않으면 제대로 판정할 수 없을 때가 있다.
        var ray = new Ray(this.transform.position + Vector3.up * 0.1f, Vector3.down);
        // 탐색 거리
        var maxDistance = 1.5f;
        // 광선 디버그 용도
        Debug.DrawRay(transform.position + Vector3.up * 0.1f, Vector3.down * maxDistance, Color.red);
        // Raycast의 hit 여부로 판정
        // 지상에만 충돌로 레이어를 지정
        return Physics.Raycast(ray, maxDistance, _fieldLayer);
    }
}