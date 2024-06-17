﻿using Microsoft.AspNetCore.Mvc;
using Redis.Sentinel.Services;

namespace Redis.Sentinel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedisController : ControllerBase
    {
        //localhost:5000/api/redis/setvalue/name/vural
        [HttpGet("[action]/{key}/{value}")]
        public async Task<IActionResult> SetValue(string key, string value)
        {
            var redis = await RedisService.RedisMasterDatabase();
            await redis.StringSetAsync(key, value);
            return Ok();
        }

        //localhost:5000/api/redis/getvalue/name
        [HttpGet("[action]/{key}")]
        public async Task<IActionResult> GetValue(string key)
        {
            var redis = await RedisService.RedisMasterDatabase();
            var data = await redis.StringGetAsync(key);
            return Ok(data.ToString());
        }
    }
}