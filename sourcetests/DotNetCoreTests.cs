using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace sourcetests
{
    [TestClass]
    public class DotNetCoreTests
    {
        [TestMethod]
        public void North_Is_Not_Null() => Assert.IsNotNull(Direction.Cardinal.North);

        [TestMethod]
        public void East_Is_Not_Null() => Assert.IsNotNull(Direction.Cardinal.East);

        [TestMethod]
        public void South_Is_Not_Null() => Assert.IsNotNull(Direction.Cardinal.South);

        [TestMethod]
        public void West_Is_Not_Null() => Assert.IsNotNull(Direction.Cardinal.West);


        [TestMethod]
        public void Dot_Net_Framework_Compiles_Globally_NonNull_TypeSafeEnum_Enumerations()
        {
            CollectionAssert.AllItemsAreNotNull(Direction.CardinalDirections.ToArray(),
                $"IReadonlyList {nameof(Direction.CardinalDirections)} contains null-pointer-reference(s).");
            CollectionAssert.AllItemsAreNotNull(Direction.IntercardinalDirections.ToArray(),
                $"IReadonlyList {nameof(Direction.IntercardinalDirections)} contains null-pointer-reference(s).");

        }
    }
}
