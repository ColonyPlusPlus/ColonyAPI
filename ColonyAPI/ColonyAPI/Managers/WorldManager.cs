using Pipliz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ColonyAPI.Managers
{
    public class WorldManager
    {
        public static string XZPositionToString(Vector3Int position)
        {
            return position.x + "," + position.z;
        }

        public static string XYZPositionToString(Vector3Int position)
        {
            return position.x + "," + position.y + "," + position.z;
        }

        public static Vector3Int positionToVector3Int(Vector3 pos)
        {
            int playerX = Pipliz.Math.RoundToInt(pos.x);
            int playerY = Pipliz.Math.RoundToInt(pos.y);
            int playerZ = Pipliz.Math.RoundToInt(pos.z);

            Vector3Int position = new Vector3Int(playerX, playerY, playerZ);

            return position;
        }
    }
}
