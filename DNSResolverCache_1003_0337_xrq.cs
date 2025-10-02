// 代码生成时间: 2025-10-03 03:37:19
/// <summary>
/// DNS解析和缓存工具
/// </summary>
using System;
using System.Net;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DnsCacheTool
{
    public class DNSResolverCache
    {
        private static readonly Dictionary<string, IPAddress[]> _cache = new Dictionary<string, IPAddress[]>();
        private static readonly object _lock = new object();

        /// <summary>
        /// 解析DNS并缓存结果
        /// </summary>
        /// <param name="host">主机名</param>
        /// <returns>主机的IP地址数组</returns>
        public static async Task<IPAddress[]> ResolveAndCacheDNSAsync(string host)
        {
            if (string.IsNullOrWhiteSpace(host))
                throw new ArgumentException("Host name cannot be null or whitespace.", nameof(host));

            lock (_lock)
            {
                if (_cache.ContainsKey(host))
                {
                    // 如果缓存中存在，直接返回缓存结果
                    return _cache[host];
                }
            }

            // 执行DNS解析
            IPAddress[] addresses = await Dns.GetHostAddressesAsync(host);
            lock (_lock)
            {
                // 将解析结果添加到缓存中
                _cache[host] = addresses;
            }
            return addresses;
        }

        /// <summary>
        /// 从缓存中获取DNS解析结果
        /// </summary>
        /// <param name="host">主机名</param>
        /// <returns>主机的IP地址数组，如果没有缓存则返回null</returns>
        public static IPAddress[] GetCachedDNS(string host)
        {
            if (string.IsNullOrWhiteSpace(host))
                throw new ArgumentException("Host name cannot be null or whitespace.", nameof(host));

            lock (_lock)
            {
                if (_cache.TryGetValue(host, out IPAddress[] cachedAddresses))
                {
                    return cachedAddresses;
                }
            }
            return null;
        }
    }
}
