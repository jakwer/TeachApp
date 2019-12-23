﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Storage;

namespace TeachApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SampleController : ControllerBase
    {

        private readonly ILogger<SampleController> _logger;

        public SampleContext _context { get; }

        public SampleController(ILogger<SampleController> logger, SampleContext context)
        {
            _logger = logger;
            this._context = context;

            if (_context.Samples.Count() == 0)
            {
                _context.Samples.Add(new Sample { Title = "Item1" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Sample> Get()
        {
            var x = _context.Samples.ToArray();
            _logger.LogError("{@x}", x);
            return x;
        }
    }
}