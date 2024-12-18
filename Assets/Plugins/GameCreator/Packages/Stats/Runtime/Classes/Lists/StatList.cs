using System;
using System.Linq;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Stats
{
    [Serializable]
    public class StatList : TPolymorphicList<StatItem>
    {
        [SerializeReference] private StatItem[] m_Stats = Array.Empty<StatItem>();
        
        // PROPERTIES: ----------------------------------------------------------------------------

        public override int Length => this.m_Stats.Length;

        // PUBLIC METHODS: ------------------------------------------------------------------------

        public StatItem Get(int index) => this.m_Stats[index];

        public StatItem Get(string id)
        {
           return m_Stats.Where(stat => stat.Stat.ID.ToString() == id).FirstOrDefault();
        }
    }
}