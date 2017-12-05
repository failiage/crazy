using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MurdererBehaviour : MonoBehaviour
{


}

//    // 이동 속도
//    public float movespeed = 0.5f;
//    // 공격 범위
//    public float attackRange = 0.5f;


//    private Vector3 SpawnPosition = Vector3.zero;
//    private Quaternion SpawnRotation;
//    private Vector3 StartPosition = Vector3.zero;
//    private Vector3 EndPosition = Vector3.zero;
//    public float MoveDistance = 1.0f;

//    private Vector3 MinErrorRange = Vector3.zero;
//    private Vector3 MaxErrorRange = Vector3.zero;

//    public Transform headTransform = null;
//#pragma warning disable 414
//    private UnityEngine.AI.NavMeshPath path = null;
//#pragma warning restore 414
//    // 타겟 추격시 한계거리
//    public float MaxTargetDistante = 30.0f;

//    public bool bIsTargeting = false;
//    public float phaseTime = 2.0f;
//    public float sightAngleMin = 130.0f;
//    public float sightAngleMin1 = 170.0f;
//    public float GhostDistance = 3.0f;
//    public float GhostDistanc1 = 2.5f;
//    public float GhostDistance2 = 1.5f;

//    public float PursuitTime = 3.0f;
//    private float SetTargetingTime = 0.0f;

//#pragma warning disable 414
//    /// <summary>
//    /// 타겟 캐스팅 레이어 마스크
//    /// </summary>
//    LayerMask layerMask = (-1);
//#pragma warning restore 414

//    private ParticleSystem particle = null;

//    // 데미지 처리
//    public float Breath = 0.0f;
//    public float Damage = 0.0f;

//    bool bIsHafe = false;
//    public bool IndicatorState = false;

//    void Awake()
//    {
//        MinErrorRange.z = -0.1f;
//        MaxErrorRange.z = 0.1f;
//    }

//    private void OnEnable()
//    {
//    }

//    public void GhostShadowSpawn()
//    {
//        StartCoroutine("CoroutineSight");
//        StartCoroutine("CoroutineAttack");
//    }

//    IEnumerator CoroutineSight()
//    {
//        //yield return new WaitForSeconds(1.0f);


//        //Vector3 lookPos = Vector3.zero;
//        //Vector3 lookDir = Vector3.zero;
//        //Vector3 targetPos = Vector3.zero;
//        //Vector3 targetDir = Vector3.zero;
//        //RaycastHit hitInfo;
//        //while (true)
//        //{
//        //    lookPos = headTransform.position;
//        //    lookDir = headTransform != null ? headTransform.up : transform.forward;
//        //    lookDir.y = 0.0f;
//        //    //targetPos = GameManager.instance.player.transform.position + (GameManager.instance.player.standingState == PlayerBehaviour.StandingState.Standing ? Vector3.up * 0.8f : Vector3.up * 0.4f);
//        //    targetDir = targetPos - headTransform.position;

//        //    // Physics.SphereCast (레이저를 발사할 위치, 구의 반경, 발사 방향, 충돌 결과, 최대 거리)
//        //    if (Physics.SphereCast(lookPos, 0.01f, targetDir, out hitInfo, GhostDistance)
//        //      && hitInfo.collider.gameObject == GameManager.instance.player.gameObject)
//        //    {
//        //        if (Vector3.Angle(lookDir, targetDir) < sightAngleMin * 0.5f)
//        //        {
//        //            if (GameManager.instance.player.standingState == PlayerBehaviour.StandingState.Standing)
//        //            {
//        //                if (eMovePath == MovePath.Line)
//        //                    StopCoroutine("GhostShadowPatrolforLine");
//        //                else if (eMovePath == MovePath.Quadrangle)
//        //                    StopCoroutine("GhostShadowPatrolforQuadrangle");
//        //                else if (eMovePath == MovePath.rectangle)
//        //                    StopCoroutine("GhostShadowPatrolforRectangle");

