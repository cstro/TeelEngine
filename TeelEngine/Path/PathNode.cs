﻿using System;
using Microsoft.Xna.Framework;

namespace TeelEngine.Path
{
    public class PathNode
    {
        public PathNode ParentNode
        {
            get { return parentNode; }
            set {
                if (!Start)
                {
                    parentNode = value;
                }
                else
                {
                    Console.WriteLine("Something is my parent :O!");
                } }
        } // The node that is before in the path
        private PathNode parentNode = null;
        // The nodes around this node 
        // These will be null if there is no node, or a node that cannot be passed through
        public PathNode NorthNode { get; set; }
        public PathNode EastNode { get; set; }
        public PathNode SouthNode { get; set; }
        public PathNode WestNode { get; set; }

        public int EstimatedCost { get; set; }      // g
        public int MovementCost { get; set; }       // h
        public int TotalCost { get; set; }          // f (g + h)

        public bool IsSolid { get; set; }
        public Point Location { get; private set; }
        public Direction Direction { get; set; }
        public bool Start = false;

        public PathNode(Point location)
        {
            Location = location;
        }

        /// <summary>
        /// Calculates the total cost of moving through the node
        /// </summary>
        public void CalculateTotalCost()
        {
            TotalCost = EstimatedCost + MovementCost;
        }
    }
}