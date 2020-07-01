using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerPosition : MonoBehaviour {


    [SerializeField] private Player player;
    [SerializeField] private FloatReference zOffSet;
    //Reset to vector3
    public void Reset()
    {
        Vector3 p1Pos = player.GetResetPosition();
        Vector3 position = new Vector3(p1Pos.x, p1Pos.y, p1Pos.z -1);
        transform.position = position;
    }
    //Reset To Transform
    public void Reset2()
    {
        Transform resetTo = player.GetResetTransform();
        transform.position = resetTo.TransformPoint(0,0, zOffSet.Value);
        transform.rotation = resetTo.rotation;
    }

}
