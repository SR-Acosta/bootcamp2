using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;
public class enemyDropSystem : MonoBehaviour
{
        [Serializable]
        public class ItemDrop
        {
            public GameObject itemPrefab;
            public int dropProbability;
        }
        [Header("Item configuration")]
        [Tooltip("You need to drag the prefabs of the items that the enemy can drop, note that they must be prefabs")]
        public ItemDrop[] itemDrops;
        [Tooltip("Probability of no item drop (in percentage)")]
        [Range(0, 100)]
        public int noDropProbability = 10;
        [Header("Drop Range configuration")]
        [Tooltip("This is the maximum distance from the enemy where the item can drop")]
        public float dropRange = 2f;
        // We call this function when the enemy is defeated
        public void Defeat()
        {
            int totalProbability = CalculateTotalProbability();
            int randomValue = Random.Range(0, totalProbability);
            if (randomValue < noDropProbability)
            {
                // No item dropped
                Destroy(gameObject);
                return;
            }
            int cumulativeProbability = noDropProbability;
            foreach (var itemDrop in itemDrops)
            {
                cumulativeProbability += itemDrop.dropProbability;
                if (randomValue < cumulativeProbability)
                {
                    InstantiateItem(itemDrop.itemPrefab);
                    break;
                }
            }
            Destroy(gameObject);
        }
        // Calculate the total probability of item drops
        private int CalculateTotalProbability()
        {
            int totalProbability = noDropProbability;
            foreach (var itemDrop in itemDrops)
            {
                totalProbability += itemDrop.dropProbability;
            }
            return totalProbability;
        }
        // Instantiate the item at a random drop position
        private void InstantiateItem(GameObject itemPrefab)
        {
            Vector2 dropPosition = GetRandomDropPosition();
            Instantiate(itemPrefab, dropPosition, Quaternion.identity);
        }
        // Generate a random position near the enemy for item drop
        private Vector2 GetRandomDropPosition()
        {
            Vector2 enemyPosition = transform.position;
            float offsetX = Random.Range(-dropRange, dropRange);
            float offsetY = Random.Range(-dropRange, dropRange);
            Vector2 dropPosition = enemyPosition + new Vector2(offsetX, offsetY);
            return dropPosition;
        }
}