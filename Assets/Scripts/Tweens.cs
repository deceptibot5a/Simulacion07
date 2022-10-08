using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweens : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    [SerializeField, Range(0,1)] private float normalizedTime;
    [SerializeField] private float duration = 5f;
    [SerializeField] Color colorI;
    [SerializeField] Color colorF;
    [SerializeField] AnimationCurve curve;

    private float currentTime = 0f;
    private Vector3 initialPosition;
    private Vector3 finalPosition;
    private SpriteRenderer spriteRenderer;
    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartTween();
    }

    private void Update() {
        normalizedTime = currentTime / duration;
        transform.position = Vector3.Lerp(initialPosition, finalPosition, EaseInQuad(normalizedTime));
        spriteRenderer.color = Color.Lerp(colorI, colorF, curve.Evaluate(normalizedTime));
        currentTime += Time.deltaTime;
        if (normalizedTime >= 1) {
            Debug.Log("Completed");
        }
        if (Input.GetKeyDown(KeyCode.Space)) StartTween();
    }
    private void StartTween() {
        currentTime = 0f;
        initialPosition = transform.position;
        finalPosition = targetTransform.position;
    }
    private float EaseInQuad(float x) {
        return x * x; 
    }
}
