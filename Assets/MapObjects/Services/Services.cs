using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapObjects.Services
{
    public class Services : MonoBehaviour
    {
        private List<IService> _services;

        private Dictionary<TickType, List<IService>> _dictionaryServices;

        private void Start()
        {
            _services.Add(new MapObjectService());

            _dictionaryServices = new Dictionary<TickType, List<IService>>();
            foreach (var service in _services)
            {
                _dictionaryServices[service.TickType].Add(service);
            }
        }

        private void Update()
        {
            foreach (var service in _dictionaryServices[TickType.Update])
            {
                service.Tick(Time.deltaTime);
            }
        }

        private void FixedUpdate()
        {
            foreach (var service in _dictionaryServices[TickType.FixedUpdate])
            {
                service.Tick(Time.fixedDeltaTime);
            }
        }

        private void LateUpdate()
        {
            foreach (var service in _dictionaryServices[TickType.LateUpdate])
            {
                service.Tick(Time.deltaTime);
            }
        }

        private IEnumerator CoroutineTick()
        {
            var time = 1f;
            var wfs = new WaitForSeconds(time);
            while (true)
            {
                yield return wfs;

                foreach (var service in _dictionaryServices[TickType.Coroutine])
                {
                    service.Tick(time);
                }
            }

        }
    }
}