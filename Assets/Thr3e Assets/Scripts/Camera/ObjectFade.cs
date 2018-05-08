/* Created by Pixel Lifetime */

using System.Collections;
using System.Collections.Generic;

using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace PixelLifetime.TwitchHelp
{
    public class ObjectFade : MonoBehaviour
    {
        [SerializeField] private Material _fadedMaterial;
        [SerializeField] private Transform _target;

        [SerializeField] private LayerMask _maskingObjectsLayerMask;
        [SerializeField] private QueryTriggerInteraction _queryTriggerInteraction = QueryTriggerInteraction.Ignore;

        private Renderer _lastRenderer;
        private Material _lastMaterial;

        private void Update()
        {
            if (this._lastRenderer != null)
            {
                this._lastRenderer.sharedMaterial = this._lastMaterial;
            }

            Ray ray = new Ray(this.transform.position, this._target.transform.position - this.transform.position);

            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit, (this._target.transform.position - this.transform.position).magnitude, this._maskingObjectsLayerMask, this._queryTriggerInteraction))
            {
                this._lastRenderer = raycastHit.collider.GetComponent<Renderer>();
                this._lastMaterial = this._lastRenderer.sharedMaterial;

                this._lastRenderer.sharedMaterial = this._fadedMaterial;
            }
            //Debug.Log(raycastHit.collider);
        }

#if UNITY_EDITOR
        protected virtual void OnDrawGizmos()
        {
            Gizmos.DrawLine(this.transform.position, this.transform.position + (this._target.transform.position - this.transform.position));
        }
#endif
    }
}

namespace PixelLifetime.TwitchHelp.UTILITY
{
#if UNITY_EDITOR
    [CustomEditor(typeof(ObjectFade))]
    [CanEditMultipleObjects]
    public class ObjectFadeEditor : Editor
    {
        private void OnEnable()
        {

        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

#pragma warning disable 0219
            ObjectFade sObjectFade = target as ObjectFade;
#pragma warning restore 0219
        }
    }
#endif
}