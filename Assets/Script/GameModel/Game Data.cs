using System.Collections.Generic;
namespace GameModel
{
    public static class GameData
    {
        internal static List<int> ForceCutBeadList = new List<int>();

        internal const int TopBead = 1, BottomBead = 2, Empty = 0;
        
        public static readonly int[,] Board =
         {
             {0, 1, 0, 1, 0, 1, 0, 1 },
             {1, 0, 1, 0, 1, 0, 1, 0 },
             {0, 1, 0, 1, 0, 1, 0, 1 },
             {0, 0, 0, 0, 0, 0, 0, 0 },
             {0, 0, 0, 0, 0, 0, 0, 0 },
             {2, 0, 2, 0, 2, 0, 2, 0 },
             {0, 2, 0, 2, 0, 2, 0, 2 },
             {2, 0, 2, 0, 2, 0, 2, 0 },

           /* {0, 0, 0, 0, 0, 0, 0, 0 },
            {0, 0, 1, 0, 1, 0, 0, 0 },
            {0, 0, 0, 2, 0, 0, 0, 2 },
            {0, 0, 0, 0, 0, 0, 0, 0 },
            {0, 0, 0, 0, 0, 0, 0, 0 },
            {2, 0, 2, 0, 0, 0, 2, 0 },
            {0, 2, 0, 2, 0, 2, 0, 2 },
            {2, 0, 2, 0, 2, 0, 2, 0 },*/
         };

         // store king position info
         public static bool[,] kingBoard = new bool[8, 8];

        internal static readonly int[][] Gotopos =
         {
            new int[]{0,0,0},      //0
            new int[]{8,10},       //1
            new int[]{0,0,0},      //2
            new int[]{10,12},      //3
            new int[]{0,0,0},      //4
            new int[]{12,14},      //5
            new int[]{0,0,0},      //6
            new int[]{14},         //7
            new int[]{1,17},       //8
            new int[]{0,0,0},      //9
            new int[]{1,3,17,19},  //10
            new int[]{0,0,0},      //11
            new int[]{3,5,19,21},  //12
            new int[]{0,0,0},      //13
            new int[]{5,7,21,23},  //14
            new int[]{0,0,0},      //15
            new int[]{0,0,0},      //16
            new int[]{8,10,24,26}, //17
            new int[]{0,0,0},      //18
            new int[]{10,12,26,28},//19
            new int[]{0,0,0},      //20
            new int[]{12,14,28,30},//21
            new int[]{0,0,0},      //22
            new int[]{14,30},      //23
            new int[]{17,33},      //24
            new int[]{0,0,0},      //25
            new int[]{17,19,33,35},//26
            new int[]{0,0,0},      //27
            new int[]{19,21,35,37},//28
            new int[]{0,0,0},      //29
            new int[]{21,23,37,39},//30
            new int[]{0,0,0},      //31
            new int[]{0,0,0},      //32
            new int[]{24,26,40,42},//33
            new int[]{0,0,0},      //34
            new int[]{26,28,42,44},//35
            new int[]{0,0,0},      //36
            new int[]{28,30,44,46},//37
            new int[]{0,0,0},      //38
            new int[]{30,46},      //39
            new int[]{33,49},      //40
            new int[]{0,0,0},      //41
            new int[]{33,35,49,51},//42
            new int[]{0,0,0},      //43
            new int[]{35,37,51,53},//44
            new int[]{0,0,0},      //45
            new int[]{37,39,53,55},//46
            new int[]{0,0,0},      //47
            new int[]{0,0,0},      //48
            new int[]{40,42,56,58},//49
            new int[]{0,0,0},      //50
            new int[]{42,44,58,60},//51
            new int[]{0,0,0},      //52
            new int[]{44,46,60,62},//53
            new int[]{0,0,0},      //54
            new int[]{46,62},      //55
            new int[]{49},         //56
            new int[]{0,0,0},      //57
            new int[]{49,51},      //58
            new int[]{0,0,0},      //59
            new int[]{51,53},      //60
            new int[]{0,0,0},      //61
            new int[]{53,55},      //62
            new int[]{0,0,0},      //63
         };

        internal static readonly int[][] CutPosition =
        {
            new int[]{0,0,0},      //0
            new int[]{19},         //1
            new int[]{0,0,0},      //2
            new int[]{17,21},      //3
            new int[]{0,0,0},      //4
            new int[]{23,19},      //5
            new int[]{0,0,0},      //6
            new int[]{21},         //7
            new int[]{26},         //8
            new int[]{0,0,0},      //9
            new int[]{28,24},      //10
            new int[]{0,0,0},      //11
            new int[]{26,30},      //12
            new int[]{0,0,0},      //13
            new int[]{28},         //14
            new int[]{0,0,0},      //15
            new int[]{0,0,0},      //16
            new int[]{35},         //17
            new int[]{0,0,0},      //18
            new int[]{37,33,1,5},  //19
            new int[]{0,0,0},      //20
            new int[]{35,39,3,7},  //21
            new int[]{0,0,0},      //22
            new int[]{37,5},       //23
            new int[]{24,42},      //24
            new int[]{0,0,0},      //25
            new int[]{8,44,12,40}, //26
            new int[]{0,0,0},      //27
            new int[]{10,46,14,42},//28
            new int[]{0,0,0},      //29
            new int[]{12,44},      //30
            new int[]{0,0,0},      //31
            new int[]{0,0,0},      //32
            new int[]{19,51},      //33
            new int[]{0,0,0},      //34
            new int[]{17,53,21,49},//35
            new int[]{0,0,0},      //36
            new int[]{19,23,55,51},//37
            new int[]{0,0,0},      //38
            new int[]{21,53},      //39
            new int[]{26,58},      //40
            new int[]{0,0,0},      //41
            new int[]{24,60,28,56},//42
            new int[]{0,0,0},      //43
            new int[]{26,62,58,30},//44
            new int[]{0,0,0},      //45
            new int[]{28,60},      //46
            new int[]{0,0,0},      //47
            new int[]{0,0,0},      //48
            new int[]{35},         //49
            new int[]{0,0,0},      //50
            new int[]{33,37},      //51
            new int[]{0,0,0},      //52
            new int[]{35,39},      //53
            new int[]{0,0,0},      //54
            new int[]{37},         //55
            new int[]{42},         //56
            new int[]{0,0,0},      //57
            new int[]{40,44},      //58
            new int[]{0,0,0},      //59
            new int[]{42,46},      //60
            new int[]{0,0,0},      //61
            new int[]{44},         //62
            new int[]{0,0,0},      //63
         };


    }

}
