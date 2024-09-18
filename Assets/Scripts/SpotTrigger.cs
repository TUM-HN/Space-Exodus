using System;
using UnityEngine;

namespace UnityEngine.XR.Content.Walkthrough
{
    internal class SpotTrigger : WalkthroughTrigger
    {
        public GameObject m_spot;

        #pragma warning restore 649
        bool m_Triggered = false;

        void Start()
        {
            TriggerZone gameObject = m_spot.GetComponent<TriggerZone>();
            if (m_spot == null)
            {
                throw new Exception("no spot");
            }
            //m_spot.GetComponent<TriggerZone>().onEnterEvent.RemoveListener(i => SpotEnterHandler());
            gameObject.onEnterEvent.AddListener(i => SpotEnterHandler());
        }

        public override bool Check()
        {
            return m_Triggered;
        }

        public override bool ResetTrigger()
        {
            m_Triggered = false;
            if (m_spot == null) return false;

            //m_spot.GetComponent<TriggerZone>().onEnterEvent.RemoveListener(i => SpotEnterHandler());
            gameObject.GetComponent<TriggerZone>().onEnterEvent.AddListener(i => SpotEnterHandler());
            return true;
        }

        public void SpotEnterHandler() {
            
                var parent = GetComponentInParent<WalkthroughStep>();
                var walkthrough = GetComponentInParent<Walkthrough>();
                if (parent != null && walkthrough != null)
                {
                    var steps = walkthrough.steps;
                    var stepIndex = Array.IndexOf(steps, parent);
                    if (stepIndex != walkthrough.currentStep)
                        walkthrough.SkipToStep(stepIndex);
                }
            

            m_Triggered = true;
        }
    }
 }