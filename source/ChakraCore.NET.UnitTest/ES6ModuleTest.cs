﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChakraCore.NET.UnitTest
{
    [TestClass]
    public class ES6ModuleTest : UnitTestBase
    {
        protected override void SetupContext()
        {
        }


        [TestMethod]
        public void BasicClassProject()
        {
            var value = projectModuleClass("BasicExport", "TestClass");
            var result=value.CallFunction<int, int>("Test1", 1);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void MultipleClassProject()
        {
            for (int i = 0; i < 10; i++)
            {
                var value = projectModuleClass("BasicExport", "TestClass");
                var result = value.CallFunction<int, int>("Test1", 1);
                Assert.AreEqual(2, result);
            }
        }

        [TestMethod]
        public void ImportExport()
        {
            var value = projectModuleClass("BasicImport", "TestClass2");
            var result = value.CallFunction<int, int>("Test2", 1);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void NestedImport()
        {
            var value = projectModuleClass("NestedImport0", "Test");
            var result = value.CallFunction<int, int>("Test1", 1);
            Assert.AreEqual(2, result);
        }


        [TestMethod]
        public async Task ModulePromiseAsync()
        {
            context.ServiceNode.GetService<IJSValueConverterService>().RegisterTask<int>();
            var c=projectModuleClass("ModulePromise", "test");
            var tt = await c.CallFunction<int, Task<int>>("test1",1);
            Assert.AreEqual(2, tt);
        }

    }
}
