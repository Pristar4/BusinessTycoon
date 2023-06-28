using System.Collections.Generic;
using UnityEngine;

namespace BT
{
    public class ResearchTree : MonoBehaviour
    {
        public List<ResearchNode> researchNodes;
    }

    [System.Serializable]
    public class ResearchNode
    
    {
        public string id;
        public string name;
        public string description;
        public bool isResearched;
        public List<string> prerequisites;

        public bool CanBeResearched(List<ResearchNode> nodes)
        {
            if (isResearched)
            {
                return false;
            }

            foreach (var prerequisite in prerequisites)
            {
                var node = nodes.Find(n => n.id == prerequisite);
                if (node == null || !node.isResearched)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
