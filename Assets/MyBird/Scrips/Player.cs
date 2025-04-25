using UnityEngine;

namespace MyBird
{
    public class Player : MonoBehaviour
    {
        #region Variables
        private Rigidbody2D rb2D;
        //����
        private bool keyJump = false;   //���� Ű ��ǲ üũ
        [SerializeField]
        private float jumpForce = 5f;   //���������� �ִ� ��

        //ȸ��
        private Vector3 birdRotation;
        //���� �ö󰥋�
        [SerializeField] private float upRotate = 2.5f;
        //�������� ȸ���ӵ�
        [SerializeField] private float downRotate = - 5f;

        //�̵�
        //�̵��ӵ� - Translate �����ϸ� �ڵ� ������ �̵�
        [SerializeField]private float moveSpeed = 5f;
        #endregion

        #region Unity Event Method
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //����
            rb2D = this.GetComponent<Rigidbody2D>();
            
            
        }
        #endregion

        #region Custom Method
        // Update is called once per frame
        void Update()
        {
            //��ǲó��
            ImputBird();
            RoateBird();

            //���� �̵�
            MoveBird();
           
        }


        private void FixedUpdate()
        {
            
            if (keyJump)
            {
                Debug.Log("����");
                JumpBird();
                keyJump = false;
            }
        }
        //��ǲó��
        void ImputBird()
        {
            //�����̽�Ű �Ǵ� ���콺 ��Ŭ�� �Է� �޵��
            keyJump |= Input.GetKeyDown(KeyCode.Space);
            keyJump |= Input.GetMouseButtonDown(0);
        }
        
        void JumpBird()
        {
            //�Ʒ��ʿ��� �������� ���� �ش�
            //rb2D.AddForce(Vector2.up * ��);
            rb2D.linearVelocity = Vector2.up * jumpForce;
        }

        //���� ȸ���ϱ�
        void RoateBird()
        {
            //�ö󰥶� �ִ� + 30�� ���� ȸ�� : rotateSpeed = 2.5f(upRotate)
            //�������� - 90������ ȸ��      : rotateSpeed = 5f(downRotate)
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