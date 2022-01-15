using System;
using UnityEngine;

public class XUiC_DialIndicator : XUiController
{
    private string TAG = "["+typeof(XUiC_DialIndicator).Name+"]";
    private bool isDirty;
    private bool ClampValue = true;

    private float velocity = 0f;
    private float duration = 0.1f;

    private float indicatorValue;
    private float lastValue;
    private float rangeMax;
    private float rangeMin = 0f;
    private float valueRange;

    private float startAngle;
    private float endAngle;
    private float angleRange;

    private float indicatorAngle;


    public override void Update(float _dt)
    {
        base.Update(_dt);
        if (base.ViewComponent.IsVisible && (isDirty || lastValue != indicatorValue))
        {
            angleRange = calculateAngleRange(startAngle, endAngle);
            valueRange = rangeMax - rangeMin;

            lastValue = getLastValue(lastValue + 1, indicatorValue + 1) - 1;

            float iV = lastValue;
            if (ClampValue)
            {
                iV = Mathf.Clamp(iV, rangeMin, rangeMax);
            }

            indicatorAngle = (iV * (angleRange / valueRange));
            indicatorAngle = startAngle - indicatorAngle;
            indicatorAngle %= 360;

            ViewComponent.UiTransform.localEulerAngles = new Vector3(0f, 0f, indicatorAngle);
            isDirty = false;
        }

    }

    public override bool ParseAttribute(string name, string value, XUiController _parent)
    {
        bool consumed = base.ParseAttribute(name, value, _parent);
        if (consumed)
        {
            return true;
        }

        float temp = 0;
        if (name != null){
            switch(name)
            {
                case "indicator_value":
                    temp = indicatorValue;
                    float.TryParse(value, out indicatorValue);
                    isDirty |= temp != indicatorValue;
                    consumed = true;
                    break;
                case "range_max":
                    temp = rangeMax;
                    float.TryParse(value, out rangeMax);
                    isDirty |= temp != rangeMax;
                    consumed = true;
                    break;
                case "range_min":
                    temp = rangeMin;
                    float.TryParse(value, out rangeMin);
                    isDirty |= temp != rangeMin;
                    consumed = true;
                    break;
                case "start_angle":
                    temp = startAngle;
                    float.TryParse(value, out startAngle);
                    isDirty |= temp != startAngle;
                    consumed = true;
                    break;
                case "end_angle":
                    temp = endAngle;
                    float.TryParse(value, out endAngle);
                    isDirty |= temp != endAngle;
                    consumed = true;
                    break;
                case "limit_indicator_to_range":
                    bool b = ClampValue;
                    ClampValue = StringParsers.ParseBool(value, 0, -1, true);
                    isDirty |= b != ClampValue;
                    consumed = true;
                    break;
                case "animation_duration":
                    float.TryParse(value, out duration);
                    consumed = true;
                    break;
            }
        }

        return consumed;
    }

    public override void OnOpen()
    {
        base.OnOpen();
        isDirty = true;
        lastValue = indicatorValue;
    }

    private float calculateAngleRange(float a, float b)
    {
        float angleRange = a - b;
        angleRange %= 360;

        if (angleRange < 0)
        {
            angleRange = Math.Abs(360 + angleRange);
        }

        return angleRange != 0 ? angleRange : 360f;
    }

    private float getLastValue(float current, float target)
    {
        float val = Mathf.SmoothDamp(current, target, ref velocity, duration);
        float diff = Math.Abs(target - val);
        if ((diff / target) < 0.005)
        {
            val = target;
            velocity = 0;
        }
        return val;
    }
}