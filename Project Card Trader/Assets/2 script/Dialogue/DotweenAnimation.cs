using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class DotweenAnimation : MonoBehaviour
{
    List<string> actionRandom = new List<string>();

    [Range(0, 3)]
    public int animIndex;

    [Header("MOVE UP")]
    private float moveDist = 30;
    private float moveDuration = 0.2f;

    [Header("RotateLeftRight")]
    private float rotation = 30;
    private float rotDuration = 0.2f;
    private int numberOfLoopRot = 4;

    [Header("MoveLeftRight")]
    private float moveDistLR = 300f;
    private float moveDurationLR = 0.2f;
    private int numberOfLoopLR = 4;  
    
    
    [Header("Scaling")]
    private float scaleUpX = 3f;
    private float scaleUpXDur = 0.2f;
    private int numberOfLoopScaleUpX = 2;

    private float scaleUpY = 3f;
    private float scaleUpYDur = 0.2f;
    private int numberOfLoopScaleUpY = 2;

    private float scaleUpaX = 3f;
    private float scaleUpaY = 3f;
    private float scaleUpDur = 0.2f;
    private int numberOfLoopScaleUp = 2;

    private float scaleDownaX = 1.4f;
    private float scaleDownaY = 1.4f;
    private float scaleDownDur = 0.3f;
    private int numberOfLoopScaleDown = 2;


    private void Start()
    {
        actionRandom.Add("MoveUp");
        actionRandom.Add("RotateLeftRight");
        actionRandom.Add("MoveLeftRight");
        actionRandom.Add("Talk");
    }

    private void Awake()
    {
        ArriveAnimation();
    }

    private IEnumerator StartAnimation()
    {
        transform.rotation = Quaternion.Euler(0, 90, 0);
        yield return new WaitForSeconds(1);
        transform.DORotateQuaternion(Quaternion.Euler(0, 0, 0), 1).SetEase(Ease.OutBounce);
        MoveUp(2);
        yield return new WaitForSeconds(3);
        ExitAnimation();
    }

    private void ArriveAnimation()
    {
        StartCoroutine(StartAnimation());
    }

    private void ExitAnimation()
    {
        transform.DORotateQuaternion(Quaternion.Euler(0, 90, 0), 0.5f).SetEase(Ease.InSine).OnComplete(() =>
        {
            transform.parent.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            transform.DORotateQuaternion(Quaternion.Euler(0, 180, 0), 0.5f).SetEase(Ease.OutExpo).OnComplete(() => 
            {
                transform.DOMoveX(transform.position.x - 500, 1).SetEase(Ease.OutFlash);
            });
        });
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && DialogueManager.current.isPlayingDialogue) 
        {
            string rdm = actionRandom[animIndex];
            Invoke(rdm, 0); 
            print(rdm);
        }
    }

    public void MoveUp(int numberOfLoop = 8)
    {
        print(moveDist);
        transform.DOMoveY(transform.position.y + moveDist, moveDuration).SetLoops(numberOfLoop, LoopType.Yoyo).SetEase(Ease.OutSine);      
    }

    public void RotateLeftRight ()
    {
        transform.parent.DORotate(new Vector3(0, 0, rotation) , rotDuration).SetLoops(numberOfLoopRot, LoopType.Yoyo).SetEase(Ease.OutSine);
    }

    public void MoveLeftRight()
    {
        transform.DOMoveX(moveDistLR, moveDurationLR).SetLoops(numberOfLoopLR, LoopType.Yoyo).SetEase(Ease.OutSine);
    }

    public void Talk()
    {
        transform.parent.DOScale(new Vector3(transform.parent.localScale.x, transform.parent.localScale.y + 0.15f, 0.15f), scaleUpDur).SetLoops(8, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }
}
