using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FollowersTracker : MonoBehaviour
{
    public TMP_Text tmpText;

    // Update is called once per frame
    void Update()
    {
        if (GlobalControl.Instance != null)
        {
            tmpText.text = GlobalControl.Instance.Followers.ToString();
        }
    }
}
