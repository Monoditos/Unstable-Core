using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingMiniGame : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform topPivot;
    [SerializeField] Transform bottomPivot;
    [SerializeField] Transform fish;
    float fishPosition;
    float fishDestination;
    float fishTimer;
    [SerializeField] float timerMultiplier = 1f;
    float fishSpeed;
    [SerializeField] float smoothMotion = 1f;



    [SerializeField] Transform hook;
    float hookPosition;
    [SerializeField] float hookSize = 0.1f;
    [SerializeField] float hookPower = 5f;
    float hookProgress;
    float hookPullVelocity;
    [SerializeField] float hookPullPower = 0.01f;
    [SerializeField] float hookGravityPower = 0.005f;

    [SerializeField] float hookProgressDegredationPower = 1f;
    [SerializeField] SpriteRenderer hookSpriteRenderer;
    [SerializeField] Transform progressBarContainer;

    private void Start()
    {
        Resize();
    }

    void Resize()
    {
        Bounds b = hookSpriteRenderer.bounds;
        float ySize = b.size.y;
        Vector3 ls = hook.localScale;
        float distance = Vector3.Distance(topPivot.position, bottomPivot.position);
        ls.y = distance / ySize * hookSize;
        hook.localScale = ls;
    }
    private void Update()
    {
        Fish();
        Hook();
        ProgressCheck();
    }
    void Fish()
    {
        fishTimer -= Time.deltaTime;
        if (fishTimer < 0f)
        {
            fishTimer = UnityEngine.Random.value * timerMultiplier;
            fishDestination = UnityEngine.Random.value;
        }

        fishPosition = Mathf.SmoothDamp(fishPosition, fishDestination, ref fishSpeed, smoothMotion);
        fish.position = Vector3.Lerp(bottomPivot.position, topPivot.position, fishPosition);
    }

    void Hook()
    {
        if (Input.GetMouseButton(0))
        {
            hookPullVelocity += hookPullPower * Time.deltaTime;
        }

        hookPullVelocity -= hookGravityPower * Time.deltaTime;
        hookPosition += hookPullVelocity;
        if ((hookPosition <= (hookSize / 2)) || (hookPosition >= (1 - hookSize / 2)))
        {
            hookPullVelocity = 0;
        }
        hookPosition = Mathf.Clamp(hookPosition, hookSize / 2, 1 - hookSize / 2);

        hook.position = Vector3.Lerp(bottomPivot.position, topPivot.position, hookPosition);
    }



    private void ProgressCheck()
    {
        Vector3 ls = progressBarContainer.localScale;
        ls.y = hookProgress;
        progressBarContainer.localScale = ls;

        float min = hookPosition - hookSize / 2;
        float max = hookPosition + hookSize / 2;
        if (min < fishPosition && fishPosition < max)
        {
            hookProgress += hookPower * Time.deltaTime;
        }
        else
        {
            hookProgress -= hookProgressDegredationPower * Time.deltaTime;
        }
        hookProgress = Mathf.Clamp(hookProgress, 0f, 1f);
    }
}
