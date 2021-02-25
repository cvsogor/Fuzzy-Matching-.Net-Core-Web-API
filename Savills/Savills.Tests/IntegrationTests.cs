using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NUnit.Framework;
using Savills.CoreWebServer.Controllers;
using Savills.Data;
using Savills.Service;
using System.IO;

namespace Savills.Tests
{
    public class Tests
    {
        SavillsController _controller;
        ISavillsService _service;
        ILogger<SavillsController> _logger;

        [SetUp]
        public void Setup()
        {
            _service = new SavillsService();
            _controller = new SavillsController(_logger, _service);
        }

        [Test]
        public void IntegrationTests()
        {
            using (StreamReader r = new StreamReader("s1.json"))
            {
                string json = r.ReadToEnd();
                S1 s1 = JsonConvert.DeserializeObject<S1>(json);
                _controller.S1(s1);
            }
            using (StreamReader r = new StreamReader("s1p.json"))
            {
                string json = r.ReadToEnd();
                S1 s1 = JsonConvert.DeserializeObject<S1>(json);
                _controller.S1(s1);
            }
            using (StreamReader r = new StreamReader("s2.json"))
            {
                string json = r.ReadToEnd();
                S2 s2 = JsonConvert.DeserializeObject<S2>(json);
                _controller.S2(s2);
            }
            using (StreamReader r = new StreamReader("s2p.json"))
            {
                string json = r.ReadToEnd();
                S2 s2 = JsonConvert.DeserializeObject<S2>(json);
                _controller.S2(s2);
            }
            using (StreamReader r = new StreamReader("s2pp.json"))
            {
                string json = r.ReadToEnd();
                S2 s2 = JsonConvert.DeserializeObject<S2>(json);
                _controller.S2(s2);
            }
            using (StreamReader r = new StreamReader("s2m.json"))
            {
                string json = r.ReadToEnd();
                S2 s2 = JsonConvert.DeserializeObject<S2>(json);
                _controller.S2(s2);
            }
        }
    }
}