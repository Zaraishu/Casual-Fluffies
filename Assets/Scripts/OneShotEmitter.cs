using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShotEmitter : MonoBehaviour {

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(gameObject.GetComponent<ParticleSystem>().main.duration);
            Destroy(gameObject);
        }
}
