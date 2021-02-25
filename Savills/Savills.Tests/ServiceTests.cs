using NUnit.Framework;
using Savills.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Savills.Tests
{
    public class ServiceTests
    {
        ISavillsService _service;

        [SetUp]
        public void Setup()
        {
            _service = new SavillsService();
        }

        [Test]
        public void Tests()
        {
        }
    }

}