//        //                StartCoroutine("GhostShadowTargeting");
//        //                yield return null;
//        //            }
//        //        }
//        //    }
//#if UNITY_EDITOR
//            //Debug.DrawLine(lookPos, targetPos, new Color(10.0f, 0.0f, 1.0f - 10.0f), 0.1f);

//            Vector3 lookPos2 = headTransform != null ? headTransform.position : (transform.forward + Vector3.up);
//            Vector3 lookDir2 = headTransform != null ? headTransform.up : transform.forward;
//            Vector3 Endpos = EndPosition;
//            Endpos.y = lookPos2.y;
//            Debug.DrawLine(lookPos2, Endpos, Color.yellow, 0.1f);
//            lookDir2.y = 0.0f;
//            DrawDebugingInfo(lookPos2, lookDir2);
//            //DrawDebugingInfo(lookPos, targetDir);
//#endif
//            yield return null;
//        }
//    }

//    IEnumerator CoroutineAttack()
//    {
//        yield return new WaitForSeconds(0.2f);

//        //while (true)
//        //{
//        //    if (GameManager.instance.player.isDead == false &&
//        //        (GameManager.instance.player.transform.position - transform.position).sqrMagnitude < (attackRange * attackRange))
//        //    {

//        //        //GameManager.instance.UpdateBreath(Constants.GhostShadowTakebreath[(int)Global.playerInfo.difficulty - 1]);
//        //        GameManager.instance.player.TakeDamage(Constants.GhostShadowTakeHP[(int)Global.playerInfo.difficulty - 1], Vector3.zero);
//        //        //GameManager.instance.player.TakeDamage(1, Vector3.zero);

//        //        GameManager.instance.UpdateBreath(Breath);
//        //        //GameManager.instance.player.TakeDamage(Damage, Vector3.zero);
//        //        Global.soundManager.PlayAudioBypass("SFX_Char_Hit", "");
//        //        Global.soundManager.PlayAudioSFX("SFX_Ghost_BlackGhost_Attack", "SFX_Ghost_BlackGhost_Attack" + GetInstanceID(), transform.position);
//        //        Global.soundManager.StopAudioSFX("SFX_Ghost_BlackGhost_Footstep" + GetInstanceID());
//        //        //WDLogger.Log("캐릭터 히트");
//        //        transform.position = SpawnPosition;
//        //        transform.rotation = SpawnRotation;

//        //        StopAllCoroutines();
//        //        this.gameObject.SetActive(false);
//        //        //AIStart();
//        //        yield return null;
//        //    }
//        //    yield return null;
//        //}
//    }

//    void AIStart()
//    {
//        //StopCoroutine("GhostShadowPursuit");

//        //if (eMovePath == MovePath.Line)
//        //    StartCoroutine("GhostShadowPatrolforLine");
//        //else if (eMovePath == MovePath.Quadrangle)
//        //    StartCoroutine("GhostShadowPatrolforQuadrangle");
//        //else if (eMovePath == MovePath.rectangle)
//        //    StartCoroutine("GhostShadowPatrolforRectangle");

//        //StartCoroutine("CoroutineSight");
//        //StartCoroutine("CoroutineAttack");
//    }

//    IEnumerator CoroutineSightphase()
//    {
//        //StopCoroutine("GhostShadowTargeting");
//        yield return new WaitForSeconds(1.0f);

////        Global.soundManager.PlayAudioSFX("SFX_Ghost_BlackGhost_Footstep", "SFX_Ghost_BlackGhost_Footstep" + GetInstanceID(), gameObject);

////        Vector3 lookPos = Vector3.zero;
////        Vector3 lookDir = Vector3.zero;
////        Vector3 targetPos = Vector3.zero;
////        Vector3 targetDir = Vector3.zero;
////        Vector3 GotoPosition = Vector3.zero;
////        RaycastHit hitInfo;
////        float fTime = 0.0f;
////        while (true)
////        {
////            if (GameManager.instance.player.isDead == true)
////            {
////                yield return null;
////                continue;
////            }

