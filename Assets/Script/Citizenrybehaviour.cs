using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Citizenrybehaviour : MonoBehaviour
{
    public enum State
    {
        None,
        Nomal,
        Crazy,
        Injury,
    }

    float moveSpeed = 2f;
    float moveDir = 0;
    float randRot = 0;
    //대충 필요한 변수들, 회전할때 부드럽게 할려면 최종 회전에서 Time.smoothDeltaTime을 활용 하면 됨.

    public State CitizenryState = State.None;
    public Vector3 Random;

    void Start()
    {
        Random.x = 90f;
        Random.y = 5f;
        Random.z = 5f;
        float totalRate = Random.x + Random.y + Random.z;
        float val = UnityEngine.Random.Range(0.0f, totalRate);
        if (val < Random.x)
            CitizenryState = State.Nomal;
        else if (val < Random.x + Random.y)
            CitizenryState = State.Crazy;
        else
            CitizenryState = State.Injury;
        // 이부분은 오브젝트를 여러개 배치할때 처음에 사방으로 퍼지게 하려고 넣는 부분임.
        // 방향값을 랜덤으로 시작.
        randRot = UnityEngine.Random.Range(-1f, 1f);
        transform.localRotation = Quaternion.Euler(0f, 180f * randRot, 0f);

        if (CitizenryState == State.Injury)
            moveSpeed = 0f;
    }

    void Update()
    {
        // 걸리는게 없으면 직진
        if (!Physics.Raycast(transform.position, transform.forward, 1f))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.smoothDeltaTime);
        }
        else
        {
            // 걸리는게 있으면 방향찾기 
            if (Physics.Raycast(transform.position, transform.forward, 1f))
            {
                if (CitizenryState == State.Crazy)
                    transform.Rotate(Vector3.up, -180);
                else if( CitizenryState == State.Nomal )
                {
                    // 좌,우,뒤로 하면 너무 끊어져보여서 그냥 랜덤값으로 방향 조절.
                    moveDir = UnityEngine.Random.Range(-1f, 1f);
                    transform.Rotate(Vector3.up, 180f * moveDir);
                }
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        // 8 시민
        // 9 미친놈

        // 충돌되면 그냥 지워.. 그리고 targets 초기화해.. 그리고 새로 돌아
        if (other.gameObject.layer == 11)
        {
            Destroy(this.gameObject);
        }
    }
}
