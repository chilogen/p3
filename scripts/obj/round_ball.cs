using UnityEngine;
using System;

public class RoundBall : BaseBall
{
    protected override Vector3 GetForcePosition(Vector2 aimPosition,Transform ball)
    {
        float SubRidus = 1 - aimPosition.y * aimPosition.y;
        float TrueX = (float)Math.Sqrt(SubRidus - aimPosition.x * aimPosition.x);
        Vector3 position = new Vector3(TrueX, aimPosition.x, aimPosition.y);
        return Vector3.Scale(position, ball.localScale) + ball.transform.position;
    }
}