////            if (animator)
////            {
////                animator.SetBool("isWalk", false);
////                animator.SetBool("isSearch", true);
////                //animator.SetBool("IsDetect", false);
////            }

////            //WDLogger.Log("똑바로 찾는다");
////            GotoPosition = transform.position + (transform.forward * 10.0f);
////            Vector3 diff = GotoPosition - transform.position;
////            transform.position = transform.position + (diff.normalized * movespeed * Time.deltaTime);


////            lookPos = headTransform.position;
////            lookDir = headTransform != null ? headTransform.up : transform.forward;
////            lookDir.y = 0.0f;
////            targetPos = GameManager.instance.player.transform.position + (GameManager.instance.player.standingState == PlayerBehaviour.StandingState.Standing ? Vector3.up * 0.8f : Vector3.up * 0.4f);
////            targetDir = targetPos - headTransform.position;

////            if (Physics.SphereCast(lookPos, 0.01f, targetDir, out hitInfo, GhostDistance2)
////                && hitInfo.collider.gameObject == GameManager.instance.player.gameObject)
////            {
////                if (Vector3.Angle(lookDir, targetDir) < sightAngleMin1 * 0.5f)
////                {
////                    StartCoroutine("CoroutineJumpAttack");
////                    yield return null;
////                }
////            }

////            // 시간안에 잡히지 않는다면 평상시 행동으로 되돌아간다.
////            fTime += Time.deltaTime;
////            if (fTime > phaseTime)
////            {
////                //WDLogger.Log("시간 만료");
////                //if (eMovePath == MovePath.Line)
////                //{
////                //    bIsTargeting = false;
////                //    StartCoroutine("GhostShadowPatrolforLine");
////                //}
////                //else if (eMovePath == MovePath.Quadrangle)
////                //{
////                //    bIsTargeting = false;
////                //    StartCoroutine("GhostShadowPatrolforQuadrangle");
////                //}
////                //StartCoroutine("CoroutineSight");

////                AIStart();
////                yield return null;
////                continue;
////            }



////#if UNITY_EDITOR
////            Vector3 lookPos2 = headTransform != null ? headTransform.position : (transform.forward + Vector3.up);
////            Vector3 lookDir2 = headTransform != null ? headTransform.up : transform.forward;
////            DrawDebugingInfo(lookPos2, lookDir2);
////#endif
////            yield return null;
////        }
//    //}

////#if UNITY_EDITOR
////    float updateTime = 0.0f;
////    void DrawDebugingInfo(Vector3 pos, Vector3 dir)
////    {
////        if ((updateTime += Time.deltaTime) < 0.1f)
////            return;
////        updateTime = 0.0f;
////        //DrawArc(pos, dir, Constants.securityGuardFarDistance[(int)Global.playerInfo.difficulty - 1], (isMoving ? sightAngleMin : sightAngleMax), 5, Color.yellow, 0.1f);
////        DrawArc(pos, dir, GhostDistance2, sightAngleMin1, 5, Color.blue, 0.1f);
////        DrawArc(pos, dir, GhostDistance, sightAngleMin, 5, Color.red, 0.1f);
////    }

////    void DrawArc(Vector3 position, Vector3 dir, float radius, float angle, int polys, Color color, float duration)
////    {
////        Vector3 pos, next, d;
////        Quaternion rot = Quaternion.LookRotation(dir);
////        float ang;

////        d = Vector3.zero;
////        d.z = radius;
////        pos = position;
////        ang = angle / (float)(polys - 1);
////        for (int i = 0; i < polys; i++)
////        {
////            next = position + (Quaternion.Euler(0.0f, -angle * 0.5f + i * ang, 0.0f) * rot) * d;
////            if (i > 0 || angle != 360.0f)
////                Debug.DrawLine(pos, next, color, duration);
////            pos = next;
////        }
////        if (angle < 360.0f)
////            Debug.DrawLine(pos, position, color, duration);
////    }
////#endif
//}

