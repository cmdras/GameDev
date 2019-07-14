using System.Collections;
using System.Collections.Generic;
using RPG.Movement;
using UnityEngine;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                MoveToCursor();
            }
        }

        public void MoveToCursor()
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool hasHit = Physics.Raycast(ray, out hitInfo);
            if (hasHit)
            {
                GetComponent<Mover>().MoveTo(hitInfo.point);
            }
        }
    }

}