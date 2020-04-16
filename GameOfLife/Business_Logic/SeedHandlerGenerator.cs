using GameOfLife.Business_Logic.Exceptions;
using GameOfLife.Business_Logic.Interfaces;
using GameOfLife.Data;
using GameOfLife.Data_Access;
using GameOfLife.Data_Access.Interfaces;

namespace GameOfLife.Business_Logic {
    public static class SeedHandlerGenerator {
        public static ISeedHandler ParseSelection(string selection, IUserInterface UI, IValidator validator) {
            return selection switch {
                "1" => new DefaultSeedHandler(SeedName.Glider),
                "2" => new DefaultSeedHandler(SeedName.SmallExploder),
                "3" => new CustomSeedHandler(UI, validator),
                _ => throw new SelectionOutOfRangeException()
            };
        }
    }
}