using UnityEngine;

// 플레이어 캐릭터를 사용자 입력에 따라 움직이는 스크립트
public class PlayerMovement : MonoBehaviour {
    public float moveSpeed = 5f; // 앞뒤 움직임의 속도
    
    private Animator playerAnimator; // 플레이어 캐릭터의 애니메이터
    private PlayerInput playerInput; // 플레이어 입력을 알려주는 컴포넌트
    private Rigidbody playerRigidbody; // 플레이어 캐릭터의 리지드바디

    Vector3 moveDistance;
    float move;

    private void Start() {
        // 사용할 컴포넌트들의 참조를 가져오기
        playerInput = GetComponent<PlayerInput>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    // FixedUpdate는 물리 갱신 주기에 맞춰 실행됨
    private void FixedUpdate() {

        // 움직임 실행
        Move();

        Vector3 horizontal = new Vector3(playerInput.moveHorizontal, 0f, 0f);
        Vector3 vertical = new Vector3(0f, 0f, playerInput.moveVertical);

        // 입력값에 따라 애니메이터의 Move 파라미터 값을 변경
        if(horizontal.magnitude > vertical.magnitude)
        {
            move = playerInput.moveHorizontal;
        }
        else if(vertical.magnitude > horizontal.magnitude)
        {
            move = playerInput.moveVertical;
        }
        else
        {
            if (vertical.magnitude == 0 && horizontal.magnitude == 0)
            {
                move = 0;
            }
            else move = playerInput.moveVertical;
        }
        playerAnimator.SetFloat("Move", move);
    }

    // 입력값에 따라 캐릭터를 앞뒤로 움직임
    private void Move() {
        moveDistance = new Vector3(playerInput.moveHorizontal, 0f, playerInput.moveVertical);
        playerRigidbody.MovePosition(playerRigidbody.position + moveDistance * moveSpeed * Time.deltaTime);
    }
}