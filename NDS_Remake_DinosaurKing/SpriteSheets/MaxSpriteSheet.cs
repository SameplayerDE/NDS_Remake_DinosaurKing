using System.Collections.Generic;

namespace NDS_Remake_DinosaurKing.SpriteSheets
{

    public enum MaxSpriteSheetIndex : int
    {
        Down_Idle = 0,
        Down_Right = 1,
        Down_Left = 2,
        Top_Idle = 3,
        Top_Right = 4,
        Top_Left = 5,
        Left_Idle = 6,
        Left_Right = 7,
        Left_Left = 8,
        Right_Idle = 9,
        Right_Right = 10,
        Right_Left = 11,
    }
    
    public class MaxSpriteSheet : SpriteSheet
    {
        // ReSharper disable once HeapView.ObjectAllocation.Evident
        public static SpriteSheet Instance { get; } = new MaxSpriteSheet();

        private MaxSpriteSheet()
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            Sections = new List<SpriteSheetSection>
            {
                new SpriteSheetSection(008, 008, 24, 32), //Down
                new SpriteSheetSection(032, 008, 24, 32), //Down_R
                new SpriteSheetSection(056, 008, 24, 32), //Down_L
                
                new SpriteSheetSection(008, 040, 24, 32), //Top
                new SpriteSheetSection(032, 040, 24, 32), //Top_R
                new SpriteSheetSection(056, 040, 24, 32), //Top_L
                
                new SpriteSheetSection(008, 072, 24, 32), //Side
                new SpriteSheetSection(032, 072, 24, 32), //Side
                new SpriteSheetSection(056, 072, 24, 32), //Side
                
                new SpriteSheetSection(008, 104, 24, 32), //Side
                new SpriteSheetSection(032, 104, 24, 32), //Side
                new SpriteSheetSection(056, 104, 24, 32), //Side
            };
        }
    }
}