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
        public void North_Is_Opposite_South() => Assert.IsTrue(Direction.Cardinal.North.Inverse.Equals(Direction.Cardinal.South) && Direction.Cardinal.South.Inverse.Equals(Direction.Cardinal.North));

        [TestMethod]
        public void East_Is_Opposite_West() => Assert.IsTrue(Direction.Cardinal.East.Inverse.Equals(Direction.Cardinal.West) && Direction.Cardinal.West.Inverse.Equals(Direction.Cardinal.East));

        [TestMethod]
        public void All_Directions_Are_Unique() => CollectionAssert.AllItemsAreUnique(Enumerable.Concat(Direction.CardinalDirections.ToArray(), Direction.IntercardinalDirections.ToArray()).Concat(Direction.IntermediateCardinalDirections.ToArray()).ToArray(), "Duplicate(s) detected.");

        [TestMethod]
        public void All_Direction_Inversions_Are_Unique() 
            => CollectionAssert.AllItemsAreUnique(
                Enumerable.Concat(
                    Direction.CardinalDirections.Select(d => d.Inverse).ToArray(), 
                    Direction.IntercardinalDirections.Select(d => d.Inverse).ToArray())
                        .Concat(Direction.IntermediateCardinalDirections.Select(d => d.Inverse).ToArray()).ToArray(), "Duplicate(s) detected.");

        [TestMethod]
        public void All_Direction_Inversions_Are_Pointers_To_Different_Directions()
        {
            foreach (var direction in Direction.CardinalDirections)
                Assert.AreNotEqual(direction, direction.Inverse, $"Inverse of {direction} is itself.");

            foreach (var direction in Direction.IntercardinalDirections)
                Assert.AreNotEqual(direction, direction.Inverse, $"Inverse of {direction} is itself.");

            foreach (var direction in Direction.IntermediateCardinalDirections)
                Assert.AreNotEqual(direction, direction.Inverse, $"Inverse of {direction} is itself.");
        }

        [TestMethod]
        public void Dot_Net_Framework_Compiles_Globally_NonNull_TypeSafeEnum_Enumerations()
        {
            CollectionAssert.AllItemsAreNotNull(Direction.CardinalDirections.ToArray(),
                $"IReadonlyList {nameof(Direction.CardinalDirections)} contains null-pointer-reference(s).");
            CollectionAssert.AllItemsAreNotNull(Direction.IntercardinalDirections.ToArray(),
                $"IReadonlyList {nameof(Direction.IntercardinalDirections)} contains null-pointer-reference(s).");
            CollectionAssert.AllItemsAreNotNull(Direction.IntermediateCardinalDirections.ToArray(),
                $"IReadonlyList {nameof(Direction.IntermediateCardinalDirections)} contains null-pointer-reference(s).");
        }
    }
}
