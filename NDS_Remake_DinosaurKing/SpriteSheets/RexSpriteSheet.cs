using System.Collections.Generic;

namespace NDS_Remake_DinosaurKing.SpriteSheets
{

    public enum RexSpriteSheetIndex : int
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
    
    public class RexSpriteSheet : SpriteSheet
    {
        // ReSharper disable once HeapView.ObjectAllocation.Evident
        public static SpriteSheet Instance { get; } = new RexSpriteSheet();

        private RexSpriteSheet()
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            Sections = new List<SpriteSheetSection>
            {
                new SpriteSheetSection(008, 160, 24, 32), //Down
                new SpriteSheetSection(032, 160, 24, 32), //Down_R
                new SpriteSheetSection(056, 160, 24, 32), //Down_L
                
                new SpriteSheetSection(008, 192, 24, 32), //Top
                new SpriteSheetSection(032, 192, 24, 32), //Top_R
                new SpriteSheetSection(056, 192, 24, 32), //Top_L
                
                new SpriteSheetSection(008, 224, 24, 32), //Side
                new SpriteSheetSection(032, 224, 24, 32), //Side
                new SpriteSheetSection(056, 224, 24, 32), //Side
                
                new SpriteSheetSection(008, 256, 24, 32), //Side
                new SpriteSheetSection(032, 256, 24, 32), //Side
                new SpriteSheetSection(056, 256, 24, 32), //Side
            };
        }
    }
}