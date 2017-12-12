using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroBehaviour : MonoBehaviour
{
    float moveSpeed = 2f;
    float moveDir = 0;
    float randRot = 0;
    //대충 필요한 변수들, 회전할때 부드럽게 할려면 최종 회전에서 Time.smoothDeltaTime을 활용 하면 됨.

    public Vector3 Random;

    public Transform headTransform = null;
    float Distance = 3.0f;
    public float sightAngleMin = 130.0f;
    public float sightAngleMin1 = 170.0f;
    public float MoveDistance = 1.0f;
    public float Distance2 = 1.5f;


    public GameObject[] targets;
    public Transform[] target;
    public Vector3 direction;
    public float velocity;
    public float accelaration;

    public bool isTarget = false;

    public Transform targetTransform;

    public float waitTime = 5.0f;
    public float Timer = 0.0f;

    void Start()
    {
        Random.x = 90f;
        Random.y = 5f;
        Random.z = 5f;
        float totalRate = Random.x + Random.y + Random.z;
        float val = UnityEngine.Random.Range(0.0f, totalRate);
        //if (val < Random.x)
        //    CitizenryState = State.Nomal;
        //else if (val < Random.x + Random.y)
        //    CitizenryState = State.Crazy;
        //else
        //    CitizenryState = State.Injury;
        // 이부분은 오브젝트를 여러개 배치할때 처음에 사방으로 퍼지게 하려고 넣는 부분임.
        // 방향값을 랜덤으로 시작.
        randRot = UnityEngine.Random.Range(-1f, 1f);
        transform.localRotation = Quaternion.Euler(0f, 180f * randRot, 0f);

        //if (CitizenryState == State.Injury)
        //    moveSpeed = 0f;

        // StartCoroutine("Move");
        //StartCoroutine("CoroutineSight");

        targets = GetRootObjects();
    }

    private void Update()
    {

        //Move();
        ToTargeting();
        TargetMove();

        Timer += Time.deltaTime;
        if (waitTime < Timer)
        {
            // 대기시간동안 찾지 못하면 삭제
            if (isTarget == false)
                Destroy(this.gameObject);
        }
    }

    void Move()
    {
        if (isTarget)
            return;

        // 걸리는게 없으면 직진
        if (!Physics.Raycast(transform.position, transform.forward, 1f))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.smoothDeltaTime);
        }
        else
        {
            // 걸리는게 있으면 방향찾기 
            if (Physics.Raycast(transform.position, transform.forward, 3f))
            {
                //if (CitizenryState == State.Crazy)
                //transform.Rotate(Vector3.up, -180);
                //else if (CitizenryState == State.Nomal)
                //{
                // 좌,우,뒤로 하면 너무 끊어져보여서 그냥 랜덤값으로 방향 조절.
                moveDir = UnityEngine.Random.Range(-1f, 1f);
                transform.Rotate(Vector3.up, 180f * moveDir);
                //}
            }
        }
    }

    public void ToTargeting()
    {
        if (isTarget == true)
            return;
        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i] == null)
                continue;
            // Player의 위치와 이 객체의 위치를 빼고 단위 벡터화 한다.
            direction = (targets[i].transform.position - transform.position).normalized;
            // 가속도 지정 (추후 힘과 질량, 거리 등 계산해서 수정할 것)
            accelaration = 0.1f;
            // 초가 아닌 한 프레임으로 가속도 계산하여 속도 증가
            velocity = (velocity + accelaration * Time.deltaTime);
            // Player와 객체 간의 거리 계산
            float distance = Vector3.Distance(targets[i].transform.position, transform.position);
            // 일정거리 안에 있을 시, 해당 방향으로 무빙
            if (distance <= Distance2)
            {
                targetTransform = targets[i].transform;
                isTarget = true;
                //this.transform.position = new Vector3(transform.position.x + (direction.x * velocity),transform.position.y + (direction.y * velocity),transform.position.z);
            }
            // 일정거리 밖에 있을 시, 속도 초기화 
            else
            {
                velocity = 0.0f;
            }
        }
    }

    public void TargetMove()
    {
        if (isTarget == false)
            return;

        Vector3 diff = targetTransform.position - transform.position;
        transform.position = transform.position + (diff.normalized * 3.0f * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(diff.normalized);
    }

    public GameObject[] GetRootObjects()
    {
        List<GameObject> roots = new List<GameObject>();
        foreach (Transform transforms in UnityEngine.Object.FindObjectsOfType<Transform>())
        {
            Debug.Log("name : " + transforms.gameObject.name);
            if (transforms.parent == null)
            {
                if (transforms.gameObject.layer == 9)
                    roots.Add(transforms.gameObject);
            }
        }
        return roots.ToArray();
    }

    public void OnTriggerEnter(Collider other)
    {
        // 8 시민
        // 9 미친놈

        // 충돌되면 그냥 지워.. 그리고 targets 초기화해.. 그리고 새로 돌아
        if (other.gameObject.layer == 9)
        {
            Destroy(other.gameObject);
            Timer = 0f;
            isTarget = false;
        }
    }
}
