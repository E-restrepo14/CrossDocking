using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationVerticalMouse : MonoBehaviour
{

    // animate the game object from -1 to +1 and back
    public float minimum = -100.0F;
    public float maximum = 100.0F;

    // starting value for the Lerp
    static float t = 0.0f;

    private void Update()
    {

        GetComponent<RectTransform>().anchoredPosition = new Vector2(0,Mathf.Lerp(minimum, maximum, t));

        // .. and increate the t interpolater
        t += 0.5f * Time.deltaTime;

        // now check if the interpolator has reached 1.0
        // and swap maximum and minimum so game object moves
        // in the opposite direction.
        if (t > 1.0f)
        {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            t = 0.0f;
        }

    }
}
