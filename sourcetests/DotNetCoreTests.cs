using static Direction; // Makes the resource local to this file.

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
        public void Dot_Net_Framework_Compiles_Globally_NonNull_TypeSafeEnum()
        {
            CollectionAssert.AllItemsAreNotNull(CardinalDirections.ToArray(),
                $"IReadonlyList {nameof(CardinalDirections)} contains null-pointer-reference(s).");
            CollectionAssert.AllItemsAreNotNull(IntercardinalDirections.ToArray(),
                $"IReadonlyList {nameof(IntercardinalDirections)} contains null-pointer-reference(s).");

        }
    }
}
