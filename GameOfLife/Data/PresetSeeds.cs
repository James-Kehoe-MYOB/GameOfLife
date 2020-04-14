using System.Collections.Generic;
using GameOfLife.Business_Logic;
using GameOfLife.Business_Logic.Models;

namespace GameOfLife.Data {
    public static class PresetSeeds {
        private const int GliderHeight = 10;
        private const int GliderWidth = 10;

        private const string GliderData = "0000000000" +
                                          "0000000000" +
                                          "0001000000" +
                                          "0000100000" +
                                          "0011100000" +
                                          "0000000000" +
                                          "0000000000" +
                                          "0000000000" +
                                          "0000000000" +
                                          "0000000000";
        public static readonly BoardProperties Glider = new BoardProperties(
            SeedName.Glider, GliderHeight, GliderWidth, GliderData);

        private const int SmallExploderHeight = 10;
        private const int SmallExploderWidth = 11;

        private const string SmallExploderData = "00000000000" +
                                                 "00000000000" +
                                                 "00000000000" +
                                                 "00000100000" +
                                                 "00001110000" +
                                                 "00001010000" +
                                                 "00000100000" +
                                                 "00000000000" +
                                                 "00000000000" +
                                                 "00000000000";

        public static readonly BoardProperties SmallExploder = new BoardProperties(
            SeedName.SmallExploder, SmallExploderHeight, SmallExploderWidth, SmallExploderData);
        
        public static List<BoardProperties> SeedList = new List<BoardProperties> {
            Glider,
            SmallExploder
        };
    }
}