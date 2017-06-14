using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Direction;

namespace sourcetests
{
    [TestClass]
    public class DotNetCoreTests
    {
        [TestMethod]
        public void North_Is_Not_Null() => Assert.IsNotNull(Cardinal.North);

        [TestMethod]
        public void East_Is_Not_Null() => Assert.IsNotNull(Cardinal.East);

        [TestMethod]
        public void South_Is_Not_Null() => Assert.IsNotNull(Cardinal.South);

        [TestMethod]
        public void West_Is_Not_Null() => Assert.IsNotNull(Cardinal.West);

        [TestMethod]
        public void North_Is_Opposite_South()
            => Assert.IsTrue(Cardinal.North.Inverse.Equals(Cardinal.South) && Cardinal.South.Inverse.Equals(Cardinal.North));

        [TestMethod]
        public void East_Is_Opposite_West()
            => Assert.IsTrue(Cardinal.East.Inverse.Equals(Cardinal.West) && Cardinal.West.Inverse.Equals(Cardinal.East));

        [TestMethod]
        public void All_Directions_Are_Unique()
            => CollectionAssert.AllItemsAreUnique(Enumerable.Concat(Cardinal.All, InterCardinal.All).Concat(IntermediateCardinal.All).ToArray(), "Duplicate(s) detected.");

        [TestMethod]
        public void All_Direction_Inversions_Are_Unique()
            => CollectionAssert.AllItemsAreUnique(
                Enumerable.Concat(
                    Cardinal.All.Select(d => d.Inverse),
                    InterCardinal.All.Select(d => d.Inverse))
                          .Concat(IntermediateCardinal.All.Select(d => d.Inverse)).ToArray(), "Duplicate(s) detected.");

        [TestMethod]
        public void All_Direction_Inversions_Are_Pointers_To_Different_Directions()
        {
            foreach (var direction in Enumerable.Concat(Cardinal.All, InterCardinal.All).Concat(IntermediateCardinal.All))
                Assert.AreNotEqual(direction, direction.Inverse, $"Inverse of {direction} is itself.");
        }

        [TestMethod]
        public void All_Direction_Names_Are_Unique()
            => CollectionAssert.AllItemsAreUnique(
                Enumerable.Concat(
                        Cardinal.All.Select(d => d.Name),
                        InterCardinal.All.Select(d => d.Name))
                          .Concat(IntermediateCardinal.All.Select(d => d.Name)).ToArray(), "Duplicate(s) detected.");


        [TestMethod]
        public void Cycling_Terminates_Prior_To_Overlap()
            => Assert.AreNotEqual(Direction.CycleClockwise().First(), Direction.CycleClockwise().Last());

        [TestMethod]
        public void Rotating_Terminates_With_Overlap() 
            => Assert.AreEqual(Direction.RotateClockwise().First(), Direction.RotateClockwise().Last());

        [TestMethod]
        public void Dot_Net_Framework_Compiles_Globally_NonNull_TypeSafeEnum_Enumerations()
        {
            CollectionAssert.AllItemsAreNotNull(Enumerable.Concat(Cardinal.All, Cardinal.All.Select(d => d.Inverse)).ToArray(), $"{nameof(Cardinal)} contains null-pointer-reference(s).");

            CollectionAssert.AllItemsAreNotNull(Enumerable.Concat(InterCardinal.All, InterCardinal.All.Select(d => d.Inverse)).ToArray(), $"{nameof(InterCardinal)} contains null-pointer-reference(s).");

            CollectionAssert.AllItemsAreNotNull(Enumerable.Concat(IntermediateCardinal.All, IntermediateCardinal.All.Select(d => d.Inverse)).ToArray(), $"{nameof(IntermediateCardinal)} contains null-pointer-reference(s).");
        }
    }
}
