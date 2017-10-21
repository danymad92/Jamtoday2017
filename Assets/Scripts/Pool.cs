using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FreakPool {

    public interface IPooleableObject {
        IPooleableObject Generate();
        void DestroyObject();
    }

    public class Pool<T> where T : IPooleableObject {

        private Queue<T> availableObjects;

        private List<T> usedObjects;

        private T baseObject;

        public Pool(T t) {
            availableObjects = new Queue<T>();
            usedObjects = new List<T>();
            baseObject = t;
        }

        /// <summary>
        /// Available Objects Count
        /// </summary>
        /// <returns></returns>
        public int AvailableObjects() {
            return availableObjects.Count;
        }

        /// <summary>
        /// Used Objects Count
        /// </summary>
        /// <returns></returns>
        public int UsedObjects() {
            return usedObjects.Count;
        }


        /// <summary>
        /// Set Pool Size
        /// </summary>
        /// <param name="size"></param>
        public void SetSize(int size) {
            ResizePool(size);
        }

        /// <summary>
        /// Release an Object to Pool
        /// </summary>
        /// <param name="m"> Object </param>
        /// <returns></returns>
        public bool Release(T m) {
            if (usedObjects.Contains(m)) {
                availableObjects.Enqueue(m);
                usedObjects.Remove(m);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Take an Object from Pool
        /// </summary>
        /// <param name="createIfNoAvailable"> True if you want to create an object if there are no one available </param>
        /// <returns></returns>
        public T Take(bool createIfNoAvailable = true) {

            T used = baseObject;

            if (availableObjects.Count == 0 && createIfNoAvailable) {
                used = (T)used.Generate();
                usedObjects.Add(used);
                return used;
            } else if (availableObjects.Count != 0) {
                used = availableObjects.Dequeue();
                usedObjects.Add(used);
                return used;
            }

            return default(T);
        }


        private void ResizePool(int size) {
            T obj = baseObject;

            int totalSize = GetSize();

            if (size > totalSize) {

                for (int i = availableObjects.Count; i < size - usedObjects.Count; ++i) {

                    obj =  (T) baseObject.Generate();
                    availableObjects.Enqueue(obj);

                }

            } else if (size < totalSize) {

                for (int i = totalSize; i > size; --i) {

                    if (availableObjects.Count > 0) {
                        obj = availableObjects.Dequeue();
                        obj.DestroyObject();
                    } else {
                        break;
                    }
                }
            }
        }

        private int GetSize() {
            return availableObjects.Count + usedObjects.Count;
        }

    }


}
