using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPlace : MonoBehaviour
{
    [SerializeField] bool correctPlace0;
    [SerializeField] bool correctPlace1;
    //public bool information;

    public bool checkPosition(int position) {
        if (position == 0) {
            if (correctPlace0) {
                Debug.Log("correctPlace 0");
                return true;
            }
        } else if (position == 1) {
            if (correctPlace1) {
                Debug.Log("correctPlace 1");
                return true;
            }
        }
        return false;
    }
}
