using UnityEngine;

namespace MyBird
{
    public class Player : MonoBehaviour
    {
        #region Variables
        private Rigidbody2D rb2D;
        //점프
        private bool keyJump = false;   //점프 키 인풋 체크
        [SerializeField]
        private float jumpForce = 5f;   //위방향으로 주는 힘

        //회전
        private Vector3 birdRotation;
        //위로 올라갈떄
        [SerializeField] private float upRotate = 2.5f;
        //내려갈때 회전속도
        [SerializeField] private float downRotate = - 5f;

        //이동
        //이동속도 - Translate 시작하면 자동 오른쪽 이동
        [SerializeField]private float moveSpeed = 5f;
        #endregion

        #region Unity Event Method
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //참조
            rb2D = this.GetComponent<Rigidbody2D>();
            
            
        }
        #endregion

        #region Custom Method
        // Update is called once per frame
        void Update()
        {
            //인풋처리
            ImputBird();
            RoateBird();

            //버드 이동
            MoveBird();
           
        }


        private void FixedUpdate()
        {
            
            if (keyJump)
            {
                Debug.Log("점프");
                JumpBird();
                keyJump = false;
            }
        }
        //인풋처리
        void ImputBird()
        {
            //스페이스키 또는 마우스 왼클릭 입력 받디기
            keyJump |= Input.GetKeyDown(KeyCode.Space);
            keyJump |= Input.GetMouseButtonDown(0);
        }
        
        void JumpBird()
        {
            //아래쪽에서 위쪽으로 힘을 준다
            //rb2D.AddForce(Vector2.up * 힘);
            rb2D.linearVelocity = Vector2.up * jumpForce;
        }

        //버드 회전하기
        void RoateBird()
        {
            //올라갈때 최대 + 30도 까지 회전 : rotateSpeed = 2.5f(upRotate)
            //내려갈때 - 90도까지 회전      : rotateSpeed = 5f(downRotate)
            float rotateSpeed = 0f;
            if (rb2D.linearVelocityY > 0f)
            {
                rotateSpeed = upRotate;
            }
            else if (rb2D.linearVelocityY < 0f)
            {
                rotateSpeed = downRotate;
            }
            birdRotation = new Vector3(0f, 0f, Mathf.Clamp((birdRotation.z + rotateSpeed), -90f, 30f));
            this.transform.eulerAngles = birdRotation;
        }

        void MoveBird()
        {
            this.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime, Space.World);
        }
        #endregion
    }

}