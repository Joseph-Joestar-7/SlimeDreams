using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    [SerializeField] private float _dissolveTime = 0.75f;

    private SpriteRenderer _spriteRenderer;
    private Material material;

    private int dissolveAmount = Shader.PropertyToID("_DissolveAmount");

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        material = _spriteRenderer.material;
        material.SetFloat(dissolveAmount, 0);
    }

    public IEnumerator Vanish()
    {
        float elapsedTime = 0f;
        while (elapsedTime < _dissolveTime)
        {
            elapsedTime += Time.deltaTime;
            float lerpedDissolve = Mathf.Lerp(0, 1.1f, elapsedTime / _dissolveTime);

            material.SetFloat(dissolveAmount, lerpedDissolve);

            yield return null;
        }
    }

    public IEnumerator Appear()
    {
        float elapsedTime = 0f;
        while (elapsedTime < _dissolveTime)
        {
            elapsedTime += Time.deltaTime;
            float lerpedDissolve = Mathf.Lerp(1.1f, 0, elapsedTime / _dissolveTime);

            material.SetFloat(dissolveAmount, lerpedDissolve);

            yield return null;
        }
    }
}
