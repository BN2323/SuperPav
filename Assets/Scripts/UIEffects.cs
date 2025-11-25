using System.Collections;
using UnityEngine;

public class UIEffects : MonoBehaviour
{
    public IEnumerator PunchScale(Transform target)
    {
        Vector3 original = target.localScale;

        target.localScale = original * 1.1f;
        yield return new WaitForSeconds(0.1f);

        target.localScale = original;
    }

    public IEnumerator ShakeUI(RectTransform target, float strength = 6f, float duration = 0.15f)
    {
        Vector3 original = target.anchoredPosition;
        float time = 0f;

        while (time < duration)
        {
            float offsetX = Random.Range(-1f, 1f) * strength;
            float offsetY = Random.Range(-1f, 1f) * strength;

            target.anchoredPosition = original + new Vector3(offsetX, offsetY, 0);

            time += Time.deltaTime;
            yield return null;
        }

        target.anchoredPosition = original;
    }
}
