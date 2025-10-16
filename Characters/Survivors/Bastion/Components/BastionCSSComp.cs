using UnityEngine;
using RoR2;
using System.Collections;

namespace BastionMod.Survivors.Bastion.Components
{
    public class BastionCSSComp : MonoBehaviour
    {
        private void OnEnable()
        {
            int number = Random.RandomRangeInt(0, 3);
            Log.Message($"Animation chosen is {number}");
            GetComponent<Animator>().SetInteger("TransformChoose", number);
        }
    }
}
