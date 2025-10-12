using System;

namespace Classes
{
    /// <summary>
    /// Summary description for BackGroundTile.
    /// </summary>
    public class BackGroundTile
    {
        public byte move_cost; /* field_0 189B4 */
        public byte field_1; /* 189B5 */
        public byte field_2; /* 189B6 */
        public byte tile_index; /* 189B7 field_3 */

        public BackGroundTile(byte MoveCost, byte v1, byte v2, byte v3)
        {
            move_cost = MoveCost;
            field_1 = v1;
            field_2 = v2;
            tile_index = v3;
        }
    }
}
